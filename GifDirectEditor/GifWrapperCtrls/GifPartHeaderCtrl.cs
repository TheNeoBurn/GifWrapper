using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BjSTools.IO.GifWrapperCtrls {
    public partial class GifPartHeaderCtrl : UserControl, IGifCtrl {
        private GifPartHeader _part;
        private bool _check = false;

        public event EventHandler ValueChanged;
        private void OnValueChanged() {
            if (ValueChanged != null) {
                try {
                    ValueChanged(this, EventArgs.Empty);
                } catch { }
            }
        }

        public GifPartHeaderCtrl() {
            InitializeComponent();

            optVersion.SelectedIndexChanged += (sender, e) => {
                if (_part == null) return;
                if (!_check) return;
                try {
                    _part.Version = optVersion.SelectedIndex == 0 ? "89a" : "87a";
                    OnValueChanged();
                } catch { }
            };
            numWidth.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.Width = v); };
            numHeight.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.Height = v); };
            numColorRes.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.ColorResolution = Convert.ToByte(v)); };
            numBGColor.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.BackgroundColor = Convert.ToByte(v)); };
            numAspectRatio.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.AspectRatio = Convert.ToByte(v)); };
            optColorTableSorted.CheckedChanged += (sender, e) => { OnValueChanged(sender as CheckBox, v => _part.TableSorted = v); };
            colorTable.ValueChanged += (sender, e) => { if (_part != null && _check) OnValueChanged(); };
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


        public GifPartHeader Part {
            get { return _part; }
            set {
                _check = false;
                _part = value;

                SuspendLayout();
                if (value == null) {
                    optVersion.SelectedIndex = 0;
                    numWidth.Value = 0;
                    numHeight.Value = 0;
                    numColorRes.Value = 0;
                    numBGColor.Value = 0;
                    numAspectRatio.Value = 0;
                    optColorTableSorted.Checked = false;
                    optUseColorTable.Checked = false;
                    numColorTableSize.Value = 0;
                    colorTable.Value = new List<Color>();
                } else {
                    optVersion.SelectedIndex = value.Version.Equals("89a") ? 0 : 1;
                    numWidth.Value = value.Width;
                    numHeight.Value = value.Height;
                    numColorRes.Value = value.ColorResolution;
                    numBGColor.Value = value.BackgroundColor;
                    numAspectRatio.Value = value.ColorResolution;
                    optColorTableSorted.Checked = value.TableSorted;
                    optUseColorTable.Checked = value.UseGlobalColorTable;
                    numColorTableSize.Value = value.GlobalColorTableSize;
                    colorTable.Value = value.GlobalColorTable ?? new List<Color>();
                }
                ResumeLayout();

                _check = true;
            }
        }

        public GifPart GifPart {
            get { return _part; }
            set { this.Part = value as GifPartHeader; }
        }

        private void btnTransformColors_Click(object sender, EventArgs e) {
            if (colorTable.Value == null || colorTable.Value.Count == 0) return;

            GifColorTableTransformFrm d = new GifColorTableTransformFrm(colorTable.Value);
            if (d.ShowDialog() == DialogResult.OK) {
                // Apply each color - needed to replace colors in underlying GifPart
                for (int i = 0; i < d.Value.Count; i++) {
                    colorTable.Value[i] = d.Value[i];
                }
                // Update color table in UI
                colorTable.Value = colorTable.Value;

                OnValueChanged();
            }
        }
    }
}
