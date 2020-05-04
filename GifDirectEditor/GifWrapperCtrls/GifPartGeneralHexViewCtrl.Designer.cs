namespace BjSTools.IO.GifWrapperCtrls {
    partial class GifPartGeneralHexViewCtrl {
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
            this.hexContent = new BjSTools.IO.GifWrapperCtrls.GifHexView();
            this.SuspendLayout();
            // 
            // hexContent
            // 
            this.hexContent.AutoScroll = true;
            this.hexContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexContent.Location = new System.Drawing.Point(0, 0);
            this.hexContent.Name = "hexContent";
            this.hexContent.Size = new System.Drawing.Size(509, 536);
            this.hexContent.TabIndex = 0;
            this.hexContent.Value = null;
            // 
            // GifPartGeneralHexViewCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hexContent);
            this.Name = "GifPartGeneralHexViewCtrl";
            this.Size = new System.Drawing.Size(509, 536);
            this.ResumeLayout(false);

        }

        #endregion

        private GifHexView hexContent;
    }
}
