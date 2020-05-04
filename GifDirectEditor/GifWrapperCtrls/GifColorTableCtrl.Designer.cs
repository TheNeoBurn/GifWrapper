namespace BjSTools.IO.GifWrapperCtrls {
    partial class GifColorTableCtrl {
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
            this.picTable = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).BeginInit();
            this.SuspendLayout();
            // 
            // picTable
            // 
            this.picTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picTable.Location = new System.Drawing.Point(0, 0);
            this.picTable.Name = "picTable";
            this.picTable.Size = new System.Drawing.Size(198, 50);
            this.picTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTable.TabIndex = 0;
            this.picTable.TabStop = false;
            this.picTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picTable_MouseClick);
            this.picTable.Resize += new System.EventHandler(this.picTable_Resize);
            // 
            // GifColorTableCtrl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.Controls.Add(this.picTable);
            this.Name = "GifColorTableCtrl";
            this.Size = new System.Drawing.Size(198, 183);
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picTable;
    }
}
