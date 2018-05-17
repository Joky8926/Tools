using System;
using System.Collections.Generic;
using System.Drawing;

namespace FontTool {
	class FontChar {
		public const char CHAR_SPACE = ' ';
		public const char CHAR_NEWLINE = '\n';
		private static string[] KERNING_PAIRS = {"A'", "AC", "AG", "AO", "AQ", "AT", "AU", "AV", "AW", "AY", "BA", "BE", "BL", "BP", "BR", "BU", "BV", "BW", "BY", "CA", "CO", "CR", "DA", "DD", "DE", "DI", "DL", "DM", "DN", "DO", "DP", "DR", "DU", "DV", "DW", "DY", "EC", "EO", "FA", "FC", "FG", "FO", "F.", "F,", "GE", "GO", "GR", "GU", "HO", "IC", "IG", "IO", "JA", "JO", "KO", "L'", "LC", "LT", "LV", "LW", "LY", "LG", "LO", "LU", "MG", "MO", "NC", "NG", "NO", "OA", "OB", "OD", "OE", "OF", "OH", "OI", "OK", "OL", "OM", "ON", "OP", "OR", "OT", "OU", "OV", "OW", "OX", "OY", "PA", "PE", "PL", "PO", "PP", "PU", "PY", "P.", "P,", "P;", "P:", "QU", "RC", "RG", "RY", "RT", "RU", "RV", "RW", "RY", "SI", "SM", "ST", "SU", "TA", "TC", "TO", "UA", "UC", "UG", "UO", "US", "VA", "VC", "VG", "VO", "VS", "WA", "WC", "WG", "WO", "YA", "YC", "YO", "YS", "ZO", "Ac", "Ad", "Ae", "Ag", "Ao", "Ap", "Aq", "At", "Au", "Av", "Aw", "Ay", "Bb", "Bi", "Bk", "Bl", "Br", "Bu", "By", "B.", "B,", "Ca", "Cr", "C.", "C,", "Da", "D.", "D,", "Eu", "Ev", "Fa", "Fe", "Fi", "Fo", "Fr", "Ft", "Fu", "Fy", "F.", "F,", "F;", "F:", "Gu", "He", "Ho", "Hu", "Hy", "Ic", "Id", "Iq", "Io", "It", "Ja", "Je", "Jo", "Ju", "J.", "J,", "Ke", "Ko", "Ku", "Lu", "Ly", "Ma", "Mc", "Md", "Me", "Mo", "Nu", "Na", "Ne", "Ni", "No", "Nu", "N.", "N,", "Oa", "Ob", "Oh", "Ok", "Ol", "O.", "O,", "Pa", "Pe", "Po", "Rd", "Re", "Ro", "Rt", "Ru", "Si", "Sp", "Su", "S.", "S,", "Ta", "Tc", "Te", "Ti", "To", "Tr", "Ts", "Tu", "Tw", "Ty", "T.", "T,", "T;", "T:", "Ua", "Ug", "Um", "Un", "Up", "Us", "U.", "U,", "Va", "Ve", "Vi", "Vo", "Vr", "Vu", "V.", "V,", "V;", "V:", "Wd", "Wi", "Wm", "Wr", "Wt", "Wu", "Wy", "W.", "W,", "W;", "W:", "Xa", "Xe", "Xo", "Xu", "Xy", "Yd", "Ye", "Yi", "Yp", "Yu", "Yv", "Y.", "Y,", "Y;", "Y:", "ac", "ad", "ae", "ag", "ap", "af", "at", "au", "av", "aw", "ay", "ap", "bl", "br", "bu", "by", "b.", "b,", "ca", "ch", "ck", "da", "dc", "de", "dg", "do", "dt", "du", "dv", "dw", "dy", "d.", "d,", "ea", "ei", "el", "em", "en", "ep", "er", "et", "eu", "ev", "ew", "ey", "e.", "e,", "fa", "fe", "ff", "fi", "fl", "fo", "f.", "f,", "ga", "ge", "gh", "gl", "go", "gg", "g.", "g,", "hc", "hd", "he", "hg", "ho", "hp", "ht", "hu", "hv", "hw", "hy", "ic", "id", "ie", "ig", "io", "ip", "it", "iu", "iv", "ja", "je", "jo", "ju", "j.", "j,", "ka", "kc", "kd", "ke", "kg", "ko", "la", "lc", "ld", "le", "lf", "lg", "lo", "lp", "lq", "lu", "lv", "lw", "ly", "ma", "mc", "md", "me", "mg", "mn", "mo", "mp", "mt", "mu", "mv", "my", "nc", "nd", "ne", "ng", "no", "np", "nt", "nu", "nv", "nw", "ny", "ob", "of", "oh", "oj", "ok", "ol", "om", "on", "op", "or", "ou", "ov", "ow", "ox", "oy", "o.", "o,", "pa", "ph", "pi", "pl", "pp", "pu", "p.", "p,", "qu", "t.", "ra", "rd", "re", "rg", "rk", "rl", "rm", "rn", "ro", "rq", "rr", "rt", "rv", "ry", "r.", "r,", "sh", "st", "su", "s.", "s,", "td", "ta", "te", "to", "t.", "t,", "ua", "uc", "ud", "ue", "ug", "uo", "up", "uq", "ut", "uv", "uw", "uy", "va", "vb", "vc", "vd", "ve", "vg", "vo", "vv", "vy", "v.", "v,", "wa", "wx", "wd", "we", "wg", "wh", "wo", "w.", "w,", "xa", "xe", "xo", "y.", "y,", "ya", "yc", "yd", "ye", "yo"};
		private static bool numMonospace = false;
		private static bool isKerningPairs = false;
		private static int kerning;
		private static int maxNumberWidth = 0;
		private static int spaceWidth = 0;
		private static int lineHeight = 0;
		private CharImage charImage;
		private char _charCode;
		private bool isNum;
		private int _x = 0;
		private int _y = 0;
		private SortedDictionary<char, int> dictKerningPairs = new SortedDictionary<char, int>();
		
