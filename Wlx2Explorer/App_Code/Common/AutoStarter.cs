using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;

namespace Wlx2Explorer.App_Code.Common
{
    static class AutoStarter
    {
        private const String RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public static void SetAutoStart(String keyName, String assemblyLocation)
        {
            var key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            key.SetValue(keyName, assemblyLocation);
        }

        public static void UnsetAutoStart(String keyName)
        {
            var key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            key.DeleteValue(keyName);
        }

        public static Boolean IsAutoStartEnabled(String keyName, String assemblyLocation)
        {
            var key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION);
            if (key == null) return false;
            var value = (String)key.GetValue(keyName);
            if (String.IsNullOrEmpty(value)) return false;
            var result = (value == assemblyLocation);
            return result;
        }
    }
}
