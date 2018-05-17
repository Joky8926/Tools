using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FontEditTool {
	public partial class ToolWnd : Form {
		private string fntFileName;
		private FontGen fontGen;
		private Bitmap image;
		private Graphics graphics;

		public ToolWnd(string fileName = "") {
			fntFileName = fileName;
			InitializeComponent();
		}

		private void ToolWnd_Load(object sender, EventArgs e) {
			if (fntFileName != "") {
				InitFontGen();
			}
			image = new Bitmap(pictureBox.Width, pictureBox.Height, PixelFormat.Format32bppArgb);
			graphics = Graphics.FromImage(image);
		}

		private void btnOpenFnt_Click(object sender, EventArgs e) {
			if (openFntDialog.ShowDialog() == DialogResult.OK) {
				if (fntFileName != openFntDialog.FileName) {
					fntFileName = openFntDialog.FileName;
					InitFontGen();
				}
			}
		}

		private void textKerning_ValueChanged(object sender, EventArgs e) {
			FontGen.Kerning = (short)textKerning.Value;
			DrawText();
		}

		private void textSpaceWidth_ValueChanged(object sender, EventArgs e) {
			fontGen.SpaceWidth = (short)textSpaceWidth.Value;
			DrawText();
		}

		private void textLineHeight_ValueChanged(object sender, EventArgs e) {
			fontGen.LineHeight = (int)textLineHeight.Value;
			DrawText();
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
			fontGen.SetKerningPair(textCharPairs.Text.ToCharArray(), (short)textAmount.Value);
			DrawText();
		}

		private void richText_TextChanged(object sender, EventArgs e) {
			DrawText();
		}

		private void btnSave_Click(object sender, EventArgs e) {
			if (fontGen == null) {
				return;
			}
			Save();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void ToolWnd_KeyDown(object sender, KeyEventArgs e) {
			if (e.Control & e.KeyCode == Keys.S) {
				Save();
			}
		}

		private void DrawText() {
			labelSave.Visible = false;
			FontChar charImg;
			FontChar lastChar = null;
			graphics.Clear(Color.Empty);
			int currX = 0;
			int currY = 0;
			foreach (char code in richText.Text) {
				charImg = fontGen.GetCharImg(code);
				if (code == '\n') {
					currX = 0;
					currY += fontGen.LineHeight;
					lastChar = null;
					continue;
				}
				if (charImg != null) {
					if (lastChar != null) {
						int offset = lastChar.GetNextCharOffsetX(charImg.CharId);
						currX += offset;
					}
					if (charImg.Image != null) {
						graphics.DrawImage(charImg.Image, currX + charImg.OffsetX, currY + charImg.OffsetY);
					}
					currX += charImg.AdvanceX;
					lastChar = charImg;
				}
			}
			pictureBox.Image = image;
		}

		private void InitFontGen() {
			textFntFile.Text = fntFileName;
			fontGen = new FontGen(fntFileName);
			textKerning.Value = 0;
			textSpaceWidth.Value = fontGen.SpaceWidth;
			textLineHeight.Value = fontGen.LineHeight;
			textKerning.Enabled = true;
			textSpaceWidth.Enabled = true;
			textLineHeight.Enabled = true;
			textCharPairs.Enabled = true;
			richText.Enabled = true;
		}

		private void Save() {
			fontGen.SaveConfig();
			labelSave.Visible = true;
		}
	}
}
