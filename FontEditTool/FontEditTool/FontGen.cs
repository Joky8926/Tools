namespace FontEditTool {
	class FontGen {
		private static short kerning = 0;
		private BMFontConfiguration conf;
		private FontPage page;

		public FontGen(string fntFileName) {
			conf = new BMFontConfiguration(fntFileName);
			page = new FontPage(conf.PngFileName, conf.LstFontDef, conf.LstKerning);
		}

		public FontChar GetCharImg(char code) {
			return page.GetCharImg(code);
		}

		public int? GetKerningPairAmount(char[] chars) {
			return page.GetKerningPairAmount(chars[0], chars[1]);
		}

		public void SetKerningPair(char[] chars, short amount) {
			page.SetKerningPair(chars[0], chars[1], amount);
		}

		public void SaveConfig() {
			conf.SaveConfig(page.GetContent());
		}

		public short SpaceWidth {
			get {
				return page.SpaceWidth;
			}
			set {
				page.SpaceWidth = value;
			}
		}

		public int LineHeight {
			get {
				return conf.LineHeight;
			}
			set {
				conf.LineHeight = value;
			}
		}

		public static short Kerning {
			get {
				return kerning;
			}
			set {
				kerning = value;
			}
		}
	}
}
