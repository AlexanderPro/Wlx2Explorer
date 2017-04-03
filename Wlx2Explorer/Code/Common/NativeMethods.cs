using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Wlx2Explorer.Code.Common
{
    class NativeMethods
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadLibrary(String fileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern Boolean FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, String procName);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean DestroyWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter, Int32 x, Int32 y, Int32 cx, Int32 cy, UInt32 flags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(Int32 idHook, KeyboardHookProc callback, IntPtr hInstance, UInt32 threadId);

        [DllImport("user32.dll")]
        public static extern Boolean UnhookWindowsHookEx(IntPtr handleHook);

        [DllImport("user32.dll")]
        public static extern Int32 CallNextHookEx(IntPtr handleHook, Int32 nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

        [DllImport("user32.dll")]
        public static extern Int32 GetAsyncKeyState(Int32 key);

        [DllImport("user32.dll")]
        public static extern IntPtr GetThreadDesktop(Int32 threadId);

        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(IntPtr hwnd);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(String name);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GetCurrentThreadId();
    }
}
