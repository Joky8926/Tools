namespace FontTool {
	partial class PreviewWnd {
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
			this.richText = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelKerningErr = new System.Windows.Forms.Label();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.textCharPairs = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textAmount = new System.Windows.Forms.NumericUpDown();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textAmount)).BeginInit();
			this.SuspendLayout();
			// 
			// richText
			// 
			this.richText.Location = new System.Drawing.Point(74, 3);
			this.richText.Name = "richText";
			this.richText.Size = new System.Drawing.Size(251, 60);
			this.richText.TabIndex = 0;
			this.richText.Text = "";
			this.richText.TextChanged += new System.EventHandler(this.richText_TextChanged);
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
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.richText);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 98);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(328, 66);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(12, 170);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(1280, 640);
			this.pictureBox.TabIndex = 3;
			this.pictureBox.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.AutoSize = true;
			this.groupBox1.Controls.Add(this.labelKerningErr);
			this.groupBox1.Controls.Add(this.flowLayoutPanel2);
			this.groupBox1.Location = new System.Drawing.Point(12, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(325, 79);
			this.groupBox1.TabIndex = 4;
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
			this.labelKerningErr.TabIndex = 7;
			this.labelKerningErr.Text = "无效的字符组合！";
			this.labelKerningErr.Visible = false;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.Controls.Add(this.label2);
			this.flowLayoutPanel2.Controls.Add(this.textCharPairs);
			this.flowLayoutPanel2.Controls.Add(this.label3);
			this.flowLayoutPanel2.Controls.Add(this.textAmount);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 20);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(313, 27);
			this.flowLayoutPanel2.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "字符组合：";
			// 
			// textCharPairs
			// 
			this.textCharPairs.Location = new System.Drawing.Point(74, 3);
			this.textCharPairs.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
			this.textCharPairs.MaxLength = 2;
			this.textCharPairs.Name = "textCharPairs";
			this.textCharPairs.Size = new System.Drawing.Size(60, 21);
			this.textCharPairs.TabIndex = 1;
			this.textCharPairs.WordWrap = false;
			this.textCharPairs.TextChanged += new System.EventHandler(this.textCharPairs_TextChanged);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(167, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "偏移量(px)：";
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
			// PreviewWnd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 374);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "PreviewWnd";
			this.Text = "预览";
			this.Load += new System.EventHandler(this.PreviewWnd_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.textAmount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox richText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textCharPairs;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown textAmount;
		private System.Windows.Forms.Label labelKerningErr;
	}
}