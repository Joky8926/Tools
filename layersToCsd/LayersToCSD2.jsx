
const settingsID = app.stringIDToTypeID("LayersToCSD2:settings");
const eCtype = {
    "project"   :"GameProjectContent",
    "node"      :"GameNodeObjectData",
    "singleNode":"SingleNodeObjectData",
    "layer"     :"GameLayerObjectData",
    "sprite"    :"SpriteObjectData",
    "button"    :"ButtonObjectData"
};

var dictSettings = {
    "writeTemplate"     :false,
    "writeCsd"          :true,
    "ignoreHiddenLayers":true,
    "exportPrefix"      :"out_",
    "btnPrefix"         :"btn_",
    "btnNSuffix"        :"_n",
    "btnPSuffix"        :"_p",
    "btnDSuffix"        :"_d"
};

var padding         = 1;
var stringOptions   = ["Scene", "Layer", "Node"];
var arrDataTypes    = [eCtype.node, eCtype.layer, eCtype.node];
var typeText        = stringOptions[0];
var dataType        = arrDataTypes[0];
var tagIndex        = 100;
var relImagesDir    = "images";
var originalDoc;
var historyIndex;
var absImagesDir;
var csdPath;

function hasFilePath() {
    var ref = new ActionReference();
    ref.putEnumerated(app.charIDToTypeID("Dcmn"), app.charIDToTypeID("Ordn"), app.charIDToTypeID("Trgt"));
    return app.executeActionGet(ref).hasKey(app.stringIDToTypeID("fileReference"));
}

function initPath() {
    var name        = decodeURI(originalDoc.name);
    name            = name.substring(0, name.indexOf("."));
    var outDir      = app.activeDocument.path.toString() + "/outputs_" + name + "/";
    csdPath         = outDir + name + ".csd";
    var folder      = new Folder(outDir + relImagesDir);
    if (folder.exists && !folder.remove()) {
        var newName
        for (var i = 1; i < 100; i++) {
            newName = relImagesDir + "_" + i;
            folder  = new Folder(outDir + newName);
            if (!folder.exists || folder.remove()) {
                relImagesDir = newName;
                break;
            }
        }
    }
    relImagesDir = relImagesDir + "/";
    absImagesDir = outDir + relImagesDir;
    Folder(absImagesDir).create();
}

function saveSettings() {
    var settings = new ActionDescriptor();
    for (var key in dictSettings) {
        var typeId  = app.stringIDToTypeID(key);
        var value   = dictSettings[key];
        switch (typeof value) {
            case "boolean":
                settings.putBoolean(typeId, value);
                break;
            case "string":
                settings.putString(typeId, value);
                break;
        }
    }
    app.putCustomOptions(settingsID, settings, true);
}

function loadSettings() {
    try {
        var settings = app.getCustomOptions(settingsID);
        for (var key in dictSettings) {
            var typeId = app.stringIDToTypeID(key);
            if (!settings.hasKey(typeId)) {
                continue;
            }
            switch (typeof dictSettings[key]) {
                case "boolean":
                    dictSettings[key] = settings.getBoolean(typeId);
                    break;
                case "string":
                    dictSettings[key] = settings.getString(typeId);
                    break;
            }
        }
    } catch (e) {
        saveSettings();
    }
}

function checkPrefix(layer, prefix) {
    if (layer.name.substr(0, prefix.length) == prefix) {
        layer.name = layer.name.substring(prefix.length);
        return true;
    }
    return false;
}

function checkSuffix(layer, suffix) {
    return layer.name.substring(layer.name.length - suffix.length) == suffix;
}

function collectGroup(group) {
    if (checkPrefix(group, dictSettings.exportPrefix)) {
        group.visible = false;
        return group;
    } else if (checkPrefix(group, dictSettings.btnPrefix)) {
        group.name      = "btn_" + group.name;
        group.ctype     = eCtype.button;
        group.visible   = false;
        return group;
    } else{
        var children = collectLayers(group);
        children.name = group.name;
        return children;
    }
}

