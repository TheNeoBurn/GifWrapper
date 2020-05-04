using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BjSTools.IO.GifWrapperCtrls
{
    public partial class GifColorTableTransformFrm : Form {
        public GifColorTableTransformFrm(IList<Color> colorTable) {
            InitializeComponent();
            this.Value = colorTable;
        }

        public IList<Color> Value {
            get { return colTableResult.Value; }
            set {
                colTableOriginal.Value = value;
                colTableResult.Value = value;
                UpdateResult();
            }
        }

        private bool _changing = false;

        private void selBrightness_ValueChanged(object sender, EventArgs e) {
            if (_changing) return;
            _changing = true;
            numBrightness.Value = selBrightness.Value;
            UpdateResult();
            _changing = false;
        }
        private void numBrightness_ValueChanged(object sender, EventArgs e) {
            if (_changing) return;
            _changing = true;
            selBrightness.Value = Convert.ToInt32(numBrightness.Value);
            UpdateResult();
            _changing = false;
        }

        private void selContrast_ValueChanged(object sender, EventArgs e) {
            if (_changing) return;
            _changing = true;
            numContrast.Value = selContrast.Value;
            UpdateResult();
            _changing = false;
        }
        private void numContrast_ValueChanged(object sender, EventArgs e) {
            if (_changing) return;
            _changing = true;
            selContrast.Value = Convert.ToInt32(numContrast.Value);
            UpdateResult();
            _changing = false;
        }

        private void selColor_ValueChanged(object sender, EventArgs e) {
            if (_changing) return;
            _changing = true;
            numColor.Value = selColor.Value;
            UpdateResult();
            _changing = false;
        }
        private void numColor_ValueChanged(object sender, EventArgs e) {
            if (_changing) return;
            _changing = true;
            selColor.Value = Convert.ToInt32(numColor.Value);
            UpdateResult();
            _changing = false;
        }

        private void UpdateResult() {
            if (colTableOriginal.Value == null) return;

            List<Color> result = new List<Color>();
            foreach (Color c in colTableOriginal.Value) {
                // Read current color
                double r = c.R;
                double g = c.G;
                double b = c.B;
                double v, h, m, u;

                // Apply brightness
                v = selBrightness.Value;
                if (v > 0) {
                    r = r + ((255d - r) * v / 100d);
                    g = g + ((255d - g) * v / 100d);
                    b = b + ((255d - b) * v / 100d);
                } else if (v < 0) {
                    r *= (100d + v) / 100d;
                    g *= (100d + v) / 100d;
                    b *= (100d + v) / 100d;
                }

                // Apply contrast
                v = (selContrast.Value + 100d) / 100d;
                h = (r + g + b) / 3d;
                r = Math.Max(0, Math.Min(255, h + (r - h) * v));
                g = Math.Max(0, Math.Min(255, h + (g - h) * v));
                b = Math.Max(0, Math.Min(255, h + (b - h) * v));

                // Apply color
                v = (selColor.Value + 360d) % 360d;
                m = (v % 120d) / 120d;
                u = (120d - (v % 120d)) / 120d;
                double nr, ng, nb;
                if (v < 120d) {
                    nr = (r * u) + (g * m);
                    ng = (g * u) + (b * m);
                    nb = (b * u) + (r * m);
                } else if (v < 240d) {
                    nr = (g * u) + (b * m);
                    ng = (b * u) + (r * m);
                    nb = (r * u) + (g * m);
                } else {
                    nr = (b * u) + (r * m);
                    ng = (r * u) + (g * m);
                    nb = (g * u) + (b * m);
                }
                r = nr; g = ng; b = nb;

                // Safeguard values
                byte br = Convert.ToByte(Math.Max(0, Math.Min(255, r)));
                byte bg = Convert.ToByte(Math.Max(0, Math.Min(255, g)));
                byte bb = Convert.ToByte(Math.Max(0, Math.Min(255, b)));
                result.Add(Color.FromArgb(br, bg, bb));
            }

            colTableResult.Value = result;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnApply_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
    }
}
