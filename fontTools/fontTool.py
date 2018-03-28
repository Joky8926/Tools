#!/usr/bin/python
#coding=utf-8
from Tkinter import *
import tkFileDialog
import tkMessageBox
from PIL import Image
import math
import os
import sys

DOUBLE_CHARS = [ord('"')]

def readFile(filename):
    txt_file    = open(filename, "r")
    content     = txt_file.read()
    txt_file.close()
    return content

def saveFile(filename, content):
    file = open(filename, 'w')
    file.write(content)
    file.close()

class UsedHeight:
    def __init__(self, left=0, right=0, y=0):
        self.left   = left
        self.right  = right
        self.y      = y

    def clone(self):
        return UsedHeight(self.left, self.right, self.y)

class Hole:
    def __init__(self, left=0, right=0, top=0, bottom=0):
        self.left   = left
        self.right  = right
        self.top    = top
        self.bottom = bottom
        self.x      = left
        self.y      = top
        self.width  = right - left
        self.height = bottom - top

class CharImage:
    __isNumberAequilate = False
    __padding           = 1
    __maxNumberWidth    = 0
    __minTop            = 9999
    __maxBottom         = 0

    def __init__(self, image, rect, charCode):
        self.image          = image.crop(rect)
        self.charCode       = charCode
        self.__width        = self.image.width
        self.__height       = self.image.height
        self.acreage        = self.image.width * self.image.height
        self.__x            = 0
        self.__y            = 0
        self.__isAequilate  = CharImage.__isNumberAequilate and charCode >= ord('0') and charCode <= ord('9')
        if self.__isAequilate and self.__width > CharImage.__maxNumberWidth:
            CharImage.__maxNumberWidth = self.__width
        self.__top  = rect[1]
        bottom      = rect[3]
        if self.__top < CharImage.__minTop:
            CharImage.__minTop = self.__top
        if bottom > CharImage.__maxBottom:
            CharImage.__maxBottom = bottom

    def getX(self):
        return self.__x

    def setX(self, num):
        self.__x = num

    def getY(self):
        return self.__y

    def setY(self, num):
        self.__y = num

    def getWidth(self):
        if self.__isAequilate:
            return CharImage.__maxNumberWidth
        return self.__width

    def getHeight(self):
        return self.__height

    def getXadvance(self):
        return self.getWidth() + CharImage.__padding

    def getRect(self):
        left = self.__x
        if self.__isAequilate:
            left += (CharImage.__maxNumberWidth - self.__width) / 2
        right = left + self.__width
        return (left, self.__y, right, self.__y + self.__height)

    def getYoffset(self):
        return self.__top - CharImage.__minTop

    @classmethod
    def getLineHeight(cls):
        return cls.__maxBottom - cls.__minTop

    @classmethod
    def config(cls, isAequilate, padding):
        cls.__isNumberAequilate = isAequilate
        cls.__padding           = padding

########################################################################################
## 合图相关
########################################################################################
def sortByWidthHeight(charA, charB):
    if charB.getHeight() == charA.getHeight():
        return charB.getWidth() - charA.getWidth()
    return charB.getHeight() - charA.getHeight()

def sortByCharCode(charA, charB):
    return charA.charCode - charB.charCode

