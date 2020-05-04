using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BjSTools.IO.GifWrapperCtrls {
    public partial class GifPartMetaLoopCtrl : UserControl, IGifCtrl {
        private GifPartMetaData.Loop _part;
        private bool _check = false;

        public event EventHandler ValueChanged;
        private void OnValueChanged() {
            if (ValueChanged != null) {
                try {
                    ValueChanged(this, EventArgs.Empty);
                } catch { }
            }
        }

        public GifPartMetaLoopCtrl() {
            InitializeComponent();
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

        public GifPartMetaData.Loop Part {
            get { return _part; }
            set {
                _check = false;
                _part = value;

                if (value == null) {
                    numIterations.Value = 0;
                } else {
                    numIterations.Value = value.Iterations;
                }

                _check = true;
            }
        }

        public GifPart GifPart {
            get { return _part; }
            set { this.Part = value as GifPartMetaData.Loop; }
        }
    }
}
