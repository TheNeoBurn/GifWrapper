namespace BjSTools.IO.GifWrapperCtrls {
    partial class GifPartHeaderCtrl {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GifPartHeaderCtrl));
            this.label1 = new System.Windows.Forms.Label();
            this.optVersion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numColorRes = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.optColorTableSorted = new System.Windows.Forms.CheckBox();
            this.numBGColor = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numAspectRatio = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.optUseColorTable = new System.Windows.Forms.CheckBox();
            this.numColorTableSize = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.colorTable = new BjSTools.IO.GifWrapperCtrls.GifColorTableCtrl();
            this.btnTransformColors = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColorRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBGColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAspectRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColorTableSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Version:";
            // 
            // optVersion
            // 
            this.optVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optVersion.FormattingEnabled = true;
            this.optVersion.Items.AddRange(new object[] {
            "89a",
            "87a"});
            this.optVersion.Location = new System.Drawing.Point(6, 16);
            this.optVersion.Name = "optVersion";
            this.optVersion.Size = new System.Drawing.Size(68, 24);
            this.optVersion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Width:";
            // 
            // numWidth
            // 
            this.numWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWidth.Location = new System.Drawing.Point(83, 18);
            this.numWidth.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(68, 22);
            this.numWidth.TabIndex = 2;
            this.numWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numWidth.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // numHeight
            // 
            this.numHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHeight.Location = new System.Drawing.Point(157, 18);
            this.numHeight.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(68, 22);
            this.numHeight.TabIndex = 3;
            this.numHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numHeight.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Height:";
            // 
            // numColorRes
            // 
            this.numColorRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numColorRes.Location = new System.Drawing.Point(6, 61);
            this.numColorRes.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numColorRes.Name = "numColorRes";
            this.numColorRes.Size = new System.Drawing.Size(40, 22);
            this.numColorRes.TabIndex = 4;
            this.numColorRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numColorRes.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Color Resolution:";
            // 
            // optColorTableSorted
            // 
            this.optColorTableSorted.AutoSize = true;
            this.optColorTableSorted.Location = new System.Drawing.Point(100, 91);
            this.optColorTableSorted.Name = "optColorTableSorted";
            this.optColorTableSorted.Size = new System.Drawing.Size(109, 17);
            this.optColorTableSorted.TabIndex = 7;
            this.optColorTableSorted.Text = "ColorTable sorted";
            this.optColorTableSorted.UseVisualStyleBackColor = true;
            // 
            // numBGColor
            // 
            this.numBGColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBGColor.Location = new System.Drawing.Point(100, 61);
            this.numBGColor.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBGColor.Name = "numBGColor";
            this.numBGColor.Size = new System.Drawing.Size(51, 22);
            this.numBGColor.TabIndex = 5;
            this.numBGColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numBGColor.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Backgroud Color:";
            // 
            // numAspectRatio
            // 
            this.numAspectRatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAspectRatio.Location = new System.Drawing.Point(6, 101);
            this.numAspectRatio.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numAspectRatio.Name = "numAspectRatio";
            this.numAspectRatio.Size = new System.Drawing.Size(51, 22);
            this.numAspectRatio.TabIndex = 6;
            this.numAspectRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numAspectRatio.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Aspect Ratio:";
            // 
            // optUseColorTable
            // 
            this.optUseColorTable.AutoSize = true;
            this.optUseColorTable.Enabled = false;
            this.optUseColorTable.Location = new System.Drawing.Point(6, 131);
            this.optUseColorTable.Name = "optUseColorTable";
            this.optUseColorTable.Size = new System.Drawing.Size(129, 17);
            this.optUseColorTable.TabIndex = 8;
            this.optUseColorTable.Text = "Use GlobalColorTable";
            this.optUseColorTable.UseVisualStyleBackColor = true;
            // 
            // numColorTableSize
            // 
            this.numColorTableSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numColorTableSize.Location = new System.Drawing.Point(141, 128);
            this.numColorTableSize.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numColorTableSize.Name = "numColorTableSize";
            this.numColorTableSize.Size = new System.Drawing.Size(51, 22);
            this.numColorTableSize.TabIndex = 9;
            this.numColorTableSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numColorTableSize.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(138, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Size:";
            // 
            // colorTable
            // 
            this.colorTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorTable.AutoScroll = true;
            this.colorTable.Location = new System.Drawing.Point(0, 154);
            this.colorTable.Name = "colorTable";
            this.colorTable.Size = new System.Drawing.Size(336, 239);
            this.colorTable.TabIndex = 16;
            this.colorTable.Value = ((System.Collections.Generic.IList<System.Drawing.Color>)(resources.GetObject("colorTable.Value")));
            // 
            // btnTransformColors
            // 
            this.btnTransformColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransformColors.Location = new System.Drawing.Point(237, 127);
            this.btnTransformColors.Name = "btnTransformColors";
            this.btnTransformColors.Size = new System.Drawing.Size(99, 23);
            this.btnTransformColors.TabIndex = 17;
            this.btnTransformColors.Text = "Transform colors";
            this.btnTransformColors.UseVisualStyleBackColor = true;
            this.btnTransformColors.Click += new System.EventHandler(this.btnTransformColors_Click);
            // 
            // GifPartHeaderCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTransformColors);
            this.Controls.Add(this.colorTable);
            this.Controls.Add(this.numColorTableSize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.optUseColorTable);
            this.Controls.Add(this.numAspectRatio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numBGColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.optColorTableSorted);
            this.Controls.Add(this.numColorRes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.optVersion);
            this.Controls.Add(this.label1);
            this.Name = "GifPartHeaderCtrl";
            this.Size = new System.Drawing.Size(339, 396);
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColorRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBGColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAspectRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColorTableSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox optVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numColorRes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox optColorTableSorted;
        private System.Windows.Forms.NumericUpDown numBGColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numAspectRatio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox optUseColorTable;
        private System.Windows.Forms.NumericUpDown numColorTableSize;
        private System.Windows.Forms.Label label7;
        private GifColorTableCtrl colorTable;
        private System.Windows.Forms.Button btnTransformColors;
    }
}
