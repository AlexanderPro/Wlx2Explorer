using System;
using System.Runtime.InteropServices;

namespace Wlx2Explorer.Native.Interfaces
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("6D5140C1-7436-11CE-8034-00AA006009FA")]
    interface IServiceProvider
    {
        void QueryService([MarshalAs(UnmanagedType.LPStruct)] Guid guidService, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObject);
    }
}
