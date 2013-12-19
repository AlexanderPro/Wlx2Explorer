using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wlx2Explorer.App_Code.Common.Extensions
{
    static class WindowExtensions
    {
        public static Boolean IsChildWindow(this IntPtr hwnd, IntPtr parentHwnd)
        {
            Boolean result = false;
            IntPtr currentHwnd = hwnd;
            for ( ; ; )
            {
                if (currentHwnd == parentHwnd)
                {
                    result = true;
                    break;
                }

                if (currentHwnd == IntPtr.Zero)
                {
                    result = false;
                    break;
                }

                currentHwnd = NativeMethods.GetParent(currentHwnd);
            }
            return result;
        }
    }
}
