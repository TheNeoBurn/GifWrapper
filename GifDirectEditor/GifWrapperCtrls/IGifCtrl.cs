using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BjSTools.IO.GifWrapperCtrls {
    public interface IGifCtrl {
        event EventHandler ValueChanged;
        GifPart GifPart { get; set; }

    }
}
