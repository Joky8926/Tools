using System.Text.RegularExpressions;

namespace FontEditTool {
	class BMFontKerningDef {
		private const string LINE_TEMPLATE = "kerning first={0,-3} second={1,-3} amount={2}\r\n";
		private char charA;
		private char charB;
		private short amount;

		public BMFontKerningDef(string line) {
			Parse(line);
		}

		public BMFontKerningDef(char charA, char charB, short amount) {
			this.charA = charA;
			this.charB = charB;
			this.amount = amount;
		}

		private void Parse(string line) {
			Match m = Regex.Match(line, @"first=(\d+)\s+second=(\d+)\s+amount=(-?\d+)");
			GroupCollection gc = m.Groups;
			charA = (char)int.Parse(gc[1].Value);
			charB = (char)int.Parse(gc[2].Value);
			amount = short.Parse(gc[3].Value);
		}

		public char CharA {
			get {
				return charA;
			}
		}

		public char CharB {
			get {
				return charB;
			}
		}

		public short Amount {
			get {
				return amount;
			}
			set {
				amount = value;
			}
		}

		public override string ToString() {
			return string.Format(LINE_TEMPLATE, (int)charA, (int)charB, amount);
		}
	}
}
