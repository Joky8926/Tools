using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FontTool {
	partial class PreviewWnd : Form {
		private ToolWnd mainWnd;
		private FontGen fontGen;
		private Bitmap image;
		private Graphics graphics;
		private Color clearColor = Color.Empty;

		public PreviewWnd(ToolWnd wnd, FontGen obj) {
			mainWnd = wnd;
			fontGen = obj;
			InitializeComponent();
		}

		private void PreviewWnd_Load(object sender, EventArgs e) {
			image = new Bitmap(pictureBox.Width, pictureBox.Height, PixelFormat.Format32bppArgb);
			graphics = Graphics.FromImage(image);
		}

		private void textCharPairs_TextChanged(object sender, EventArgs e) {
			labelKerningErr.Visible = false;
			textAmount.Enabled = false;
			if (textCharPairs.Text.Length < 2) {
				return;
			}
			int? amount = fontGen.GetKerningPairAmount(textCharPairs.Text.ToCharArray());
			if (amount == null) {
				labelKerningErr.Visible = true;
			} else {
				textAmount.Value = amount ?? 0;
				textAmount.Enabled = true;
			}
		}

		private void textAmount_ValueChanged(object sender, EventArgs e) {
			FontChar.KerningPairs = true;
			fontGen.SetKerningPair(textCharPairs.Text.ToCharArray(), (short)textAmount.Value);
			DrawText();
			mainWnd.CheckedKerningPairs();
		}

		private void richText_TextChanged(object sender, EventArgs e) {
			DrawText();
		}

		private void btnColor_Click(object sender, EventArgs e) {
			if (colorDialog.ShowDialog() == DialogResult.OK) {
				clearColor = colorDialog.Color;
				DrawText();
			}
		}

		public void DrawText() {
			FontChar charImg;
			FontChar lastChar = null;
			graphics.Clear(clearColor);
			int currX = 0;
			int currY = 0;
			foreach (char code in richText.Text) {
				if (code == FontChar.CHAR_NEWLINE) {
					currX = 0;
					currY += FontChar.LineHeight;
					lastChar = null;
					continue;
				}
				if (code == FontChar.CHAR_SPACE && FontChar.SpaceWidth > 0) {
					currX += FontChar.SpaceWidth;
					lastChar = null;
				}
				charImg = fontGen.GetCharImg(code);
				if (charImg != null) {
					if (lastChar != null) {
						int offset = lastChar.GetNextCharOffsetX(charImg.CharCode);
						currX += offset;
					}
					graphics.DrawImage(charImg.Image, currX + charImg.OffsetX, currY + charImg.OffsetY);
					currX += charImg.AdvanceX;
					lastChar = charImg;
				}
			}
			pictureBox.Image = image;
		}
	}
}
