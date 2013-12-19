using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Wlx2Explorer.App_Code.Common
{
    class KeyboardHook
    {
        private IntPtr _hookHandle;
        private KeyboardHookProc _hookProc;
        private Int32 _key1;
        private Int32 _key2;
        private Int32 _key3;

        public event EventHandler<EventArgs> Hooked;

        public Boolean Start(Int32 key1, Int32 key2, Int32 key3)
        {
            _key1 = key1;
            _key2 = key2;
            _key3 = key3;
            _hookProc = HookProc;
            var moduleHandle = NativeMethods.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
            _hookHandle = NativeMethods.SetWindowsHookEx(NativeConstants.WH_KEYBOARD_LL, _hookProc, moduleHandle, 0);
            var hookStarted = _hookHandle != IntPtr.Zero;
            return hookStarted;
        }

        public Boolean Stop()
        {
            if (_hookHandle == IntPtr.Zero) return true;
            var hookStoped = NativeMethods.UnhookWindowsHookEx(_hookHandle);
            return hookStoped;
        }

        private Int32 HookProc(Int32 code, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            if (code == NativeConstants.HC_ACTION)
            {
                if (wParam.ToInt32() == NativeConstants.WM_KEYDOWN)
                {
                    var key1 = true;
                    var key2 = true;

                    if (_key1 != (Int32)ModifierKey.None)
                    {
                        var key1State = NativeMethods.GetAsyncKeyState(_key1) & 0x8000;
                        key1 = Convert.ToBoolean(key1State);
                    }

                    if (_key2 != (Int32)ModifierKey.None)
                    {
                        var key2State = NativeMethods.GetAsyncKeyState(_key2) & 0x8000;
                        key2 = Convert.ToBoolean(key2State);
                    }

                    if (key1 && key2 && lParam.vkCode == _key3)
                    {
                        var handler = Hooked;
                        if (handler != null)
                        {
                            handler.BeginInvoke(this, EventArgs.Empty, null, null);
                        }
                    }
                }
            }
            return NativeMethods.CallNextHookEx(_hookHandle, code, wParam, ref lParam);
        }
    }
}