class FontPage:
    def __init__(self, lstCharImg, outDir, filename, hasSpace):
        self.__lstCharImg   = lstCharImg
        self.__outDir       = outDir
        self.__fileName     = filename
        self.__hasSpace     = hasSpace
        self.__width        = 0
        self.__height       = 0
        self.__lstCharImg.sort(sortByWidthHeight)
        self.__resetSize()
        self.__createBigImage()
        self.__saveFntFile()

    def __createBigImage(self):
        img = Image.new("RGBA", (self.__width, self.__height), (0, 0, 0, 0))
        for charImg in self.__lstCharImg:
            img.paste(charImg.image, charImg.getRect())
        img.save(self.__outDir + self.__fileName + '.png', 'PNG')

    def __resetSize(self):
        self.__currX    = 0
        self.__heights  = []
        self.__holes    = []
        if self.__width == 0 or self.__height == 0:
            self.__calSize()
        else:
            if self.__width > self.__height:
                self.__height *= 2
            else:
                self.__width *= 2
        self.__addChars()

    def __calSize(self):
        totalAcre = 0
        for charImg in self.__lstCharImg:
            totalAcre += charImg.acreage
        exp         = int(math.ceil(math.log(totalAcre, 2)))
        heightExp   = exp / 2
        widthExp    = heightExp + exp % 2
        self.__height   = int(math.pow(2, heightExp))
        self.__width    = int(math.pow(2, widthExp))

    def __addChars(self):
        lstChars = []
        lstChars.extend(self.__lstCharImg)
        while len(lstChars) > 0:
            while len(self.__holes) > 0:
                hole        = self.__holes[0]
                bestMatch   = None
                n           = 0
                while len(lstChars) > n:
                    charImg     = lstChars[n]
                    tmpWidth    = charImg.getWidth() + 2
                    tmpHeight   = charImg.getHeight() + 2
                    if hole.width == tmpWidth and hole.height == tmpHeight:
                        bestMatch = charImg
                        break
                    elif hole.width >= tmpWidth and hole.height >= tmpHeight:
                        if not bestMatch or charImg.getWidth() > bestMatch.getWidth():
                            bestMatch = charImg
                    n += 1
                if bestMatch:
                    if hole.width > tmpWidth:
                        hole2 = Hole(hole.left + tmpWidth, hole.right, hole.top, hole.bottom)
                        self.__holes.append(hole2)
                    if hole.height > tmpHeight:
                        hole2 = Hole(hole.left, hole.left + tmpWidth, hole.top + tmpHeight, hole.bottom)
                        self.__holes.append(hole2)
                    self.__addCharByPos(hole.x, hole.y, bestMatch)
                    lstChars.remove(bestMatch)
                self.__holes.pop(0)
            ok      = False
            i       = 0
            origX   = self.__currX
            while len(lstChars) > i:
                charImg = lstChars[i]
                if charImg.getWidth() <= self.__width - self.__currX:
                    if self.__addChar(charImg):
                        lstChars.remove(charImg)
                        ok = True
                        if origX > self.__currX:
                            break
                        else:
                            origX = self.__currX
                    else:
                        self.__resetSize()
                        return
                else:
                    i += 1
            if not ok:
                if not self.__addChar(lstChars.pop(0)):
                    self.__resetSize()
                    return

    def __addChar(self, charImg):
        for i in range(len(self.__heights) + 1):
            if self.__currX + charImg.getWidth() > self.__width:
                self.__currX = 0
            cy = 0
            for usedHeight in self.__heights:
                if self.__currX >= usedHeight.right:
                    continue
                if self.__currX + charImg.getWidth() < usedHeight.left:
                    break
                if cy < usedHeight.y:
                    cy = usedHeight.y
            if cy + charImg.getHeight() <= self.__height:
                self.__addCharByPos(self.__currX, cy, charImg, True)
                self.__currX += charImg.getWidth() + 1
                return True
            else:
                if i < len(self.__heights):
                    self.__currX = self.__heights[i].right
        return False

    def __addCharByPos(self, cx, cy, charImg, updateHeights = False):
        charImg.setX(cx)
        charImg.setY(cy)
        if updateHeights:
            self.__updateHeights(cx, cy, charImg)

    def __updateHeights(self, cx, cy, charImg):
        left    = cx
        right   = cx + charImg.getWidth() + 1
        y       = cy + charImg.getHeight() + 1
        newUsedHeight = UsedHeight(left, right, y)
        if len(self.__heights) == 0:
            self.__heights.append(newUsedHeight)
        else:
            newHeights = []
            for usedHeight in self.__heights:
                if usedHeight.right < left or usedHeight.left > right:
                    newHeights.append(usedHeight)
                else:
                    if usedHeight.y < cy:
                        hole = Hole(max(usedHeight.left, left), min(usedHeight.right, right), usedHeight.y, cy)
                        self.__holes.append(hole)
                    if usedHeight.left <= left or usedHeight.right >= right:
                        if usedHeight.y == y:
                            if usedHeight.right < right:
                                usedHeight.right = right
                                newHeights.append(usedHeight)
                                newUsedHeight = None
                            else:
                                newHeights[len(newHeights) - 1].right = usedHeight.right
                        else:
                            if usedHeight.left < left:
                                leftHeigth = usedHeight.clone()
                                leftHeigth.right = left
                                newHeights.append(leftHeigth)
                            if newUsedHeight:
                                newHeights.append(newUsedHeight)
                                newUsedHeight = None
                            if usedHeight.right > right:
                                usedHeight.left = right
                                newHeights.append(usedHeight)
            self.__heights = newHeights

    def __saveFntFile(self):
        self.__lstCharImg.sort(sortByCharCode)
        content = 'info face="Arial" size=32 bold=0 italic=0 charset="" unicode=1 stretchH=100 smooth=1 aa=1 padding=0,0,0,0 spacing=1,1 outline=0\n'
        content += 'common lineHeight=%d base=26 scaleW=%d scaleH=%d pages=1 packed=0 alphaChnl=1 redChnl=0 greenChnl=0 blueChnl=0\n' % (CharImage.getLineHeight(), self.__width, self.__height)
        content += 'page id=0 file="%s.png"\n' % self.__fileName
        content += 'chars count=%d\n' % len(self.__lstCharImg)
        strCharLine = 'char id={:<4d} x={:<5d} y={:<5d} width={:<5d} height={:<5d} xoffset={:<5d} yoffset={:<5d} xadvance={:<5d} page=0  chnl=15\n'
        for charImg in self.__lstCharImg:
            content += strCharLine.format(charImg.charCode, charImg.getX(), charImg.getY(), charImg.getWidth(), charImg.getHeight(), 0, charImg.getYoffset(), charImg.getXadvance())
        if self.__hasSpace:
            content += strCharLine.format(32, 0, 0, 0, 0, self.__lstCharImg[0].getWidth(), 0, self.__lstCharImg[0].getWidth())
        saveFile(self.__outDir + self.__fileName + '.fnt', content)

