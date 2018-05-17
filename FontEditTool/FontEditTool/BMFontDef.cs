using System.Drawing;
using System.Text.RegularExpressions;

namespace FontEditTool {
	class BMFontDef {
		public const char CHAR_SPACE = ' ';
		private const string LINE_TEMPLATE = "char id={0,-3} x={1,-4} y={2,-4} width={3,-4} height={4,-4} xoffset={5,-4} yoffset={6,-4} xadvance={7,-4} page=0 chnl=15\r\n";
		private char charID;
		private Rectangle rect;
		private short xOffset;
		private short yOffset;
		private short xAdvance;

		public BMFontDef(string line) {
			Parse(line);
		}

		public BMFontDef(short spaceWidth) {
			charID = CHAR_SPACE;
			rect = Rectangle.Empty;
			xOffset = spaceWidth;
			yOffset = 0;
			xAdvance = spaceWidth;
		}

		private void Parse(string line) {
			Match m = Regex.Match(line, @"id=(\d+)\s+x=(\d+)\s+y=(\d+)\s+width=(\d+)\s+height=(\d+)\s+xoffset=(\d+)\s+yoffset=(\d+)\s+xadvance=(\d+)\s+");
			GroupCollection gc = m.Groups;
			charID = (char)int.Parse(gc[1].Value);
			rect.X = int.Parse(gc[2].Value);
			rect.Y = int.Parse(gc[3].Value);
			rect.Width = int.Parse(gc[4].Value);
			rect.Height = int.Parse(gc[5].Value);
			xOffset = short.Parse(gc[6].Value);
			yOffset = short.Parse(gc[7].Value);
			xAdvance = short.Parse(gc[8].Value);
		}

		public override string ToString() {
			return string.Format(LINE_TEMPLATE, (int)charID, rect.X, rect.Y, rect.Width, rect.Height, xOffset, yOffset, AdvanceX);
		}

		public char CharId {
			get {
				return charID;
			}
		}

		public Rectangle Rect {
			get {
				return rect;
			}
		}

		public short OffsetX {
			get {
				return xOffset;
			}
			set {
				xOffset = value;
			}
		}

		public short OffsetY {
			get {
				return yOffset;
			}
		}

		public short AdvanceX {
			get {
				return (short)(xAdvance + FontGen.Kerning);
			}
			set {
				xAdvance = value;
			}
		}
	}
}
