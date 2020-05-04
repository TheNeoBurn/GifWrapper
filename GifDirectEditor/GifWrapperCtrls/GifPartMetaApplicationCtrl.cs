using System;
using System.Windows.Forms;

namespace BjSTools.IO.GifWrapperCtrls {
    public partial class GifPartMetaApplicationCtrl : UserControl, IGifCtrl {
        private GifPartMetaData.ApplicationData _part;
        private bool _check = false;

        public event EventHandler ValueChanged;
        private void OnValueChanged() {
            if (ValueChanged != null) {
                try {
                    ValueChanged(this, EventArgs.Empty);
                } catch { }
            }
        }

        public GifPartMetaApplicationCtrl() {
            InitializeComponent();

            txtAppIdent.TextChanged += (sender, e) => {
                if (_part == null || !_check) return;
                try {
                    _part.AppIdentifier = txtAppIdent.Text;
                    OnValueChanged();
                } catch { }
            }; 
        }

        public GifPartMetaData.ApplicationData Part {
            get { return _part; }
            set {
                _check = false;
                _part = value;

                if (value == null) {
                    txtAppIdent.Text = "";
                    hexParas.Value = null;
                } else {
                    txtAppIdent.Text = value.AppIdentifier;
                    hexParas.Value = value.Content;
                }

                _check = true;
            }
        }

        public GifPart GifPart {
            get { return _part; }
            set { this.Part = value as GifPartMetaData.ApplicationData; }
        }
    }
}
