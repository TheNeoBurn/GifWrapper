using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BjSTools.IO.GifWrapperCtrls {
    public class CommonDialogDesigner : CommonDialog {
        public override void Reset() {
            
        }

        protected override bool RunDialog(IntPtr hwndOwner) {
            return true;
        }
    }
}
