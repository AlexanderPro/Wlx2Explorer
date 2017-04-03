using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Wlx2Explorer.Code.Common
{
    static class WindowsExplorerUtilities
    {
        public static IList<String> GetSelectedFilesFromForegroundExplorerWindow()
        {
            var hwndForeground = NativeMethods.GetForegroundWindow();
            var selectedFiles = GetSelectedFilesFromWindow(hwndForeground);
            return selectedFiles;
        }

        public static IList<String> GetSelectedFilesFromWindow(IntPtr hwnd)
        {
            var fileNames = new List<String>();
            Type shellAppType = Type.GetTypeFromProgID("Shell.Application");
            Object shellObject = Activator.CreateInstance(shellAppType);
            SHDocVw.ShellWindows shellWindows = (SHDocVw.ShellWindows)shellAppType.InvokeMember("Windows", BindingFlags.InvokeMethod, null, shellObject, new object[] { });
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
    }
}