		public FontChar(char charCode, CharImage imgA, CharImage imgB) {
			_charCode = charCode;
			charImage = imgA.Union(imgB);
			isNum = charCode >= '0' && charCode <= '9';
			if (isNum && charImage.Width > maxNumberWidth) {
				maxNumberWidth = charImage.Width;
			}
		}
		
		public void GenKerningPair(FontChar char2) {
			string charsPair = new string(new char[] { _charCode, char2._charCode });
			if (Array.IndexOf(KERNING_PAIRS, charsPair) < 0) {
				return;
			}
			dictKerningPairs[char2._charCode] = charImage.CalOffset(char2.charImage);
		}

		public List<string> GetKerningPairsStr() {
			string template = "kerning first={0,-3} second={1,-3} amount={2}\r\n";
			List<string> lstStr = new List<string>();
			foreach (KeyValuePair<char, int> kvp in dictKerningPairs) {
				if (kvp.Value != 0) {
					lstStr.Add(string.Format(template, (int)_charCode, (int)kvp.Key, kvp.Value));
				}
			}
			return lstStr;
		}

		public int GetNextCharOffsetX(char nextChar) {
			if (isKerningPairs && dictKerningPairs.ContainsKey(nextChar)) {
				return dictKerningPairs[nextChar];
			}
			return 0;
		}

		public void SetKerningPair(char nextChar, short amount) {
			dictKerningPairs[nextChar] = amount;
		}

		public int Width {
			get {
				if (IsMonospace) {
					return maxNumberWidth;
				}
				return charImage.Width;
			}
		}

		public int Height {
			get {
				return charImage.Height;
			}
		}

		public int Acreage {
			get {
				return charImage.Acreage;
			}
		}

		public int X {
			get {
				return _x;
			}
			set {
				_x = value;
			}
		}

		public int Y {
			get {
				return _y;
			}
			set {
				_y = value;
			}
		}

		public int OffsetY {
			get {
				return charImage.OffsetY;
			}
		}

		public int OffsetX {
			get {
				if (IsMonospace) {
					return (maxNumberWidth - charImage.Width) / 2;
				}
				return 0;
			}
		}

		public int AdvanceX {
			get {
				return Width + kerning;
			}
		}

		public Bitmap Image {
			get {
				return charImage.Image;
			}
		}

		public Rectangle Rect {
			get {
				int left = _x;
				if (IsMonospace) {
					left += (maxNumberWidth - charImage.Width) / 2;
				}
				return new Rectangle(left, _y, charImage.Width, charImage.Height);
			}
		}

		public char CharCode {
			get {
				return _charCode;
			}
		}

		private bool IsMonospace {
			get {
				return isNum && numMonospace;
			}
		}
		
		public static int Kerning {
			set {
				kerning = value;
			}
		}

		public static int SpaceWidth {
			get {
				if (spaceWidth == 0) {
					return 0;
				}
				return spaceWidth + kerning;
			}
			set {
				spaceWidth = value;
			}
		}

		public static bool KerningPairs {
			get {
				return isKerningPairs;
			}
			set {
				isKerningPairs = value;
			}
		}

		public static bool NumMonospace {
			set {
				numMonospace = value;
			}
		}

		public static int LineHeight {
			get {
				if (lineHeight == 0) {
					return CharImage.LineHeight;
				}
				return lineHeight;
			}
			set {
				lineHeight = value;
			}
		}
	}
}
