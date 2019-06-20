using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Wlx2Explorer
{
    class Win32WindowWrapper : IWin32Window
    {
        public IntPtr Handle { get; private set; }

        public Win32WindowWrapper(IntPtr handle)
        {
            Handle = handle;
        }
    }
}