using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;
using Wlx2Explorer.Native;

namespace Wlx2Explorer.Utils
{
    static class WindowUtils
    {
        public static string GetSelectedFileFromDesktopOrExplorer()
        {
            var hwnd = NativeMethods.GetForegroundWindow();
            var className = GetClassName(hwnd);
            if (className == "WorkerW" || className == "Progman")
            {
                var hwndSysListView32 = GetSysListView32();
                var fileName = GetSelectedFileFromDesktop(hwndSysListView32);
                return fileName;
            }
            else
            {
                var fileName = GetSelectedFileFromExplorer(hwnd);
                return fileName;
            }
        }

        private static string GetSelectedFileFromExplorer(IntPtr hwnd)
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
                        var items = ((Shell32.IShellFolderViewDual2)window.Document).SelectedItems();
                        fileNames = items.Cast<Shell32.FolderItem>().Select(x => x.Path).ToList();
                    }
                }
            }
            return fileNames.Any() ? fileNames[0] : string.Empty;
        }

        private static string GetSelectedFileFromDesktop(IntPtr hwnd)
        {
            var processPointer = IntPtr.Zero;
            var virtualAllocPointer = IntPtr.Zero;
            try
            {
                var itemNames = new List<string>();
                var processId = (uint)0;
                NativeMethods.GetWindowThreadProcessId(hwnd, out processId);
                var itemCount = NativeMethods.SendMessage(hwnd, NativeConstants.LVM_GETITEMCOUNT, 0, 0);
                processPointer = NativeMethods.OpenProcess(NativeConstants.PROCESS_VM_OPERATION | NativeConstants.PROCESS_VM_READ | NativeConstants.PROCESS_VM_WRITE, false, processId);
                virtualAllocPointer = NativeMethods.VirtualAllocEx(processPointer, IntPtr.Zero, 4096, NativeConstants.MEM_RESERVE | NativeConstants.MEM_COMMIT, NativeConstants.PAGE_READWRITE);

                for (int i = 0; i < itemCount; i++)
                {
                    var buffer = new byte[256];
                    var item = new LVITEM[1];
                    item[0].mask = NativeConstants.LVIF_TEXT;
                    item[0].iItem = i;
                    item[0].iSubItem = 0;
                    item[0].cchTextMax = buffer.Length;
                    item[0].pszText = (IntPtr)((int)virtualAllocPointer + Marshal.SizeOf(typeof(LVITEM)));
                    var numberOfBytesRead = (uint)0;

                    NativeMethods.WriteProcessMemory(processPointer, virtualAllocPointer, Marshal.UnsafeAddrOfPinnedArrayElement(item, 0), Marshal.SizeOf(typeof(LVITEM)), ref numberOfBytesRead);
                    NativeMethods.SendMessage(hwnd, NativeConstants.LVM_GETITEMW, i, virtualAllocPointer.ToInt32());
                    NativeMethods.ReadProcessMemory(processPointer, (IntPtr)((int)virtualAllocPointer + Marshal.SizeOf(typeof(LVITEM))), Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0), buffer.Length, ref numberOfBytesRead);

                    var text = Encoding.Unicode.GetString(buffer, 0, (int)numberOfBytesRead);
                    text = text.Substring(0, text.IndexOf('\0'));
                    var result = NativeMethods.SendMessage(hwnd, NativeConstants.LVM_GETITEMSTATE, i, (int)NativeConstants.LVIS_SELECTED);
                    if (result == NativeConstants.LVIS_SELECTED)
                    {
                        itemNames.Add(text);
                    }
                }

                if (itemNames.Any())
                {
                    var desktopDirectoryName = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    var commonDesktopDirectoryName = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
                    var itemName = itemNames[0];
                    var fileNames = Directory.GetFiles(desktopDirectoryName, itemName + ".*").ToList();
                    fileNames.AddRange(Directory.GetFiles(commonDesktopDirectoryName, itemName + ".*"));
                    if (fileNames.Any())
                    {
                        var fileName = fileNames[0];
                        if (Path.GetExtension(fileName).ToLower() == ".lnk")
                        {
                            WshShell shell = new WshShell();
                            IWshShortcut link = (IWshShortcut)shell.CreateShortcut(fileName);
                            return link.TargetPath;
                        }
                        return fileName;
                    }
                }
                return string.Empty;
            }
            finally
            {
                if (processPointer != IntPtr.Zero && virtualAllocPointer != IntPtr.Zero)
                {
                    NativeMethods.VirtualFreeEx(processPointer, virtualAllocPointer, 0, NativeConstants.MEM_RELEASE);
                }

                if (processPointer != IntPtr.Zero)
                {
                    NativeMethods.CloseHandle(processPointer);
                }
            }
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

        public static string GetClassName(IntPtr hwnd)
        {
            var builder = new StringBuilder(1024);
            NativeMethods.GetClassName(hwnd, builder, builder.Capacity);
            var className = builder.ToString();
            return className;
        }

        public static IntPtr GetSysListView32()
        {
            if (Environment.OSVersion.Version.Major == 5)
            {
                var hwndProgman = NativeMethods.FindWindow("Progman", null);
                var hwndShell = NativeMethods.FindWindowEx(hwndProgman, IntPtr.Zero, "SHELLDLL_DefView", null);
                var hwnd = NativeMethods.FindWindowEx(hwndShell, IntPtr.Zero, "SysListView32", "FolderView");
                return hwnd;
            }
            else
            {
                var hwnd = IntPtr.Zero;
                NativeMethods.EnumWindows(new NativeMethods.EnumWindowProc((tophandle, topparamhandle) =>
                {
                    var parent = NativeMethods.FindWindowEx(tophandle, IntPtr.Zero, "SHELLDLL_DefView", null);
                    if (parent != IntPtr.Zero)
                    {
                        hwnd = NativeMethods.FindWindowEx(parent, IntPtr.Zero, "SysListView32", null);
                        return false;
                    }

                    return true;
                }), IntPtr.Zero);
                return hwnd;
            }
        }
    }
} 