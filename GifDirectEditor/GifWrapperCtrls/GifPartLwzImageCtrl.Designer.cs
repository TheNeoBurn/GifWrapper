namespace BjSTools.IO.GifWrapperCtrls {
    partial class GifPartLwzImageCtrl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GifPartLwzImageCtrl));
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numLeft = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numTop = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.optColorTableSorted = new System.Windows.Forms.CheckBox();
            this.optInterlaced = new System.Windows.Forms.CheckBox();
            this.numMinCodeSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.optUseLocalColorTable = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numColorTableSize = new System.Windows.Forms.NumericUpDown();
            this.colorTable = new BjSTools.IO.GifWrapperCtrls.GifColorTableCtrl();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnImportGlobal = new System.Windows.Forms.Button();
            this.btnDeleteColorTable = new System.Windows.Forms.Button();
            this.btnTransformColors = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinCodeSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColorTableSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // numWidth
            // 
            this.numWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWidth.Location = new System.Drawing.Point(6, 62);
            this.numWidth.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(66, 22);
            this.numWidth.TabIndex = 3;
            this.numWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Width:";
            // 
            // numLeft
            // 
            this.numLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLeft.Location = new System.Drawing.Point(6, 19);
            this.numLeft.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numLeft.Name = "numLeft";
            this.numLeft.Size = new System.Drawing.Size(66, 22);
            this.numLeft.TabIndex = 1;
            this.numLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numLeft.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Left:";
            // 
            // numHeight
            // 
            this.numHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHeight.Location = new System.Drawing.Point(78, 62);
            this.numHeight.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(66, 22);
            this.numHeight.TabIndex = 4;
            this.numHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Height:";
            // 
            // numTop
            // 
            this.numTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTop.Location = new System.Drawing.Point(78, 19);
            this.numTop.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numTop.Name = "numTop";
            this.numTop.Size = new System.Drawing.Size(66, 22);
            this.numTop.TabIndex = 2;
            this.numTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Top:";
            // 
            // optColorTableSorted
            // 
            this.optColorTableSorted.AutoSize = true;
            this.optColorTableSorted.Location = new System.Drawing.Point(6, 112);
            this.optColorTableSorted.Name = "optColorTableSorted";
            this.optColorTableSorted.Size = new System.Drawing.Size(109, 17);
            this.optColorTableSorted.TabIndex = 6;
            this.optColorTableSorted.Text = "ColorTable sorted";
            this.optColorTableSorted.UseVisualStyleBackColor = true;
            // 
            // optInterlaced
            // 
            this.optInterlaced.AutoSize = true;
            this.optInterlaced.Location = new System.Drawing.Point(6, 89);
            this.optInterlaced.Name = "optInterlaced";
            this.optInterlaced.Size = new System.Drawing.Size(73, 17);
            this.optInterlaced.TabIndex = 5;
            this.optInterlaced.Text = "Interlaced";
            this.optInterlaced.UseVisualStyleBackColor = true;
            // 
            // numMinCodeSize
            // 
            this.numMinCodeSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinCodeSize.Location = new System.Drawing.Point(6, 155);
            this.numMinCodeSize.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMinCodeSize.Name = "numMinCodeSize";
            this.numMinCodeSize.Size = new System.Drawing.Size(60, 22);
            this.numMinCodeSize.TabIndex = 7;
            this.numMinCodeSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Minimum Code SIze:";
            // 
            // optUseLocalColorTable
            // 
            this.optUseLocalColorTable.AutoSize = true;
            this.optUseLocalColorTable.Enabled = false;
            this.optUseLocalColorTable.Location = new System.Drawing.Point(6, 184);
            this.optUseLocalColorTable.Name = "optUseLocalColorTable";
            this.optUseLocalColorTable.Size = new System.Drawing.Size(122, 17);
            this.optUseLocalColorTable.TabIndex = 8;
            this.optUseLocalColorTable.Text = "UseLocalColorTable";
            this.optUseLocalColorTable.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Size:";
            // 
            // numColorTableSize
            // 
            this.numColorTableSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numColorTableSize.Location = new System.Drawing.Point(135, 181);
            this.numColorTableSize.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numColorTableSize.Name = "numColorTableSize";
            this.numColorTableSize.ReadOnly = true;
            this.numColorTableSize.Size = new System.Drawing.Size(60, 22);
            this.numColorTableSize.TabIndex = 9;
            this.numColorTableSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colorTable
            // 
            this.colorTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorTable.AutoScroll = true;
            this.colorTable.Location = new System.Drawing.Point(6, 207);
            this.colorTable.Name = "colorTable";
            this.colorTable.Size = new System.Drawing.Size(333, 236);
            this.colorTable.TabIndex = 10;
            this.colorTable.TabStop = false;
            this.colorTable.Value = ((System.Collections.Generic.IList<System.Drawing.Color>)(resources.GetObject("colorTable.Value")));
            // 
            // picPreview
            // 
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPreview.Location = new System.Drawing.Point(150, 3);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(189, 149);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 12;
            this.picPreview.TabStop = false;
            // 
            // btnImportGlobal
            // 
            this.btnImportGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportGlobal.Location = new System.Drawing.Point(261, 155);
            this.btnImportGlobal.Name = "btnImportGlobal";
            this.btnImportGlobal.Size = new System.Drawing.Size(78, 23);
            this.btnImportGlobal.TabIndex = 20;
            this.btnImportGlobal.Text = "Import Global";
            this.btnImportGlobal.UseVisualStyleBackColor = true;
            this.btnImportGlobal.Click += new System.EventHandler(this.btnImportGlobal_Click);
            // 
            // btnDeleteColorTable
            // 
            this.btnDeleteColorTable.Location = new System.Drawing.Point(168, 155);
            this.btnDeleteColorTable.Name = "btnDeleteColorTable";
            this.btnDeleteColorTable.Size = new System.Drawing.Size(90, 23);
            this.btnDeleteColorTable.TabIndex = 21;
            this.btnDeleteColorTable.Text = "Delete Loacal";
            this.btnDeleteColorTable.UseVisualStyleBackColor = true;
            this.btnDeleteColorTable.Click += new System.EventHandler(this.btnDeleteColorTable_Click);
            // 
            // btnTransformColors
            // 
            this.btnTransformColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransformColors.Location = new System.Drawing.Point(201, 180);
            this.btnTransformColors.Name = "btnTransformColors";
            this.btnTransformColors.Size = new System.Drawing.Size(138, 23);
            this.btnTransformColors.TabIndex = 22;
            this.btnTransformColors.Text = "Transform colors";
            this.btnTransformColors.UseVisualStyleBackColor = true;
            this.btnTransformColors.Click += new System.EventHandler(this.btnTransformColors_Click);
            // 
            // GifPartLwzImageCtrl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnTransformColors);
            this.Controls.Add(this.btnDeleteColorTable);
            this.Controls.Add(this.btnImportGlobal);
            this.Controls.Add(this.numColorTableSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.optUseLocalColorTable);
            this.Controls.Add(this.colorTable);
            this.Controls.Add(this.numMinCodeSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.optColorTableSorted);
            this.Controls.Add(this.optInterlaced);
            this.Controls.Add(this.picPreview);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numTop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numLeft);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GifPartLwzImageCtrl";
            this.Size = new System.Drawing.Size(342, 446);
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinCodeSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColorTableSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numTop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.CheckBox optColorTableSorted;
        private System.Windows.Forms.CheckBox optInterlaced;
        private System.Windows.Forms.NumericUpDown numMinCodeSize;
        private System.Windows.Forms.Label label5;
        private GifColorTableCtrl colorTable;
        private System.Windows.Forms.CheckBox optUseLocalColorTable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numColorTableSize;
        private System.Windows.Forms.Button btnImportGlobal;
        private System.Windows.Forms.Button btnDeleteColorTable;
        private System.Windows.Forms.Button btnTransformColors;
    }
}
