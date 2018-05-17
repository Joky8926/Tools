using System;
using System.IO;
using System.Windows.Forms;

namespace FontTool {
	public partial class ToolWnd : Form {
		private string pngFileName;
		private FontGen fontGen;
		private PreviewWnd previewWnd;

		public ToolWnd(string fileName = "") {
			pngFileName = fileName;
			InitializeComponent();
		}

		private void ToolWnd_Load(object sender, EventArgs e) {
			SetFilePath();
		}

		private void btnOpenPng_Click(object sender, EventArgs e) {
			if (openPngDialog.ShowDialog() == DialogResult.OK) {
				if (pngFileName == openPngDialog.FileName) {
					return;
				}
				pngFileName = openPngDialog.FileName;
				SetFilePath();
			}
		}

		private void textChars_TextChanged(object sender, EventArgs e) {
			SetChars();
		}

		private void textDoubleChar_TextChanged(object sender, EventArgs e) {
			fontGen.SetDoubleChars(textDoubleChar.Text);
			RefreshPreview();
		}

		private void textKerning_ValueChanged(object sender, EventArgs e) {
			FontChar.Kerning = (int)textKerning.Value;
			RefreshPreview();
		}

		private void textSpaceWidth_ValueChanged(object sender, EventArgs e) {
			FontChar.SpaceWidth = (int)textSpaceWidth.Value;
			RefreshPreview();
		}

		private void textLineHeight_ValueChanged(object sender, EventArgs e) {
			FontChar.LineHeight = (int)textLineHeight.Value;
			RefreshPreview();
		}

		private void checkBoxKerningPairs_CheckedChanged(object sender, EventArgs e) {
			if (FontChar.KerningPairs == checkBoxKerningPairs.Checked) {
				return;
			}
			FontChar.KerningPairs = checkBoxKerningPairs.Checked;
			if (FontChar.KerningPairs) {
				fontGen.GenKerningPairs();
			}
			RefreshPreview();
		}

		private void checkBoxNumMonospace_CheckedChanged(object sender, EventArgs e) {
			FontChar.NumMonospace = checkBoxNumMonospace.Checked;
			RefreshPreview();
		}

		private void btnConfirm_Click(object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(textChars.Text)) {
				MessageBox.Show("请输入png中对应的字符！", "警告");
				return;
			}
			fontGen.CreateFnt();
			labelSuccess.Visible = true;
		}

		private void btnPreview_Click(object sender, EventArgs e) {
			if (previewWnd != null) {
				return;
			}
			previewWnd = new PreviewWnd(this, fontGen);
			previewWnd.Show();
			previewWnd.FormClosed += OnClosedPreviewWnd;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}
		
		private void SetFilePath() {
			textPngFile.Text = pngFileName;
			if (string.IsNullOrWhiteSpace(pngFileName)) {
				return;
			}
			if (fontGen == null) {
				fontGen = new FontGen(pngFileName);
			} else {
				fontGen.ResetFileName(pngFileName);
			}
			string txtFileName = Path.ChangeExtension(pngFileName, "txt");
			if (File.Exists(txtFileName)) {
				using (StreamReader sr = new StreamReader(txtFileName)) {
					string line = sr.ReadLine();
					textChars.Text = line;
				}
			}
			SetChars();
			textLineHeight.Value = CharImage.LineHeight;
			textChars.Enabled = true;
			textDoubleChar.Enabled = true;
			textKerning.Enabled = true;
			textSpaceWidth.Enabled = true;
			textLineHeight.Enabled = true;
			checkBoxKerningPairs.Enabled = true;
			checkBoxNumMonospace.Enabled = true;
			btnConfirm.Enabled = true;
			btnPreview.Enabled = true;
		}

		private void SetChars() {
			fontGen.SetChars(textChars.Text);
			RefreshPreview();
		}

		private void RefreshPreview() {
			if (previewWnd != null) {
				previewWnd.DrawText();
			}
			labelSuccess.Visible = false;
		}

		public void CheckedKerningPairs() {
			checkBoxKerningPairs.Checked = true;
			labelSuccess.Visible = false;
		}

		private void OnClosedPreviewWnd(object sender, FormClosedEventArgs e) {
			previewWnd = null;
		}
	}
}
