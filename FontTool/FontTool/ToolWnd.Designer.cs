namespace FontTool {
	partial class ToolWnd {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.btnOpenPng = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textPngFile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textChars = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textKerning = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.textSpaceWidth = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.textLineHeight = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.textDoubleChar = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.checkBoxKerningPairs = new System.Windows.Forms.CheckBox();
			this.checkBoxNumMonospace = new System.Windows.Forms.CheckBox();
			this.btnConfirm = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnPreview = new System.Windows.Forms.Button();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.openPngDialog = new System.Windows.Forms.OpenFileDialog();
			this.labelSuccess = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textKerning)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textSpaceWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textLineHeight)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOpenPng
			// 
			this.btnOpenPng.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnOpenPng.Location = new System.Drawing.Point(242, 3);
			this.btnOpenPng.Name = "btnOpenPng";
			this.btnOpenPng.Size = new System.Drawing.Size(75, 23);
			this.btnOpenPng.TabIndex = 0;
			this.btnOpenPng.Text = "浏览";
			this.btnOpenPng.UseVisualStyleBackColor = true;
			this.btnOpenPng.Click += new System.EventHandler(this.btnOpenPng_Click);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "选择PNG文件：";
			// 
			// textPngFile
			// 
			this.textPngFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textPngFile.Enabled = false;
			this.textPngFile.Location = new System.Drawing.Point(116, 4);
			this.textPngFile.Name = "textPngFile";
			this.textPngFile.Size = new System.Drawing.Size(100, 21);
			this.textPngFile.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "PNG中对应的字符：";
			// 
			// textChars
			// 
			this.textChars.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textChars.Enabled = false;
			this.textChars.Location = new System.Drawing.Point(116, 32);
			this.textChars.Name = "textChars";
			this.textChars.Size = new System.Drawing.Size(100, 21);
			this.textChars.TabIndex = 3;
			this.textChars.TextChanged += new System.EventHandler(this.textChars_TextChanged);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(21, 90);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "字体间距(px)：";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.textKerning, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.textPngFile, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.textChars, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnOpenPng, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.textSpaceWidth, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.textLineHeight, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.textDoubleChar, 1, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(320, 164);
			this.tableLayoutPanel1.TabIndex = 4;
			// 
			// textKerning
			// 
			this.textKerning.Enabled = false;
			this.textKerning.Location = new System.Drawing.Point(116, 86);
			this.textKerning.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.textKerning.Name = "textKerning";
			this.textKerning.Size = new System.Drawing.Size(120, 21);
			this.textKerning.TabIndex = 6;
			this.textKerning.ValueChanged += new System.EventHandler(this.textKerning_ValueChanged);
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 117);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 12);
			this.label4.TabIndex = 7;
			this.label4.Text = "空格宽度(px)：";
			// 
			// textSpaceWidth
			// 
			this.textSpaceWidth.Enabled = false;
			this.textSpaceWidth.Location = new System.Drawing.Point(116, 113);
			this.textSpaceWidth.Name = "textSpaceWidth";
			this.textSpaceWidth.Size = new System.Drawing.Size(120, 21);
			this.textSpaceWidth.TabIndex = 8;
			this.textSpaceWidth.ValueChanged += new System.EventHandler(this.textSpaceWidth_ValueChanged);
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(45, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 12);
			this.label5.TabIndex = 9;
			this.label5.Text = "行高(px)：";
			// 
			// textLineHeight
			// 
			this.textLineHeight.Enabled = false;
			this.textLineHeight.Location = new System.Drawing.Point(116, 140);
			this.textLineHeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.textLineHeight.Name = "textLineHeight";
			this.textLineHeight.Size = new System.Drawing.Size(120, 21);
			this.textLineHeight.TabIndex = 10;
			this.textLineHeight.ValueChanged += new System.EventHandler(this.textLineHeight_ValueChanged);
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(57, 63);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 12);
			this.label7.TabIndex = 12;
			this.label7.Text = "双字符：";
			// 
			// textDoubleChar
			// 
			this.textDoubleChar.Enabled = false;
			this.textDoubleChar.Location = new System.Drawing.Point(116, 59);
			this.textDoubleChar.MaxLength = 9;
			this.textDoubleChar.Name = "textDoubleChar";
			this.textDoubleChar.Size = new System.Drawing.Size(100, 21);
			this.textDoubleChar.TabIndex = 13;
			this.textDoubleChar.Text = "\"";
			this.textDoubleChar.TextChanged += new System.EventHandler(this.textDoubleChar_TextChanged);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.checkBoxKerningPairs);
			this.flowLayoutPanel1.Controls.Add(this.checkBoxNumMonospace);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(79, 173);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(168, 22);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// checkBoxKerningPairs
			// 
			this.checkBoxKerningPairs.AutoSize = true;
			this.checkBoxKerningPairs.Enabled = false;
			this.checkBoxKerningPairs.Location = new System.Drawing.Point(3, 3);
			this.checkBoxKerningPairs.Name = "checkBoxKerningPairs";
			this.checkBoxKerningPairs.Size = new System.Drawing.Size(84, 16);
			this.checkBoxKerningPairs.TabIndex = 0;
			this.checkBoxKerningPairs.Text = "字距对调节";
			this.checkBoxKerningPairs.UseVisualStyleBackColor = true;
			this.checkBoxKerningPairs.CheckedChanged += new System.EventHandler(this.checkBoxKerningPairs_CheckedChanged);
			// 
			// checkBoxNumMonospace
			// 
			this.checkBoxNumMonospace.AutoSize = true;
			this.checkBoxNumMonospace.Enabled = false;
			this.checkBoxNumMonospace.Location = new System.Drawing.Point(93, 3);
			this.checkBoxNumMonospace.Name = "checkBoxNumMonospace";
			this.checkBoxNumMonospace.Size = new System.Drawing.Size(72, 16);
			this.checkBoxNumMonospace.TabIndex = 1;
			this.checkBoxNumMonospace.Text = "数字等宽";
			this.checkBoxNumMonospace.UseVisualStyleBackColor = true;
			this.checkBoxNumMonospace.CheckedChanged += new System.EventHandler(this.checkBoxNumMonospace_CheckedChanged);
			// 
			// btnConfirm
			// 
			this.btnConfirm.Enabled = false;
			this.btnConfirm.Location = new System.Drawing.Point(3, 3);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(75, 23);
			this.btnConfirm.TabIndex = 6;
			this.btnConfirm.Text = "确定";
			this.btnConfirm.UseVisualStyleBackColor = true;
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(165, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.Controls.Add(this.btnConfirm);
			this.flowLayoutPanel2.Controls.Add(this.btnPreview);
			this.flowLayoutPanel2.Controls.Add(this.btnCancel);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(41, 208);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(243, 29);
			this.flowLayoutPanel2.TabIndex = 8;
			// 
			// btnPreview
			// 
			this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnPreview.Enabled = false;
			this.btnPreview.Location = new System.Drawing.Point(84, 3);
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Size = new System.Drawing.Size(75, 23);
			this.btnPreview.TabIndex = 9;
			this.btnPreview.Text = "预览";
			this.btnPreview.UseVisualStyleBackColor = true;
			this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.AutoSize = true;
			this.flowLayoutPanel3.Controls.Add(this.tableLayoutPanel1);
			this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel1);
			this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel2);
			this.flowLayoutPanel3.Controls.Add(this.labelSuccess);
			this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(12, 12);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(326, 267);
			this.flowLayoutPanel3.TabIndex = 9;
			// 
			// openPngDialog
			// 
			this.openPngDialog.DefaultExt = "png";
			this.openPngDialog.Filter = "png文件|*.png";
			this.openPngDialog.Title = "请选择PNG文件";
			// 
			// labelSuccess
			// 
			this.labelSuccess.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelSuccess.AutoSize = true;
			this.labelSuccess.ForeColor = System.Drawing.Color.ForestGreen;
			this.labelSuccess.Location = new System.Drawing.Point(130, 245);
			this.labelSuccess.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
			this.labelSuccess.Name = "labelSuccess";
			this.labelSuccess.Size = new System.Drawing.Size(65, 12);
			this.labelSuccess.TabIndex = 11;
			this.labelSuccess.Text = "创建成功！";
			this.labelSuccess.Visible = false;
			// 
			// ToolWnd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(344, 288);
			this.Controls.Add(this.flowLayoutPanel3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ToolWnd";
			this.Text = "fnt字体制作工具";
			this.Load += new System.EventHandler(this.ToolWnd_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.textKerning)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textSpaceWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textLineHeight)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnOpenPng;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textPngFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textChars;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.CheckBox checkBoxKerningPairs;
		private System.Windows.Forms.CheckBox checkBoxNumMonospace;
		private System.Windows.Forms.NumericUpDown textKerning;
		private System.Windows.Forms.Button btnConfirm;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
		private System.Windows.Forms.OpenFileDialog openPngDialog;
		private System.Windows.Forms.Button btnPreview;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown textSpaceWidth;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown textLineHeight;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textDoubleChar;
		private System.Windows.Forms.Label labelSuccess;
	}
}