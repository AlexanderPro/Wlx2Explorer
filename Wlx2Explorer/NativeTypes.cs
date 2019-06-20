using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Wlx2Explorer
{
    [StructLayout(LayoutKind.Sequential)]
    struct KBDLLHOOKSTRUCT
    {
        public Int32 vkCode;
        public Int32 scanCode;
        public Int32 flags;
        public Int32 time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    class ListDefaultParamStruct
    {
        public Int32 size;
        public Int32 interfaceVersionLow;
        public Int32 interfaceVersionHigh;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public String defaultIniFile;
    }

    [StructLayout(LayoutKind.Sequential)]
    class Rect
    {
        public Int32 Left;
        public Int32 Top;
        public Int32 Right;
        public Int32 Bottom;
        public Int32 Width { get { return Right - Left; } }
        public Int32 Height { get { return Bottom - Top; } }
    }

    delegate Int32 KeyboardHookProc(Int32 code, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);
}
