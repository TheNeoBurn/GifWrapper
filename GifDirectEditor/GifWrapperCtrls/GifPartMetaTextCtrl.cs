using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BjSTools.IO.GifWrapperCtrls {
    public partial class GifPartMetaTextCtrl : UserControl, IGifCtrl {
        private GifPartMetaData.TextDraw _part;
        private bool _check = false;

        public event EventHandler ValueChanged;
        private void OnValueChanged() {
            if (ValueChanged != null) {
                try {
                    ValueChanged(this, EventArgs.Empty);
                } catch { }
            }
        }

        public GifPartMetaTextCtrl() {
            InitializeComponent();

            numLeft.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.Left = v); };
            numTop.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.Top = v); };
            numWidth.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.Width = v); };
            numHeight.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.Height = v); };
            numCharWidth.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.CharWidth = Convert.ToByte(v)); };
            numCharHeight.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.CharHeight = Convert.ToByte(v)); };
            numTextColor.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.TextColor = Convert.ToByte(v)); };
            numBGColor.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.BackgroundColor = Convert.ToByte(v)); };
            txtText.TextChanged += (sender, e) => {
                if (_part == null || !_check) return;
                try {
                    _part.Text = txtText.Text;
                    OnValueChanged();
                } catch { }
            };

        }

        private void OnValueChanged(NumericUpDown num, Action<ushort> setter) {
            if (_part == null) return;
            if (!_check) return;

            try {
                ushort value = Convert.ToUInt16(num.Value);
                setter(value);
                OnValueChanged();
            } catch { }
        }

        public GifPartMetaData.TextDraw Part {
            get { return _part; }
            set {
                _check = false;
                _part = value;

                numLeft.Value = value.Left;
                numTop.Value = value.Top;
                numWidth.Value = value.Width;
                numHeight.Value = value.Height;
                numCharWidth.Value = value.CharWidth;
                numCharHeight.Value = value.CharHeight;
                numTextColor.Value = value.TextColor;
                numBGColor.Value = value.BackgroundColor;
                txtText.Text = value.Text;

                _check = true;
            }
        }

        public GifPart GifPart {
            get { return _part; }
            set { this.Part = value as GifPartMetaData.TextDraw; }
        }

    }
}
