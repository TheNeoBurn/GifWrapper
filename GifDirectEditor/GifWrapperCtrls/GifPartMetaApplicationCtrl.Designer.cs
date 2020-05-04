namespace BjSTools.IO.GifWrapperCtrls {
    partial class GifPartMetaApplicationCtrl {
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
            this.txtAppIdent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hexParas = new BjSTools.IO.GifWrapperCtrls.GifHexView();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAppIdent
            // 
            this.txtAppIdent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppIdent.Location = new System.Drawing.Point(6, 19);
            this.txtAppIdent.Name = "txtAppIdent";
            this.txtAppIdent.Size = new System.Drawing.Size(228, 22);
            this.txtAppIdent.TabIndex = 3;
            this.txtAppIdent.Text = "NETSCAPE2.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "App Identification:";
            // 
            // hexParas
            // 
            this.hexParas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hexParas.AutoScroll = true;
            this.hexParas.Location = new System.Drawing.Point(6, 60);
            this.hexParas.Name = "hexParas";
            this.hexParas.Size = new System.Drawing.Size(277, 234);
            this.hexParas.TabIndex = 4;
            this.hexParas.Value = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parameters:";
            // 
            // GifPartMetaApplicationCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hexParas);
            this.Controls.Add(this.txtAppIdent);
            this.Controls.Add(this.label1);
            this.Name = "GifPartMetaApplicationCtrl";
            this.Size = new System.Drawing.Size(286, 297);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAppIdent;
        private System.Windows.Forms.Label label1;
        private GifHexView hexParas;
        private System.Windows.Forms.Label label2;
    }
}
