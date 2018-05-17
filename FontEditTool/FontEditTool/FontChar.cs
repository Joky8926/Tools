using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace FontEditTool {
	class FontChar {
		private BMFontDef fontDef;
		private Bitmap _image;
		private SortedDictionary<char, BMFontKerningDef> dictKerning = new SortedDictionary<char, BMFontKerningDef>();

		public FontChar(Bitmap img, BMFontDef fontDef) {
			this.fontDef = fontDef;
			if (fontDef.Rect.Width > 0 && fontDef.Rect.Height > 0) {
				_image = img.Clone(fontDef.Rect, PixelFormat.Format32bppArgb);
			}
		}

		public void InitKerning(BMFontKerningDef fontKerning) {
			dictKerning[fontKerning.CharB] = fontKerning;
		}

		public short GetNextCharOffsetX(char nextChar) {
			if (dictKerning.ContainsKey(nextChar)) {
				return dictKerning[nextChar].Amount;
			}
			return 0;
		}

		public void SetKerningPair(char nextChar, short amount) {
			if (dictKerning.ContainsKey(nextChar)) {
				dictKerning[nextChar].Amount = amount;
			} else {
				dictKerning[nextChar] = new BMFontKerningDef(CharId, nextChar, amount);
			}
		}

		public string GetCharLine() {
			return fontDef.ToString();
		}

		public List<string> GetKerningLines() {
			List<string> lines = new List<string>();
			foreach (BMFontKerningDef fontKerning in dictKerning.Values) {
				if (fontKerning.Amount != 0) {
					lines.Add(fontKerning.ToString());
				}
			}
			return lines;
		}

		public char CharId {
			get {
				return fontDef.CharId;
			}
		}

		public Bitmap Image {
			get {
				return _image;
			}
		}

		public int OffsetX {
			get {
				return fontDef.OffsetX;
			}
		}

		public int OffsetY {
			get {
				return fontDef.OffsetY;
			}
		}

		public short AdvanceX {
			get {
				return fontDef.AdvanceX;
			}
		}
		
		public short Width {
			set {
				if (CharId != BMFontDef.CHAR_SPACE) {
					return;
				}
				fontDef.OffsetX = value;
				fontDef.AdvanceX = value;
			}
		}
	}
}
