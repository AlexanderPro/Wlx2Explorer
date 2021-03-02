using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;
using Wlx2Explorer.Native;

namespace Wlx2Explorer
{
    class Plugin
    {
        private IntPtr _moduleHandle;
        private delegate IntPtr ListLoadDelegate(IntPtr hwndParent, string fileName, int flags);
        private delegate void ListCloseWindowDelegate(IntPtr hwndList);
        private delegate void ListGetDetectStringDelegate(StringBuilder detectString, int size);
        private delegate void ListNotificationReceivedDelegate(IntPtr hwndList, int message, IntPtr wParam, IntPtr lParam);
        private delegate void ListSetDefaultParamsDelegate(ListDefaultParamStruct defaultParams);
        private delegate int ListSearchTextDelegate(IntPtr hwndList, string searchString, int flags);
        private delegate int ListSearchDialogDelegate(IntPtr hwndList, int flags);
        private delegate int ListPrintDelegate(IntPtr hwndList, string fileName, string printerName, int flags, ref Rect margins);

        private delegate IntPtr ListLoadWDelegate(IntPtr hwndParent, [MarshalAs(UnmanagedType.LPTStr)] string fileName, int flags);
        private delegate int ListSearchTextWDelegate(IntPtr hwndList, [MarshalAs(UnmanagedType.LPTStr)] string searchString, int flags);
        private delegate int ListPrintWDelegate(IntPtr hwndList, [MarshalAs(UnmanagedType.LPTStr)] string fileName, [MarshalAs(UnmanagedType.LPTStr)] string printerName, int flags, ref Rect margins);


        public string ModuleName
        {
            get;
            private set;
        }

        public bool ListCloseWindowExist
        {
            get
            {
                var listCloseWindow = (ListCloseWindowDelegate)LoadFunction<ListCloseWindowDelegate>("ListCloseWindow");
                var exist = listCloseWindow != null;
                return exist;
            }
        }

        public bool ListGetDetectStringExist
        {
            get
            {
                var listGetDetectString = (ListGetDetectStringDelegate)LoadFunction<ListGetDetectStringDelegate>("ListGetDetectString");
                var exist = listGetDetectString != null;
                return exist;
            }
        }

        public bool ListSetDefaultParamsExist
        {
            get
            {
                var listSetDefaultParams = (ListSetDefaultParamsDelegate)LoadFunction<ListSetDefaultParamsDelegate>("ListSetDefaultParams");
                var exist = listSetDefaultParams != null;
                return exist;
            }
        }

        public bool ListSearchTextExist
        {
            get
            {
                var listSearchTextW = (ListSearchTextWDelegate)LoadFunction<ListSearchTextWDelegate>("ListSearchTextW");
                var listSearchText = (ListSearchTextDelegate)LoadFunction<ListSearchTextDelegate>("ListSearchText");
                var exist = listSearchTextW != null || listSearchText != null;
                return exist;
            }
        }

        public bool ListSearchDialogExist
        {
            get
            {
                var listSearchDialog = (ListSearchDialogDelegate)LoadFunction<ListSearchDialogDelegate>("ListSearchDialog");
                var exist = listSearchDialog != null;
                return exist;
            }
        }

        public bool ListPrintExist
        {
            get
            {
                var listPrintW = (ListPrintWDelegate)LoadFunction<ListPrintWDelegate>("ListPrintW");
                var listPrint = (ListPrintDelegate)LoadFunction<ListPrintDelegate>("ListPrint");
                var exist = listPrintW != null || listPrint != null;
                return exist;
            }
        }


        public Plugin(string moduleName)
        {
            ModuleName = moduleName;
            _moduleHandle = IntPtr.Zero;
        }

        public bool LoadModule()
        {
            UnloadModule();
            _moduleHandle = NativeMethods.LoadLibrary(ModuleName);
            var result = _moduleHandle != IntPtr.Zero;
            return result;
        }

        public bool UnloadModule()
        {
            if (_moduleHandle == IntPtr.Zero)
            {
                return true;
            }
            var result = NativeMethods.FreeLibrary(_moduleHandle);
            return result;
        }

