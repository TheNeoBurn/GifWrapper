using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BjSTools.IO.GifWrapperCtrls {
    public partial class GifPartGeneralHexViewCtrl : UserControl, IGifCtrl {
        public GifPart.IGifPartContent _part;
        private bool _check = false;

        public event EventHandler ValueChanged;
        private void OnValueChanged() {
            if (ValueChanged != null) {
                try {
                    ValueChanged(this, EventArgs.Empty);
                } catch { }
            }
        }

        public GifPartGeneralHexViewCtrl() {
            InitializeComponent();
        }

        public GifPart.IGifPartContent Part {
            get { return _part; }
            set {
                _check = false;
                _part = value;

                if (value == null) {
                    hexContent.Value = new byte[0];
                } else {
                    hexContent.Value = value.Content;
                }

                _check = true;
            }
        }

        public GifPart GifPart {
            get { return _part as GifPart; }
            set { this.Part = value as GifPart.IGifPartContent; }
        }

    }
}
