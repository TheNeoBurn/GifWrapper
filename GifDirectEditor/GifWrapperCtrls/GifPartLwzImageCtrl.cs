using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BjSTools.IO.GifWrapperCtrls {
    public partial class GifPartLwzImageCtrl : UserControl, IGifCtrl {
        private GifPartLwzImage _part;
        private bool _check = false;

        public event EventHandler ValueChanged;
        private void OnValueChanged() {
            if (ValueChanged != null) {
                try {
                    ValueChanged(this, EventArgs.Empty);
                    UpdatePreview();
                } catch { }
            }
        }

        public GifPartLwzImageCtrl() {
            InitializeComponent();

            numLeft.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.Left = v); };
            numTop.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.Top = v); };
            numWidth.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.Width = v); };
            numHeight.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.Height = v); };
            numMinCodeSize.ValueChanged += (sender, e) => { OnValueChanged(sender as NumericUpDown, v => _part.MinimumCodeSize = Convert.ToByte(v)); };
            optInterlaced.CheckedChanged += (sender, e) => { OnValueChanged(sender as CheckBox, v => _part.Interlaced = v); };
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


        public GifPartLwzImage Part {
            get { return _part; }
            set {
                _check = false;
                _part = value;

                if (value == null) {
                    numLeft.Value = 0;
                    numTop.Value = 0;
                    numWidth.Value = 0;
                    numHeight.Value = 0;
                    numMinCodeSize.Value = 0;
                    numColorTableSize.Value = 0;
                    optInterlaced.Checked = false;
                    optColorTableSorted.Checked = false;
                    optUseLocalColorTable.Checked = false;
                    colorTable.Value = new List<Color>();
                } else {
                    numLeft.Value = value.Left;
                    numTop.Value = value.Top;
                    numWidth.Value = value.Width;
                    numHeight.Value = value.Height;
                    numMinCodeSize.Value = value.MinimumCodeSize;
                    numColorTableSize.Value = value.UseLocalColorTable ? value.LocalColorTableSize : 0;
                    optInterlaced.Checked = value.Interlaced;
                    optColorTableSorted.Checked = value.TableSorted;
                    optUseLocalColorTable.Checked = value.UseLocalColorTable;
                    colorTable.Value = value.LocalColorTable ?? new List<Color>();
                }

                UpdatePreview();

                _check = true;
            }
        }

        public GifPart GifPart {
            get { return _part; }
            set { this.Part = value as GifPartLwzImage; }
        }


        private void UpdatePreview() {
            if (this.InvokeRequired) {
                this.Invoke(new Action(UpdatePreview));
                return;
            }

            Image img = null;

            if (_part != null) {
                try {
                    img = _part.ToImage();
                } catch (Exception ex) {
                    img = new Bitmap(256, 256);
                    using (Graphics g = Graphics.FromImage(img))
                    using (Pen red = new Pen(Color.Red, 4f))
                    using (Font fnt = new Font(FontFamily.GenericSansSerif, 8f, FontStyle.Regular)) {

                        g.Clear(Color.Transparent);
                        g.DrawRectangle(red, 0, 0, 256, 256);
                        g.DrawLine(red, 0, 0, 256, 256);
                        g.DrawLine(red, 256, 0, 0, 256);

                        g.DrawString(ex.Message, fnt, Brushes.Black, new RectangleF(8, 8, 248, 248));
                    }
                }
            }

            if (picPreview.Image != null) picPreview.Image.Dispose();
            picPreview.Image = img;
        }

        private void btnImportGlobal_Click(object sender, EventArgs e) {
            if (_part == null) return;
            if (_part.Wrapper == null) {
                MessageBox.Show("No image connection set!", "No Wrapper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                if (!_part.Wrapper.Header.UseGlobalColorTable) {
                    throw new Exception("There is no global color table!");
                } else if (_part.UseLocalColorTable) {
                    if (_part.LocalColorTable.Count != _part.Wrapper.Header.GlobalColorTable.Count) {
                        throw new Exception("The color count does not match!");
                    } else {
                        _part.LocalColorTable = _part.Wrapper.Header.GlobalColorTable;
                    }
                } else {
                    _part.LocalColorTable = _part.Wrapper.Header.GlobalColorTable;
                }
                this.Part = _part;
                OnValueChanged();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteColorTable_Click(object sender, EventArgs e) {
            if (_part == null) return;

            try {
                if (_part.UseLocalColorTable) {
                    if (_part.Wrapper == null) {
                        throw new Exception("No image connection set!");
                    } else if (!_part.Wrapper.Header.UseGlobalColorTable) {
                        throw new Exception("There is no global color table to use!");
                    } else if (_part.LocalColorTable.Count != _part.Wrapper.Header.GlobalColorTable.Count) {
                        throw new Exception("The color count does not match!");
                    } else {
                        _part.LocalColorTable = null;
                    }
                }
                this.Part = _part;
                OnValueChanged();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error deleting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