########################################################################################
## 切图相关
########################################################################################
def isOpaque(color):
    return color[3] > 0

def hCheck(img_array, y, x1, x2):
    for x in range(x1, x2):
        if isOpaque(img_array[x, y]):
            return True
    return False

def vCheck(img_array, x, y1, y2):
    for y in range(y1, y2):
        if isOpaque(img_array[x, y]):
            return True
    return False

class ImageMgr:
    def __init__(self, filePath, lstCode):
        self.__filePath = filePath
        self.__lstCode  = lstCode

    def clipAllChars(self):
        self.lstImages = []
        img = Image.open(self.__filePath)
        width, height = img.size
        if img.mode != "RGBA":
            img = img.convert("RGBA")
        img_array = img.load()
        index = 0
        startX = 0
        endX = 0
        while (startX < width):
            if vCheck(img_array, startX, 0, height):
                charCode    = self.__lstCode[index]
                endX        = startX + 1
                while (endX < width):
                    if not vCheck(img_array, endX, 0, height):
                        break
                    endX += 1
                if charCode in DOUBLE_CHARS:
                    while (endX < width):
                        if vCheck(img_array, endX, 0, height):
                            break
                        endX += 1
                    while (endX < width):
                        if not vCheck(img_array, endX, 0, height):
                            break
                        endX += 1
                for top in range(0, height):
                    if hCheck(img_array, top, startX, endX):
                        break
                for bottom in xrange(height - 1, top, -1):
                    if hCheck(img_array, bottom, startX, endX):
                        break
                bottom += 1
                rect    = (startX, top, endX, bottom)
                charImg = CharImage(img, rect, charCode)
                self.lstImages.append(charImg)
                index += 1
                startX = endX
            startX += 1

