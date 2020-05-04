using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BjSTools.IO.GifWrapperCtrls {
    public partial class GifColorTableCtrl : UserControl {
        private const int COLUMNS = 16;
        private const int TILESIZE = 32;

        public event EventHandler ValueChanged;
        private void OnValueChanged() {
            if (ValueChanged != null) {
                try {
                    ValueChanged(this, EventArgs.Empty);
                } catch { }
            }
        }

        private IList<Color> _table = new List<Color>();
        private int Rows = 0;

        public GifColorTableCtrl() {
            InitializeComponent();
            UpdateTable();
        }

        public IList<Color> Value {
            get { return _table; }
            set {
                _table = value;
                UpdateTable();
            }
        }

        private void UpdateTable() {
            Rows = Math.Max(1, ((_table.Count - 1) / COLUMNS) + 1);

            Bitmap bmp = new Bitmap(COLUMNS * TILESIZE, Rows * TILESIZE);
            using (Graphics g = Graphics.FromImage(bmp)) {
                int x = 0;
                int y = 0;
                foreach (Color c in _table) {
                    g.DrawRectangle(Pens.Black, x * TILESIZE, y * TILESIZE, TILESIZE - 1, TILESIZE - 1);
                    using (SolidBrush b = new SolidBrush(c)) {
                        g.FillRectangle(b, x * TILESIZE + 1, y * TILESIZE + 1, TILESIZE - 3, TILESIZE - 3);
                    }

                    x++;
                    if (x == COLUMNS) {
                        x = 0;
                        y++;
                    }
                }
            }

            if (picTable.Image != null) picTable.Image.Dispose();
            picTable.Image = bmp;
            picTable.Height = picTable.Width * Rows / COLUMNS;

            GC.Collect();
        }

        private void picTable_MouseClick(object sender, MouseEventArgs e) {
            if (!this.Enabled) return;

            if (e.Button == MouseButtons.Left) {
                int x = COLUMNS * e.X / picTable.Width;
                int y = e.Y * Rows / picTable.Height;
                int i = COLUMNS * y + x;
                if (i < _table.Count) {
                    OnColorClicked(i);
                }
            }
        }

        private void picTable_Resize(object sender, EventArgs e) {
            picTable.Height = picTable.Width * Rows / COLUMNS;
        }

        private void OnColorClicked(int i) {
            Color c = _table[i];
            ColorDialog d = new ColorDialog();
            d.Color = c;
            if (d.ShowDialog() == DialogResult.OK) {
                _table[i] = d.Color;
                UpdateTable();
                OnValueChanged();
            }
        }
    }
}
