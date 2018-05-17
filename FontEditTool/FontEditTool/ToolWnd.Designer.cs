namespace FontEditTool {
	partial class ToolWnd {
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent() {
			this.openFntDialog = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelKerningErr = new System.Windows.Forms.Label();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.label5 = new System.Windows.Forms.Label();
			this.textCharPairs = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textAmount = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.textKerning = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.textFntFile = new System.Windows.Forms.TextBox();
			this.btnOpenFnt = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.textSpaceWidth = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.textLineHeight = new System.Windows.Forms.NumericUpDown();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.richText = new System.Windows.Forms.RichTextBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.labelSave = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textAmount)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textKerning)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textSpaceWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textLineHeight)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.flowLayoutPanel3.SuspendLayout();
			this.flowLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFntDialog
			// 
			this.openFntDialog.Filter = "fnt文件|*.fnt";
			this.openFntDialog.Title = "请选择FNT文件";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox1.AutoSize = true;
			this.groupBox1.Controls.Add(this.labelKerningErr);
			this.groupBox1.Controls.Add(this.flowLayoutPanel2);
			this.groupBox1.Location = new System.Drawing.Point(4, 119);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(325, 79);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "单独调整字距：";
			// 
			// labelKerningErr
			// 
			this.labelKerningErr.AutoSize = true;
			this.labelKerningErr.ForeColor = System.Drawing.Color.Red;
			this.labelKerningErr.Location = new System.Drawing.Point(78, 50);
			this.labelKerningErr.Name = "labelKerningErr";
			this.labelKerningErr.Size = new System.Drawing.Size(101, 12);
			this.labelKerningErr.TabIndex = 6;
			this.labelKerningErr.Text = "无效的字符组合！";
			this.labelKerningErr.Visible = false;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.Controls.Add(this.label5);
			this.flowLayoutPanel2.Controls.Add(this.textCharPairs);
			this.flowLayoutPanel2.Controls.Add(this.label6);
			this.flowLayoutPanel2.Controls.Add(this.textAmount);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 20);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(313, 27);
			this.flowLayoutPanel2.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 7);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 12);
			this.label5.TabIndex = 0;
			this.label5.Text = "字符组合：";
			// 
			// textCharPairs
			// 
			this.textCharPairs.Enabled = false;
			this.textCharPairs.Location = new System.Drawing.Point(74, 3);
			this.textCharPairs.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
			this.textCharPairs.MaxLength = 2;
			this.textCharPairs.Name = "textCharPairs";
			this.textCharPairs.Size = new System.Drawing.Size(60, 21);
			this.textCharPairs.TabIndex = 1;
			this.textCharPairs.WordWrap = false;
			this.textCharPairs.TextChanged += new System.EventHandler(this.textCharPairs_TextChanged);
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(167, 7);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 12);
			this.label6.TabIndex = 2;
			this.label6.Text = "偏移量(px)：";
			// 
			// textAmount
			// 
			this.textAmount.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textAmount.Enabled = false;
			this.textAmount.Location = new System.Drawing.Point(250, 3);
			this.textAmount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.textAmount.Name = "textAmount";
			this.textAmount.Size = new System.Drawing.Size(60, 21);
			this.textAmount.TabIndex = 3;
			this.textAmount.ValueChanged += new System.EventHandler(this.textAmount_ValueChanged);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.textKerning, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.label8, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.textFntFile, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnOpenFnt, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.label10, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.textSpaceWidth, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.label11, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.textLineHeight, 1, 3);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(19, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(296, 110);
			this.tableLayoutPanel2.TabIndex = 6;
			// 
			// textKerning
			// 
			this.textKerning.Enabled = false;
			this.textKerning.Location = new System.Drawing.Point(92, 32);
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
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(83, 12);
			this.label7.TabIndex = 0;
			this.label7.Text = "选择FNT文件：";
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 36);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(77, 12);
			this.label8.TabIndex = 2;
			this.label8.Text = "调整字间距：";
			// 
			// textFntFile
			// 
			this.textFntFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textFntFile.Enabled = false;
			this.textFntFile.Location = new System.Drawing.Point(92, 4);
			this.textFntFile.Name = "textFntFile";
			this.textFntFile.Size = new System.Drawing.Size(100, 21);
			this.textFntFile.TabIndex = 1;
			// 
			// btnOpenFnt
			// 
			this.btnOpenFnt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnOpenFnt.Location = new System.Drawing.Point(218, 3);
			this.btnOpenFnt.Name = "btnOpenFnt";
			this.btnOpenFnt.Size = new System.Drawing.Size(75, 23);
			this.btnOpenFnt.TabIndex = 0;
			this.btnOpenFnt.Text = "浏览";
			this.btnOpenFnt.UseVisualStyleBackColor = true;
			this.btnOpenFnt.Click += new System.EventHandler(this.btnOpenFnt_Click);
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(21, 63);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(65, 12);
			this.label10.TabIndex = 7;
			this.label10.Text = "空格宽度：";
			// 
			// textSpaceWidth
			// 
			this.textSpaceWidth.Enabled = false;
			this.textSpaceWidth.Location = new System.Drawing.Point(92, 59);
			this.textSpaceWidth.Name = "textSpaceWidth";
			this.textSpaceWidth.Size = new System.Drawing.Size(120, 21);
			this.textSpaceWidth.TabIndex = 8;
			this.textSpaceWidth.ValueChanged += new System.EventHandler(this.textSpaceWidth_ValueChanged);
			// 
			// label11
			// 
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(21, 90);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(65, 12);
			this.label11.TabIndex = 9;
			this.label11.Text = "行高(px)：";
			// 
			// textLineHeight
			// 
			this.textLineHeight.Enabled = false;
			this.textLineHeight.Location = new System.Drawing.Point(92, 86);
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
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.richText);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 204);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(328, 66);
			this.flowLayoutPanel1.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "预览文本：";
			// 
			// richText
			// 
			this.richText.Enabled = false;
			this.richText.Location = new System.Drawing.Point(74, 3);
			this.richText.Name = "richText";
			this.richText.Size = new System.Drawing.Size(251, 60);
			this.richText.TabIndex = 0;
			this.richText.Text = "";
			this.richText.TextChanged += new System.EventHandler(this.richText_TextChanged);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(352, 12);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(1280, 640);
			this.pictureBox.TabIndex = 8;
			this.pictureBox.TabStop = false;
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.flowLayoutPanel3.AutoSize = true;
			this.flowLayoutPanel3.Controls.Add(this.btnSave);
			this.flowLayoutPanel3.Controls.Add(this.btnCancel);
			this.flowLayoutPanel3.Location = new System.Drawing.Point(86, 283);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(162, 29);
			this.flowLayoutPanel3.TabIndex = 9;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(3, 3);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 6;
			this.btnSave.Text = "保存";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(84, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// flowLayoutPanel4
			// 
			this.flowLayoutPanel4.AutoSize = true;
			this.flowLayoutPanel4.Controls.Add(this.tableLayoutPanel2);
			this.flowLayoutPanel4.Controls.Add(this.groupBox1);
			this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel1);
			this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel3);
			this.flowLayoutPanel4.Controls.Add(this.labelSave);
			this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel4.Location = new System.Drawing.Point(12, 12);
			this.flowLayoutPanel4.Name = "flowLayoutPanel4";
			this.flowLayoutPanel4.Size = new System.Drawing.Size(334, 342);
			this.flowLayoutPanel4.TabIndex = 10;
			// 
			// labelSave
			// 
			this.labelSave.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelSave.AutoSize = true;
			this.labelSave.ForeColor = System.Drawing.Color.ForestGreen;
			this.labelSave.Location = new System.Drawing.Point(134, 320);
			this.labelSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 10);
			this.labelSave.Name = "labelSave";
			this.labelSave.Size = new System.Drawing.Size(65, 12);
			this.labelSave.TabIndex = 10;
			this.labelSave.Text = "保存成功！";
			this.labelSave.Visible = false;
			// 
			// ToolWnd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 362);
			this.Controls.Add(this.flowLayoutPanel4);
			this.Controls.Add(this.pictureBox);
			this.KeyPreview = true;
			this.Name = "ToolWnd";
			this.Text = "Fnt字体编辑工具";
			this.Load += new System.EventHandler(this.ToolWnd_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolWnd_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.textAmount)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.textKerning)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textSpaceWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textLineHeight)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel4.ResumeLayout(false);
			this.flowLayoutPanel4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFntDialog;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textCharPairs;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown textAmount;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.NumericUpDown textKerning;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textFntFile;
		private System.Windows.Forms.Button btnOpenFnt;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown textSpaceWidth;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown textLineHeight;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox richText;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
		private System.Windows.Forms.Label labelKerningErr;
		private System.Windows.Forms.Label labelSave;
	}
}

