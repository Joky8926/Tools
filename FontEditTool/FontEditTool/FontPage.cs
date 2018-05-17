using System.Collections.Generic;
using System.Drawing;

namespace FontEditTool {
	class FontPage {
		private const string KERNINGS_TEMPLATE = "\r\nkernings count={0}\r\n";
		private string pngFile;
		private SortedDictionary<char, FontChar> dictFontChar = new SortedDictionary<char, FontChar>();

		public FontPage(string pngFile, List<BMFontDef> lstFontDef, List<BMFontKerningDef> lstKerning) {
			this.pngFile = pngFile;
			LoadImage(lstFontDef);
			InitKerning(lstKerning);
		}

		private void LoadImage(List<BMFontDef> lstFontDef) {
			Bitmap img = new Bitmap(pngFile);
			foreach (BMFontDef fontDef in lstFontDef) {
				FontChar charImg = new FontChar(img, fontDef);
				dictFontChar[charImg.CharId] = charImg;
			}
		}

		private void InitKerning(List<BMFontKerningDef> lstKerning) {
			foreach (BMFontKerningDef fontKerning in lstKerning) {
				dictFontChar[fontKerning.CharA].InitKerning(fontKerning);
			}
		}

		public FontChar GetCharImg(char code) {
			if (dictFontChar.ContainsKey(code)) {
				return dictFontChar[code];
			}
			return null;
		}

		public int? GetKerningPairAmount(char charA, char charB) {
			if (dictFontChar.ContainsKey(charA)) {
				return dictFontChar[charA].GetNextCharOffsetX(charB);
			}
			return null;
		}

		public void SetKerningPair(char charA, char charB, short amount) {
			dictFontChar[charA].SetKerningPair(charB, amount);
		}

		public string GetContent() {
			string content = "";
			string kerningContent = "";
			int kerningCount = 0;
			List<string> lstTmp;
			foreach (FontChar charImg in dictFontChar.Values) {
				content += charImg.GetCharLine();
				lstTmp = charImg.GetKerningLines();
				kerningCount += lstTmp.Count;
				for (int i = 0; i < lstTmp.Count; i++) {
					kerningContent += lstTmp[i];
				}
			}
			if (kerningCount > 0) {
				content += string.Format(KERNINGS_TEMPLATE, kerningCount) + kerningContent;
			}
			return content;
		}

		public short SpaceWidth {
			get {
				if (dictFontChar.ContainsKey(BMFontDef.CHAR_SPACE)) {
					return dictFontChar[BMFontDef.CHAR_SPACE].AdvanceX;
				}
				return 0;
			}
			set {
				if (dictFontChar.ContainsKey(BMFontDef.CHAR_SPACE)) {
					dictFontChar[BMFontDef.CHAR_SPACE].Width = value;
				} else {
					dictFontChar[BMFontDef.CHAR_SPACE] = new FontChar(null, new BMFontDef(value));
				}
			}
		}
	}
}
