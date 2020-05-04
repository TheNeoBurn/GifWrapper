using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BjSTools.IO.GifWrapperCtrls {
    public partial class SelectNumberFrm : Form {
        public SelectNumberFrm(string title, string optName, decimal upperBound, decimal initValue) {
            InitializeComponent();

            this.Text = title;
            lblName.Text = optName + ":";
            numValue.Maximum = upperBound;
            numValue.Value = initValue;
        }

        protected override void OnShown(EventArgs e) {
            base.OnShown(e);

            this.CenterToParent();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        public decimal Value {
            get { return numValue.Value; }
            set { numValue.Value = value; }
        }
    }
}
