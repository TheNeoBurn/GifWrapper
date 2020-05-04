using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BjSTools.IO.GifWrapperCtrls {
    public partial class GifHexView : UserControl {
        private byte[] _data = null;

        public GifHexView() {
            InitializeComponent();
        }

        public byte[] Value {
            get { return _data; }
            set {
                _data = value;
                SetValue(value ?? new byte[0]);
            }
        }

        private void SetValue(byte[] data) {
            StringBuilder sb = new StringBuilder();
            StringBuilder tb = new StringBuilder();

            int pos = 0;
            bool even = true;
            foreach (byte b in data) {
                if (pos % 16 == 0) {
                    if (tb.Length != 0) {
                        sb.Append("  ");
                        sb.Append(tb.ToString());
                        tb = new StringBuilder();
                    }
                    if (sb.Length != 0) {
                        sb.Append(Environment.NewLine);
                    }
                    sb.AppendFormat("{0:X8}", pos);
                    sb.Append(" ");
                }

                if (even) sb.Append(" ");
                sb.AppendFormat("{0:X2}", b);

                tb.Append((b > 0x1F && b < 0x7F) ? (char)b : '.');

                pos++;
                even = !even;
            }
            while (pos % 16 != 0) {
                if (even) sb.Append(" ");
                sb.Append("  ");

                pos++;
                even = !even;
            }

            if (tb.Length != 0) {
                sb.Append("  ");
                sb.Append(tb.ToString());
            }

            lblText.Text = sb.ToString();
        }
    }
}
