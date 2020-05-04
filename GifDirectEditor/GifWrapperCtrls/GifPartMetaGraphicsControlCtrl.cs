using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BjSTools.IO.GifWrapperCtrls {
    public partial class GifPartMetaGraphicsControlCtrl : UserControl, IGifCtrl {
        private GifPartMetaData.GraphicsControl _part;
        private bool _check = false;

        public event EventHandler ValueChanged;
        private void OnValueChanged() {
            if (ValueChanged != null) {
                try {
                    ValueChanged(this, EventArgs.Empty);
                } catch { }
            }
        }

        public GifPartMetaGraphicsControlCtrl() {
            InitializeComponent();

            optDisposalMethod.SelectedIndex = 0;

            optDisposalMethod.SelectedIndexChanged += (sender, e) => {
                if (_part == null || !_check) return;
                try {
                    _part.DisposalMethod = (GifPartMetaData.DisposalMethods)optDisposalMethod.SelectedIndex;
                    OnValueChanged();
                } catch { }
            };
            optUseUserInput.CheckedChanged += (sender, e) => { OnValueChanged(sender as CheckBox, v => _part.UseUserInput = v); };
            optUseTransparency.CheckedChanged += (sender, e) => { OnValueChanged(sender as CheckBox, v => _part.UseTransparency = v); };
            numDelayTime.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.DelayTime = v); };
            numTransColor.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.TransparentColor = Convert.ToByte(v)); };
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
        private void OnValueChanged(CheckBox box, Action<bool> setter) {
            if (_part == null) return;
            if (!_check) return;

            try {
                bool value = box.Checked;
                setter(value);
                OnValueChanged();
            } catch { }
        }

        public GifPartMetaData.GraphicsControl Part {
            get { return _part; }
            set {
                _check = false;
                _part = value;

                if (value == null) {
                    optDisposalMethod.SelectedIndex = 0;
                    optUseUserInput.Checked = false;
                    optUseTransparency.Checked = false;
                    numDelayTime.Value = 0;
                    numTransColor.Value = 0;
                } else {
                    optDisposalMethod.SelectedIndex = (int)value.DisposalMethod;
                    optUseUserInput.Checked = value.UseUserInput;
                    optUseTransparency.Checked = value.UseTransparency;
                    numDelayTime.Value = value.DelayTime;
                    numTransColor.Value = value.TransparentColor;
                }

                _check = true;
            }
        }

        public GifPart GifPart {
            get { return _part; }
            set { this.Part = value as GifPartMetaData.GraphicsControl; }
        }
    }
}
