using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace FontTool {
	class FontGen {
		private string pngFileName;
		private string doubleChars = "";
		private string fileName;
		private string outDir;
		private List<char> lstCharCode = new List<char>();
		private List<CharImage> lstCharImage = new List<CharImage>();
		private List<FontChar> lstFontChar = new List<FontChar>();

		public FontGen(string fileName) {
			ResetFileName(fileName);
		}

		public void ResetFileName(string fileName) {
			pngFileName = fileName;
			CreateOutDir();
			ClipAllChars();
			CreateSidesEmpty();
		}

		private void CreateOutDir() {
			fileName = Path.GetFileNameWithoutExtension(pngFileName);
			string dirName = Path.GetDirectoryName(pngFileName);
			outDir = Path.Combine(dirName, fileName);
			Directory.CreateDirectory(outDir);
		}

		private void ClipAllChars() {
			CharImage.Init();
			lstCharImage.Clear();
			Bitmap img = new Bitmap(pngFileName);
			int startX = 0;
			int endX = 0;
			while (startX < img.Width) {
				if (CheckV(img, startX, 0, img.Height)) {
					endX = startX + 1;
					while (endX < img.Width) {
						if (!CheckV(img, endX, 0, img.Height)) {
							break;
						}
						endX++;
					}
					int top = 0;
					for (; top < img.Height; top++) {
						if (CheckH(img, top, startX, endX)) {
							break;
						}
					}
					int bottom = img.Height - 1;
					for (; bottom > top; bottom--) {
						if (CheckH(img, bottom, startX, endX)) {
							break;
						}
					}
					bottom++;
					Rectangle rect = new Rectangle(startX, top, endX - startX, bottom - top);
					CharImage charImg = new CharImage(img, rect);
					lstCharImage.Add(charImg);
					startX = endX;
				}
				startX++;
			}
		}

		private bool CheckV(Bitmap img, int x, int y1, int y2) {
			for (int y = y1; y < y2; y++) {
				if (IsOpaque(img.GetPixel(x, y))) {
					return true;
				}
			}
			return false;
		}

		private bool CheckH(Bitmap img, int y, int x1, int x2) {
			for (int x = x1; x < x2; x++) {
				if (IsOpaque(img.GetPixel(x, y))) {
					return true;
				}
			}
			return false;
		}

		private bool IsOpaque(Color color) {
			return color.A > 0;
		}

		private void CreateSidesEmpty() {
			for (int i = 0; i < lstCharImage.Count; i++) {
				lstCharImage[i].GenSidesEmpty();
			}
		}

		public void SetChars(string chars) {
			GenCharCodes(chars);
			GenFontChars();
		}

		private void GenCharCodes(string strChars) {
			lstCharCode.Clear();
			char[] tmp = strChars.ToCharArray();
			for (int i = 0; i < tmp.Length; i++) {
				if (tmp[i] != ' ') {
					lstCharCode.Add(tmp[i]);
				}
			}
		}

		public void SetDoubleChars(string chars) {
			doubleChars = chars;
			GenFontChars();
		}

		private void GenFontChars() {
			lstFontChar.Clear();
			for (int i = 0, j = 0; i < lstCharCode.Count && j < lstCharImage.Count; i++, j++) {
				char charId = lstCharCode[i];
				CharImage imgA = lstCharImage[j];
				CharImage imgB = null;
				if (doubleChars.IndexOf(charId) >= 0) {
					imgB = lstCharImage[++j];
				}
				lstFontChar.Add(new FontChar(charId, imgA, imgB));
			}
		}

		public void GenKerningPairs() {
			foreach (FontChar charImg in lstFontChar) {
				foreach (FontChar char2Img in lstFontChar) {
					charImg.GenKerningPair(char2Img);
				}
			}
		}

		public int? GetKerningPairAmount(char[] chars) {
			FontChar fontCharA = GetCharImg(chars[0]);
			FontChar fontCharB = GetCharImg(chars[1]);
			if (fontCharA == null || fontCharB == null) {
				return null;
			}
			return fontCharA.GetNextCharOffsetX(fontCharB.CharCode);
		}

		public void SetKerningPair(char[] chars, short amount) {
			FontChar fontChar = GetCharImg(chars[0]);
			fontChar.SetKerningPair(chars[1], amount);
		}

		public FontChar GetCharImg(char code) {
			foreach (FontChar charImg in lstFontChar) {
				if (charImg.CharCode == code) {
					return charImg;
				}
			}
			return null;
		}

		public void CreateFnt() {
			FontPage page = new FontPage(lstFontChar, outDir, fileName);
			page.CreateFontPage();
		}
	}
}
