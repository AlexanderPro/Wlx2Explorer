using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

namespace Wlx2Explorer.Utils
{
    static class WindowUtils
    {
        public static IList<string> GetSelectedFilesFromForegroundExplorerWindow()
        {
            var hwndForeground = NativeMethods.GetForegroundWindow();
            var selectedFiles = GetSelectedFilesFromWindow(hwndForeground);
            return selectedFiles;
        }

        public static IList<string> GetSelectedFilesFromWindow(IntPtr hwnd)
        {
            var fileNames = new List<string>();
            var shellAppType = Type.GetTypeFromProgID("Shell.Application");
            var shellObject = Activator.CreateInstance(shellAppType);
            var shellWindows = (SHDocVw.ShellWindows)shellAppType.InvokeMember("Windows", BindingFlags.InvokeMethod, null, shellObject, new object[] { });
            foreach (SHDocVw.InternetExplorer window in shellWindows)
            {
                if (window.HWND == hwnd.ToInt32())
                {
                    var fileName = Path.GetFileNameWithoutExtension(window.FullName).ToLower();
                    if (fileName.ToLowerInvariant() == "explorer")
                    {
                        Shell32.FolderItems items = ((Shell32.IShellFolderViewDual2)window.Document).SelectedItems();
                        fileNames = items.Cast<Shell32.FolderItem>().Select(x => x.Path).ToList();
                    }
                }
            }
            return fileNames;
        }

        public static bool IsChildWindow(IntPtr hwnd, IntPtr parentHwnd)
        {
            var result = false;
            var currentHwnd = hwnd;
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