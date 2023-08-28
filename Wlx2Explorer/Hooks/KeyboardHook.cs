using System;
using System.Diagnostics;
using Wlx2Explorer.Native;

namespace Wlx2Explorer.Hooks
{
    class KeyboardHook
    {
        private IntPtr _hookHandle;
        private KeyboardHookProc _hookProc;
        private int _key1;
        private int _key2;
        private int _key3;

        public event EventHandler<EventArgs> Hooked;

        public bool Start(int key1, int key2, int key3)
        {
            _key1 = key1;
            _key2 = key2;
            _key3 = key3;
            _hookProc = HookProc;
            using var currentProcess = Process.GetCurrentProcess();
            using var currentModule = currentProcess.MainModule;
            var moduleHandle = NativeMethods.GetModuleHandle(currentModule.ModuleName);
            _hookHandle = NativeMethods.SetWindowsHookEx(NativeConstants.WH_KEYBOARD_LL, _hookProc, moduleHandle, 0);
            var hookStarted = _hookHandle != IntPtr.Zero;
            return hookStarted;
        }

        public bool Stop()
        {
            if (_hookHandle == IntPtr.Zero)
            {
                return true;
            }
            var hookStoped = NativeMethods.UnhookWindowsHookEx(_hookHandle);
            return hookStoped;
        }

        private int HookProc(int code, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            if (code == NativeConstants.HC_ACTION)
            {
                if (wParam.ToInt32() == NativeConstants.WM_KEYDOWN || wParam.ToInt32() == NativeConstants.WM_SYSKEYDOWN)
                {
                    var key1 = true;
                    var key2 = true;

                    if (_key1 != (int)VirtualKeyModifier.None)
                    {
                        var key1State = NativeMethods.GetAsyncKeyState(_key1) & 0x8000;
                        key1 = Convert.ToBoolean(key1State);
                    }

                    if (_key2 != (int)VirtualKeyModifier.None)
                    {
                        var key2State = NativeMethods.GetAsyncKeyState(_key2) & 0x8000;
                        key2 = Convert.ToBoolean(key2State);
                    }

                    if (key1 && key2 && lParam.vkCode == _key3)
                    {
                        var handler = Hooked;
                        handler?.BeginInvoke(this, EventArgs.Empty, null, null);
                    }
                }
            }
            return NativeMethods.CallNextHookEx(_hookHandle, code, wParam, ref lParam);
        }
    }
}
