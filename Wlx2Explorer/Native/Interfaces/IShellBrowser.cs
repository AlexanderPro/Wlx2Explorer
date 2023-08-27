using System;
using System.Runtime.InteropServices;

namespace Wlx2Explorer.Native.Interfaces
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214E2-0000-0000-C000-000000000046")]
    interface IShellBrowser
    {
        void GetWindow(out IntPtr phwnd);
    }
}
