using Microsoft.Win32;

namespace Wlx2Explorer
{
    static class StartUpManager
    {
        private const string RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public static void AddToStartup(string keyName, string assemblyLocation)
        {
            using var key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION, true);
            key.SetValue(keyName, assemblyLocation);
        }

        public static void RemoveFromStartup(string keyName)
        {
            using var key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION, true);
            key.DeleteValue(keyName);
        }

        public static bool IsInStartup(string keyName, string assemblyLocation)
        {
            using var key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION, true);
            if (key == null)
            {
                return false;
            }
            var value = (string)key.GetValue(keyName);
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            var result = (value == assemblyLocation);
            return result;
        }
    }
}