########################################################################################
## 界面相关
########################################################################################
class ToolWindow(Tk):
    def __init__(self, filePath):
        Tk.__init__(self)
        self.__createWindow()
        self.__setFilePath(filePath)

    def __createWindow(self):
        self.title("fnt字体制作工具")
        self.resizable(width=False, height=False)
        self.__createInputFrame()
        self.__createCheckButtonFrame()
        self.__createButtons()

    def __createInputFrame(self):
        frm = Frame(self)
        self.__createOpenFileInput(frm)
        self.__createCharsInput(frm)
        self.__createPaddingInput(frm)
        frm.pack()

    def __setFilePath(self, filename):
        if len(filename) > 0:
            self.__varPath.set(filename)
            txtFileName = filename[:-3] + "txt"
            if os.path.isfile(txtFileName):
                self.__varChars.set(readFile(txtFileName))

    def __createOpenFileInput(self, parent):
        Label(parent, text="选择png文件：").grid(row=0, column=0, padx=10, sticky=E)
        self.__varPath = StringVar()
        Entry(parent, textvariable=self.__varPath, state=DISABLED).grid(row=0, column=1, sticky=W)
        def openFile():
            filename = tkFileDialog.askopenfilename(filetypes=[("all files", "*.png")])
            if filename:
                self.__setFilePath(filename)
        Button(parent, text="浏览", command=openFile).grid(row=0, column=2, padx=10, ipadx=10)

    def __createCharsInput(self, parent):
        self.__varChars = StringVar()
        Label(parent, text="输入png中对应的字符：").grid(row=1, column=0, padx=10, sticky=E)
        Entry(parent, textvariable=self.__varChars).grid(row=1, column=1, sticky=W)

    def __createPaddingInput(self, parent):
        Label(parent, text="设置字体间距(px)：").grid(row=2, column=0, padx=10, sticky=E)
        def isOkay(content):
            return content == "" or len(content) < 4 and content.isdigit() and content[0] != '0'
        okayCommand = parent.register(isOkay)
        self.__varPadding = Spinbox(parent, from_=1, to=100, validate="key", vcmd=(okayCommand, '%P'))
        self.__varPadding.grid(row=2, column=1, sticky=W)

    def __createCheckButtonFrame(self):
        frm = Frame(self)
        self.__varHasSpace      = BooleanVar()
        self.__varIsAequilate   = BooleanVar()
        Checkbutton(frm, text="有空格", variable=self.__varHasSpace).grid(row=0, column=0, ipadx=10)
        Checkbutton(frm, text="数字等框", variable=self.__varIsAequilate).grid(row=0, column=1, ipadx=10)
        frm.pack()

    def __createButtons(self):
        def onConfirm():
            if self.__varPath.get() == "":
                tkMessageBox.showwarning("警告", "请选择png文件！")
                return
            if self.__varChars.get() == "" or self.__varChars.get().isspace():
                tkMessageBox.showwarning("警告", "请输入png中对应的字符！")
                return
            CharImage.config(self.__varIsAequilate.get(), int(self.__varPadding.get()))
            filePath = self.__varPath.get()
            self.__createOutDir(filePath)
            mgr = ImageMgr(filePath, self.__getCharCodeList())
            mgr.clipAllChars()
            FontPage(mgr.lstImages, self.__outDir, self.__fileName, self.__varHasSpace.get())
            self.destroy()
        frm = Frame(self)
        Button(frm, text="确认", command=onConfirm).pack(side=LEFT, padx=10, ipadx=10)
        Button(frm, text="取消", command=self.destroy).pack(side=RIGHT, padx=10, ipadx=10)
        frm.pack()

    def __createOutDir(self, filePath):
        self.__fileName = os.path.basename(filePath).split('.')[0]
        self.__outDir   = os.path.dirname(filePath) + '\\' + self.__fileName + '\\'
        if not os.path.exists(self.__outDir):
            os.mkdir(self.__outDir)

    def __getCharCodeList(self):
        strChars = self.__varChars.get()
        lstCode = []
        for i in range(len(strChars)):
            if strChars[i] != " ":
                lstCode.append(ord(strChars[i]))
        return lstCode

########################################################################################
## main函数
########################################################################################
def main():
    filePath = len(sys.argv) > 1 and sys.argv[1] or ""
    wnd = ToolWindow(filePath)
    wnd.mainloop()

if __name__ == "__main__":
    main()
