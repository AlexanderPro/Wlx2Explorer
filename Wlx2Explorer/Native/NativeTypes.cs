using System;
using System.Runtime.InteropServices;

namespace Wlx2Explorer.Native
{
    [StructLayout(LayoutKind.Sequential)]
    struct KBDLLHOOKSTRUCT
    {
        public int vkCode;
        public int scanCode;
        public int flags;
        public int time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    class ListDefaultParamStruct
    {
        public int size;
        public int interfaceVersionLow;
        public int interfaceVersionHigh;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string defaultIniFile;
    }

    [StructLayout(LayoutKind.Sequential)]
    class Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public int Width { get { return Right - Left; } }
        public int Height { get { return Bottom - Top; } }
    }

    delegate int KeyboardHookProc(int code, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);
}