        public IntPtr ListLoad(IntPtr hwndParent, string fileName)
        {
            var listLoadW = (ListLoadWDelegate)LoadFunction<ListLoadWDelegate>("ListLoadW");
            if (listLoadW != null)
            {
                var hwnd = listLoadW(hwndParent, fileName, 0);
                return hwnd;
            }
            else
            {
                var listLoad = (ListLoadDelegate)LoadFunction<ListLoadDelegate>("ListLoad");
                if (listLoad == null)
                {
                    return IntPtr.Zero;
                }
                var hwnd = listLoad(hwndParent, fileName, 0);
                return hwnd;
            }
        }

        public void ListCloseWindow(IntPtr hwndList)
        {
            var function = (ListCloseWindowDelegate)LoadFunction<ListCloseWindowDelegate>("ListCloseWindow");
            function(hwndList);
        }

        public string ListGetDetectString()
        {
            var function = (ListGetDetectStringDelegate)LoadFunction<ListGetDetectStringDelegate>("ListGetDetectString");
            var detectString = new StringBuilder(1024 * 10);
            function(detectString, detectString.Capacity);
            return detectString.ToString();
        }

        public void ListNotificationReceived(IntPtr hwndList, int message, IntPtr wParam, IntPtr lParam)
        {
            var function = (ListNotificationReceivedDelegate)LoadFunction<ListNotificationReceivedDelegate>("ListNotificationReceived");
            function(hwndList, message, wParam, lParam);
        }

        public void ListSetDefaultParams(int interfaceVersionLow, int interfaceVersionHigh, string iniFile)
        {
            var function = (ListSetDefaultParamsDelegate)LoadFunction<ListSetDefaultParamsDelegate>("ListSetDefaultParams");
            var defaultParams = new ListDefaultParamStruct();
            defaultParams.interfaceVersionLow = interfaceVersionLow;
            defaultParams.interfaceVersionHigh = interfaceVersionHigh;
            defaultParams.defaultIniFile = iniFile;
            defaultParams.size = Marshal.SizeOf(defaultParams);
            function(defaultParams);
        }

        public int ListSearchText(IntPtr hwndList, string searchString, int flags)
        {
            var listSearchTextW = (ListSearchTextWDelegate)LoadFunction<ListSearchTextWDelegate>("ListSearchTextW");
            if (listSearchTextW != null)
            {
                var result = listSearchTextW(hwndList, searchString, flags);
                return result;
            }
            else
            {
                var listSearchText = (ListSearchTextDelegate)LoadFunction<ListSearchTextDelegate>("ListSearchText");
                var result = listSearchText(hwndList, searchString, flags);
                return result;
            }
        }

        public int ListSearchDialog(IntPtr hwndList, int flags)
        {
            var function = (ListSearchDialogDelegate)LoadFunction<ListSearchDialogDelegate>("ListSearchDialog");
            var result = function(hwndList, flags);
            return result;
        }

        public int ListPrint(IntPtr hwndList, string fileName, string printerName, int flags, ref Rect margins)
        {
            var listPrintW = (ListPrintWDelegate)LoadFunction<ListPrintWDelegate>("ListPrintW");
            if (listPrintW != null)
            {
                var result = listPrintW(hwndList, fileName, printerName, flags, ref margins);
                return result;

            }
            else
            {
                var listPrint = (ListPrintDelegate)LoadFunction<ListPrintDelegate>("ListPrint");
                var result = listPrint(hwndList, fileName, printerName, flags, ref margins);
                return result;
            }
        }

        [HandleProcessCorruptedStateExceptions]
        public static string[] GetSupportedExtensions(string fileName)
        {
            try
            {
                var plugin = new Plugin(fileName);
                var pluginLoaded = plugin.LoadModule();
                if (!pluginLoaded) return new string[0];
                var detectString = plugin.ListGetDetectStringExist ? plugin.ListGetDetectString() : string.Empty;
                var regExp = new Regex("EXT=\\\"(\\w+)\\\"", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                var matches = regExp.Matches(detectString);
                var result = matches.Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
                plugin.UnloadModule();
                return result;
            }
            catch
            {
                return new string[0];
            }
        }

        private Delegate LoadFunction<T>(string functionName)
        {
            if (_moduleHandle == IntPtr.Zero) throw new Exception("Plugin module is not loaded.");
            var functionAddress = NativeMethods.GetProcAddress(_moduleHandle, functionName);
            if (functionAddress == IntPtr.Zero)
            {
                return null;
            }
            var function = Marshal.GetDelegateForFunctionPointer(functionAddress, typeof(T));
            return function;
        }
    }
}