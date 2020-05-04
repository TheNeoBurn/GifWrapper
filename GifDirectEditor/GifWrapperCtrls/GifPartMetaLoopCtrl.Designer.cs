namespace BjSTools.IO.GifWrapperCtrls {
    partial class GifPartMetaLoopCtrl {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAppIdent = new System.Windows.Forms.TextBox();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "App Identification:";
            // 
            // txtAppIdent
            // 
            this.txtAppIdent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppIdent.Location = new System.Drawing.Point(6, 19);
            this.txtAppIdent.Name = "txtAppIdent";
            this.txtAppIdent.ReadOnly = true;
            this.txtAppIdent.Size = new System.Drawing.Size(228, 22);
            this.txtAppIdent.TabIndex = 1;
            this.txtAppIdent.Text = "NETSCAPE2.0";
            // 
            // numIterations
            // 
            this.numIterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numIterations.Location = new System.Drawing.Point(6, 60);
            this.numIterations.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numIterations.Name = "numIterations";
            this.numIterations.Size = new System.Drawing.Size(75, 22);
            this.numIterations.TabIndex = 17;
            this.numIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Iterations:";
            // 
            // GifPartMetaLoopCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numIterations);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAppIdent);
            this.Controls.Add(this.label1);
            this.Name = "GifPartMetaLoopCtrl";
            this.Size = new System.Drawing.Size(350, 396);
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAppIdent;
        private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.Label label5;
    }
}
