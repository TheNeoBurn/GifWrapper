namespace BjSTools.IO.GifWrapperCtrls {
    partial class GifPartMetaGraphicsControlCtrl {
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
            this.optDisposalMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optUseUserInput = new System.Windows.Forms.CheckBox();
            this.optUseTransparency = new System.Windows.Forms.CheckBox();
            this.numDelayTime = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numTransColor = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDelayTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransColor)).BeginInit();
            this.SuspendLayout();
            // 
            // optDisposalMethod
            // 
            this.optDisposalMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.optDisposalMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optDisposalMethod.FormattingEnabled = true;
            this.optDisposalMethod.Items.AddRange(new object[] {
            "NotSpecified",
            "DoNotDispose",
            "RestoreToBGColor",
            "RestoreToPrevious",
            "Reserved4",
            "Reserved5",
            "Reserved6",
            "Reserved7"});
            this.optDisposalMethod.Location = new System.Drawing.Point(6, 19);
            this.optDisposalMethod.Name = "optDisposalMethod";
            this.optDisposalMethod.Size = new System.Drawing.Size(196, 24);
            this.optDisposalMethod.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Disposal Method:";
            // 
            // optUseUserInput
            // 
            this.optUseUserInput.AutoSize = true;
            this.optUseUserInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optUseUserInput.Location = new System.Drawing.Point(6, 49);
            this.optUseUserInput.Name = "optUseUserInput";
            this.optUseUserInput.Size = new System.Drawing.Size(112, 20);
            this.optUseUserInput.TabIndex = 2;
            this.optUseUserInput.Text = "Use UserInput";
            this.optUseUserInput.UseVisualStyleBackColor = true;
            // 
            // optUseTransparency
            // 
            this.optUseTransparency.AutoSize = true;
            this.optUseTransparency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optUseTransparency.Location = new System.Drawing.Point(6, 75);
            this.optUseTransparency.Name = "optUseTransparency";
            this.optUseTransparency.Size = new System.Drawing.Size(139, 20);
            this.optUseTransparency.TabIndex = 3;
            this.optUseTransparency.Text = "Use Transparency";
            this.optUseTransparency.UseVisualStyleBackColor = true;
            // 
            // numDelayTime
            // 
            this.numDelayTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDelayTime.Location = new System.Drawing.Point(6, 117);
            this.numDelayTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numDelayTime.Name = "numDelayTime";
            this.numDelayTime.Size = new System.Drawing.Size(71, 22);
            this.numDelayTime.TabIndex = 4;
            this.numDelayTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDelayTime.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Delay Time:";
            // 
            // numTransColor
            // 
            this.numTransColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTransColor.Location = new System.Drawing.Point(6, 158);
            this.numTransColor.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numTransColor.Name = "numTransColor";
            this.numTransColor.Size = new System.Drawing.Size(60, 22);
            this.numTransColor.TabIndex = 5;
            this.numTransColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Transparent Color:";
            // 
            // GifPartMetaGraphicsControlCtrl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.numTransColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numDelayTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.optUseTransparency);
            this.Controls.Add(this.optUseUserInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.optDisposalMethod);
            this.Name = "GifPartMetaGraphicsControlCtrl";
            this.Size = new System.Drawing.Size(301, 229);
            ((System.ComponentModel.ISupportInitialize)(this.numDelayTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTransColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox optDisposalMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox optUseUserInput;
        private System.Windows.Forms.CheckBox optUseTransparency;
        private System.Windows.Forms.NumericUpDown numDelayTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numTransColor;
        private System.Windows.Forms.Label label2;
    }
}
