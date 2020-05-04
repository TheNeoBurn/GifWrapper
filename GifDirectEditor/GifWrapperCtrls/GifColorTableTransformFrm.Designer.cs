namespace BjSTools.IO.GifWrapperCtrls
{
    partial class GifColorTableTransformFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GifColorTableTransformFrm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.colTableOriginal = new BjSTools.IO.GifWrapperCtrls.GifColorTableCtrl();
            this.colTableResult = new BjSTools.IO.GifWrapperCtrls.GifColorTableCtrl();
            this.selBrightness = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.numBrightness = new System.Windows.Forms.NumericUpDown();
            this.numContrast = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.selContrast = new System.Windows.Forms.TrackBar();
            this.numColor = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.selColor = new System.Windows.Forms.TrackBar();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selColor)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 157);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.colTableOriginal);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.colTableResult);
            this.splitContainer1.Size = new System.Drawing.Size(526, 181);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 10;
            // 
            // colTableOriginal
            // 
            this.colTableOriginal.AutoScroll = true;
            this.colTableOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colTableOriginal.Enabled = false;
            this.colTableOriginal.Location = new System.Drawing.Point(0, 0);
            this.colTableOriginal.Name = "colTableOriginal";
            this.colTableOriginal.Size = new System.Drawing.Size(261, 181);
            this.colTableOriginal.TabIndex = 0;
            this.colTableOriginal.Value = ((System.Collections.Generic.IList<System.Drawing.Color>)(resources.GetObject("colTableOriginal.Value")));
            // 
            // colTableResult
            // 
            this.colTableResult.AutoScroll = true;
            this.colTableResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colTableResult.Enabled = false;
            this.colTableResult.Location = new System.Drawing.Point(0, 0);
            this.colTableResult.Name = "colTableResult";
            this.colTableResult.Size = new System.Drawing.Size(261, 181);
            this.colTableResult.TabIndex = 0;
            this.colTableResult.Value = ((System.Collections.Generic.IList<System.Drawing.Color>)(resources.GetObject("colTableResult.Value")));
            // 
            // selBrightness
            // 
            this.selBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selBrightness.AutoSize = false;
            this.selBrightness.LargeChange = 10;
            this.selBrightness.Location = new System.Drawing.Point(103, 12);
            this.selBrightness.Maximum = 100;
            this.selBrightness.Minimum = -100;
            this.selBrightness.Name = "selBrightness";
            this.selBrightness.Size = new System.Drawing.Size(341, 32);
            this.selBrightness.TabIndex = 0;
            this.selBrightness.TickFrequency = 10;
            this.selBrightness.ValueChanged += new System.EventHandler(this.selBrightness_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Brightness:";
            // 
            // numBrightness
            // 
            this.numBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBrightness.Location = new System.Drawing.Point(452, 11);
            this.numBrightness.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numBrightness.Name = "numBrightness";
            this.numBrightness.Size = new System.Drawing.Size(63, 26);
            this.numBrightness.TabIndex = 2;
            this.numBrightness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBrightness.ValueChanged += new System.EventHandler(this.numBrightness_ValueChanged);
            // 
            // numContrast
            // 
            this.numContrast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numContrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numContrast.Location = new System.Drawing.Point(452, 58);
            this.numContrast.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numContrast.Name = "numContrast";
            this.numContrast.Size = new System.Drawing.Size(63, 26);
            this.numContrast.TabIndex = 4;
            this.numContrast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numContrast.ValueChanged += new System.EventHandler(this.numContrast_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contrast:";
            // 
            // selContrast
            // 
            this.selContrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selContrast.AutoSize = false;
            this.selContrast.LargeChange = 10;
            this.selContrast.Location = new System.Drawing.Point(103, 59);
            this.selContrast.Maximum = 100;
            this.selContrast.Minimum = -100;
            this.selContrast.Name = "selContrast";
            this.selContrast.Size = new System.Drawing.Size(341, 32);
            this.selContrast.TabIndex = 3;
            this.selContrast.TickFrequency = 10;
            this.selContrast.ValueChanged += new System.EventHandler(this.selContrast_ValueChanged);
            // 
            // numColor
            // 
            this.numColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numColor.Location = new System.Drawing.Point(452, 106);
            this.numColor.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numColor.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numColor.Name = "numColor";
            this.numColor.Size = new System.Drawing.Size(63, 26);
            this.numColor.TabIndex = 6;
            this.numColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numColor.ValueChanged += new System.EventHandler(this.numColor_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Color:";
            // 
            // selColor
            // 
            this.selColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selColor.AutoSize = false;
            this.selColor.LargeChange = 10;
            this.selColor.Location = new System.Drawing.Point(103, 107);
            this.selColor.Maximum = 180;
            this.selColor.Minimum = -180;
            this.selColor.Name = "selColor";
            this.selColor.Size = new System.Drawing.Size(341, 32);
            this.selColor.TabIndex = 5;
            this.selColor.TickFrequency = 10;
            this.selColor.ValueChanged += new System.EventHandler(this.selColor_ValueChanged);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.Green;
            this.btnApply.Location = new System.Drawing.Point(378, 344);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(137, 38);
            this.btnApply.TabIndex = 12;
            this.btnApply.Text = "OK";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Maroon;
            this.btnCancel.Location = new System.Drawing.Point(15, 344);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(137, 38);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // GifColorTableTransformFrm
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(527, 394);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.numColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selColor);
            this.Controls.Add(this.numContrast);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selContrast);
            this.Controls.Add(this.numBrightness);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selBrightness);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GifColorTableTransformFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transform Color Table";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private GifColorTableCtrl colTableOriginal;
        private GifColorTableCtrl colTableResult;
        private System.Windows.Forms.TrackBar selBrightness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numBrightness;
        private System.Windows.Forms.NumericUpDown numContrast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar selContrast;
        private System.Windows.Forms.NumericUpDown numColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar selColor;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
    }
}