function collectLayers(layer) {
    var collect = [];
    for (var i = layer.layers.length - 1; i >= 0; i--) {
        var child = layer.layers[i];
        if (dictSettings.ignoreHiddenLayers && !child.visible) {
            continue;
        }
        if (child.bounds[2] == 0 && child.bounds[3] == 0) {
            continue;
        }
        if (child.layers && child.layers.length > 0) {
            collect.push(collectGroup(child));
        } else {
            collect.push(child);
            child.visible = false;
        }
    }
    return collect;
}

function storeHistory() {
    historyIndex = app.activeDocument.historyStates.length - 1;
}

function guid() {
    function s4() {
        return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
}

function restoreHistory() {
    app.activeDocument.activeHistoryState = app.activeDocument.historyStates[historyIndex];
}

function tenNum() {
    return '1' + Math.floor((Math.random() * 9 + 1) * 0x10000000).toString(10).substring(1);
}

function createNode(xmlParent, name) {
    tagIndex += 1;
    xmlParent.appendChild(<AbstractNodeData Name={name} ActionTag={tenNum()} Tag={tagIndex} IconVisible="True" ctype={eCtype.singleNode + ""}/>);
    var node = xmlParent.AbstractNodeData[xmlParent.AbstractNodeData.length() - 1];
    node.appendChild(<Size X="0.0000" Y="0.0000"/>);
    node.appendChild(<Children/>);
    node.appendChild(<AnchorPoint/>);
    node.appendChild(<Position/>);
    node.appendChild(<Scale ScaleX="1.0000" ScaleY="1.0000"/>);
    node.appendChild(<CColor A="255" R="255" G="255" B="255"/>);
    node.appendChild(<PrePosition/>);
    node.appendChild(<PreSize X="0.0000" Y="0.0000"/>);
    return node.Children;
}

function getEncodeName(layer) {
    return layer.name.replace(/^\s+|\s+$|[:\/\\*\?\"\<\>\|\$]/g, "");
}

function showButtonAllState(layer) {
    var collect = {};
    if (!layer.layers || layer.layers.length == 0) {
        collect.normal = layer;
        return collect;
    }
    var tmp = {};
    for (var i = 0; i < layer.layers.length; i++) {
        var child = layer.layers[i];
        var dict = child.visible ? collect : tmp;
        if (child.bounds[2] == 0 && child.bounds[3] == 0) {
            continue;
        }
        if (checkSuffix(child, dictSettings.btnNSuffix)) {
            dict.normal = child;
        } else if (checkSuffix(child, dictSettings.btnPSuffix)) {
            dict.pressed = child;
        } else if (checkSuffix(child, dictSettings.btnDSuffix)) {
            dict.disabled = child;
        }
        child.visible = false;
    }
    for (var key in tmp) {
        if (!collect[key]) {
            collect[key] = tmp[key];
        }
    }
    return collect;
}

function savePng(filename) {
    var pngSaveOptions      = new ExportOptionsSaveForWeb();
    pngSaveOptions.format   = SaveDocumentType.PNG;
    pngSaveOptions.PNG8     = false;
    app.activeDocument.exportDocument(new File(filename + ".png"), ExportType.SAVEFORWEB, pngSaveOptions);
}

function createBtnImage(layer, xmlParent, xmlKeyName) {
    layer.visible = true;
    var imageName = getEncodeName(layer);
    savePng(absImagesDir + imageName);
    xmlParent.appendChild(<{xmlKeyName} Type="Normal" Path={relImagesDir + imageName + ".png"} Plist=""/>);
    layer.visible = false;
}

function createButton(xmlParent, layer) {
    var buttonName = getEncodeName(layer);
    var x = app.activeDocument.width.as("px");
    var y = app.activeDocument.height.as("px");
    layer.visible = true;
    var dicBtnStates = showButtonAllState(layer);
    for (var key in dicBtnStates) {
        dicBtnStates[key].visible = true;
    }
    if (!layer.isBackgroundLayer) {
        app.activeDocument.trim(TrimType.TRANSPARENT, false, true, true, false);
    }
    x -= app.activeDocument.width.as("px");
    y -= app.activeDocument.height.as("px");
    if (!layer.isBackgroundLayer) {
        app.activeDocument.trim(TrimType.TRANSPARENT, true, false, false, true);
    }
    var width   = app.activeDocument.width.as("px") + padding * 2;
    var height  = app.activeDocument.height.as("px") + padding * 2;
    if (padding > 0) {
        app.activeDocument.resizeCanvas(width, height, AnchorPosition.MIDDLECENTER);
    }
    for (var key in dicBtnStates) {
        dicBtnStates[key].visible = false;
    }

    x += width / 2;
    y += height / 2;
    var eageX = 15;
    var eageY = 11;
    if (width / 3 < eageX) {
        eageX = parseInt(width / 3);
    }
    if (height / 3 < eageY) {
        eageY = parseInt(height / 3);
    }

    tagIndex += 1;
    xmlParent.appendChild(<AbstractNodeData Name={buttonName} ActionTag={tenNum()} Tag={tagIndex} IconVisible="False" TouchEnable="True" FontSize="14" LeftEage={eageX} RightEage={eageX} TopEage={eageY} BottomEage={eageY} Scale9OriginX={eageX} Scale9OriginY={eageY} Scale9Width={width - eageX * 2} Scale9Height={height - eageY * 2} ShadowOffsetX="2.0000" ShadowOffsetY="-2.0000" ctype={eCtype.button + ""}/>);
    var node = xmlParent.AbstractNodeData[xmlParent.AbstractNodeData.length() - 1];
    node.appendChild(<Size X={width} Y={height + ""}/>);
    node.appendChild(<AnchorPoint ScaleX="0.5000" ScaleY="0.5000"/>);
    node.appendChild(<Position X={x} Y={y + ""}/>);
    node.appendChild(<Scale ScaleX="1.0000" ScaleY="1.0000"/>);
    node.appendChild(<CColor A="255" R="255" G="255" B="255"/>);
    node.appendChild(<PrePosition X="0.0000" Y="0.0000"/>);
    node.appendChild(<PreSize X="0.0000" Y="0.0000"/>);
    node.appendChild(<TextColor A="255" R="0" G="0" B="0"/>);
    if (dicBtnStates.disabled) {
        createBtnImage(dicBtnStates.disabled, node, "DisabledFileData");
    }
    if (dicBtnStates.pressed) {
        createBtnImage(dicBtnStates.pressed, node, "PressedFileData");
    }
    if (dicBtnStates.normal) {
        createBtnImage(dicBtnStates.normal, node, "NormalFileData");
    }
    node.appendChild(<OutlineColor A="255" R="255" G="0" B="0"/>);
    node.appendChild(<ShadowColor A="255" R="110" G="110" B="110"/>);
    restoreHistory();
    layer.visible = false;
}

function createSprite(xmlParent, layer) {
    var imageName = getEncodeName(layer);
    var x = app.activeDocument.width.as("px");
    var y = app.activeDocument.height.as("px");
    layer.visible = true;
    if (!layer.isBackgroundLayer) {
        app.activeDocument.trim(TrimType.TRANSPARENT, false, true, true, false);
    }
    x -= app.activeDocument.width.as("px");
    y -= app.activeDocument.height.as("px");
    if (!layer.isBackgroundLayer) {
        app.activeDocument.trim(TrimType.TRANSPARENT, true, false, false, true);
    }
    var width   = app.activeDocument.width.as("px") + padding * 2;
    var height  = app.activeDocument.height.as("px") + padding * 2;

    // Save image.
    if (padding > 0) {
        app.activeDocument.resizeCanvas(width, height, AnchorPosition.MIDDLECENTER);
    }
    savePng(absImagesDir + imageName);

    x += width / 2;
    y += height / 2;

    tagIndex += 1;
    xmlParent.appendChild(<AbstractNodeData Name={imageName} ActionTag={tenNum()} Tag={tagIndex} IconVisible="False" ctype={eCtype.sprite + ""}/>);
    var node = xmlParent.AbstractNodeData[xmlParent.AbstractNodeData.length() - 1];
    node.appendChild(<Size X={width} Y={height + ""}/>);
    node.appendChild(<AnchorPoint ScaleX="0.5000" ScaleY="0.5000"/>);
    node.appendChild(<Position X={x} Y={y + ""}/>);
    node.appendChild(<Scale ScaleX="1.0000" ScaleY="1.0000"/>);
    node.appendChild(<CColor A="255" R="255" G="255" B="255"/>);
    node.appendChild(<PrePosition X="0.0000" Y="0.0000"/>);
    node.appendChild(<PreSize X="0.0000" Y="0.0000"/>);
    node.appendChild(<FileData Type="Normal" Path={relImagesDir + imageName + ".png"} Plist=""/>);
    node.appendChild(<BlendFunc Src="1" Dst="771"/>);
    restoreHistory();
    layer.visible = false;
}

function createLayers(parent, collect) {
    for (var i = 0; i < collect.length; i++) {
        var child = collect[i];
        if (child.length && child.length > 0) {
            var node = createNode(parent, child.name);
            createLayers(node, child);
        } else if (child.ctype == eCtype.button) {
            createButton(parent, child);
        } else {
            createSprite(parent, child);
        }
    }
}

function run() {
    app.activeDocument.duplicate();

    // Output template image.
    if (dictSettings.writeTemplate) {
        var file = new File(absImagesDir + "template");
        if (file.exists) {
            file.remove();
        }
        app.activeDocument.saveAs(file, new PNGSaveOptions(), true, Extension.LOWERCASE);
    }

    // Rasterize all layers.
    try {
        app.executeAction(app.stringIDToTypeID("rasterizeAll"), undefined, DialogModes.NO);
    } catch (ignored) {

    }

    var docName     = decodeURI(originalDoc.name);
    docName         = docName.substring(0, docName.indexOf("."));
    var docWidth    = app.activeDocument.width.as("px");
    var docHeight   = app.activeDocument.height.as("px");

    // Output images and csd.
    var xml = new XML(<GameFile/>);
    xml.appendChild(<PropertyGroup Name={docName} Type={typeText} ID={guid()} Version="3.10.0.0"/>);
    xml.appendChild(<Content ctype={eCtype.project + ""}/>);
    xml.Content.appendChild(<Content/>);
    xml.Content.Content.appendChild(<Animation Duration="0" Speed="1.0000"/>);
    xml.Content.Content.appendChild(<ObjectData Name={typeText} Tag={tagIndex} ctype={dataType + ""}/>);
    xml.Content.Content.ObjectData.appendChild(<Size X={docWidth} Y={docHeight + ""}/>);
    xml.Content.Content.ObjectData.appendChild(<Children/>);

    // Collect and hide layers.
    var layers = collectLayers(app.activeDocument);
    storeHistory();
    createLayers(xml.Content.Content.ObjectData.Children, layers);

    app.activeDocument.close(SaveOptions.DONOTSAVECHANGES);

    if (dictSettings.writeCsd) {
        var file = new File(csdPath);
        file.remove();
        file.open("w", "TEXT");
        file.lineFeed = "\n";
        file.write(xml.toXMLString());
        file.close();
    }
}

function createEditText(parent, label, text) {
    var group = parent.add("group");
    group.add("statictext", undefined, label);
    var edittext = group.add("edittext", undefined, text);
    edittext.characters = 10;
    return edittext;
}

function showDialog() {
    var dialog = new Window("dialog", "csd转化工具");
    dialog.alignChildren = "fill";

    var checkboxGroup = dialog.add("group");
    checkboxGroup.orientation   = "column";
    checkboxGroup.alignChildren = "left";
    var writeTemplateCheckbox       = checkboxGroup.add("checkbox", undefined, "生成参考图");
    var writeJsonCheckbox           = checkboxGroup.add("checkbox", undefined, "导出csd");
    var ignoreHiddenLayersCheckbox  = checkboxGroup.add("checkbox", undefined, "忽略隐藏的图层");
    writeTemplateCheckbox.value         = dictSettings.writeTemplate;
    writeJsonCheckbox.value             = dictSettings.writeCsd;
    ignoreHiddenLayersCheckbox.value    = dictSettings.ignoreHiddenLayers;

    var selGroup = dialog.add("group");
    selGroup.add("statictext", undefined, "类型:");
    var typeSel = selGroup.add("dropdownlist", undefined, "");
    for (var i = 0, len = stringOptions.length; i < len; i++) {
        typeSel.add("item", stringOptions[i]);
    };
    typeSel.selection = typeSel.items[0];

    typeSel.onChange = function() {
        typeText = stringOptions[parseInt(this.selection)];
        dataType = arrDataTypes[parseInt(this.selection)];
    };

    var textGroup = dialog.add("group");
    textGroup.orientation   = "column";
    textGroup.alignChildren = "right";
    var exportPrefixText    = createEditText(textGroup, "导出组前缀:", dictSettings.exportPrefix);
    var btnPrefixText       = createEditText(textGroup, "按钮组前缀:", dictSettings.btnPrefix);
    var btnNSuffixText      = createEditText(textGroup, "按钮默认后缀:", dictSettings.btnNSuffix);
    var btnPSuffixText      = createEditText(textGroup, "按钮按下后缀:", dictSettings.btnPSuffix);
    var btnDSuffixText      = createEditText(textGroup, "按钮不可用后缀", dictSettings.btnDSuffix);

    var group = dialog.add("group");
        group.alignment = "center";
        var runButton = group.add("button", undefined, "确定");
        var cancelButton = group.add("button", undefined, "取消");
        cancelButton.onClick = function () {
            dialog.close(0);
        };

    function updateSettings() {
        dictSettings.writeTemplate      = writeTemplateCheckbox.value;
        dictSettings.writeCsd           = writeJsonCheckbox.value;
        dictSettings.ignoreHiddenLayers = ignoreHiddenLayersCheckbox.value;
        dictSettings.exportPrefix       = exportPrefixText.text;
        dictSettings.btnPrefix          = btnPrefixText.text;
        dictSettings.btnNSuffix         = btnNSuffixText.text;
        dictSettings.btnPSuffix         = btnPSuffixText.text;
        dictSettings.btnDSuffix         = btnDSuffixText.text;
    }

    dialog.onClose = function () {
        updateSettings();
        saveSettings();
    };

    runButton.onClick = function () {
        dialog.close(0);
        var rulerUnits = app.preferences.rulerUnits;
        app.preferences.rulerUnits = Units.PIXELS;
        try {
            run();
            alert("脚本执行完成！");
        } catch (e) {
            alert("脚本运行异常！请保护现场，联系程序员解决问题！");
            alert(e.message);
        } finally {
            if (app.activeDocument != originalDoc) {
                app.activeDocument.close(SaveOptions.DONOTSAVECHANGES);
            }
            app.preferences.rulerUnits = rulerUnits;
        }
    };

    dialog.center();
    dialog.show();
}

function main() {
    try {
        originalDoc = app.activeDocument;
    } catch (ignored) {
        alert("请先打开一个psd文件！");
        return;
    }
    if (!hasFilePath()) {
        alert("你的psd文件还没保存过，请先保存一下！");
        return;
    }
    initPath();
    loadSettings();
    showDialog();
}

main();
