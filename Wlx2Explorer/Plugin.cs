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
        #region Fields.Private

        private IntPtr _moduleHandle;
        private delegate IntPtr LoadPluginDelegate(IntPtr hwndParent, string fileName, int flags);
        private delegate void UnloadPluginDelegate(IntPtr hwndList);
        private delegate void GetDetectStringDelegate(StringBuilder detectString, int size);
        private delegate void NotificationReceivedDelegate(IntPtr hwndList, int message, IntPtr wParam, IntPtr lParam);
        private delegate void SetDefaultParamsDelegate(ListDefaultParamStruct defaultParams);
        private delegate int SearchTextDelegate(IntPtr hwndList, string searchString, int flags);
        private delegate int SearchDialogDelegate(IntPtr hwndList, int flags);
        private delegate int PrintDelegate(IntPtr hwndList, string fileName, string printerName, int flags, ref Rect margins);

        #endregion


        #region Properties.Private

        public string ModuleName
        {
            get;
            private set;
        }

        public bool IsLoadPluginFunctionExist
        {
            get
            {
                var function = (LoadPluginDelegate)LoadFunction<LoadPluginDelegate>("ListLoad");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public bool IsUnloadPluginFunctionExist
        {
            get
            {
                var function = (UnloadPluginDelegate)LoadFunction<UnloadPluginDelegate>("ListCloseWindow");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public bool IsGetDetectStringFunctionExist
        {
            get
            {
                var function = (GetDetectStringDelegate)LoadFunction<GetDetectStringDelegate>("ListGetDetectString");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public bool IsNotificationReceivedFunctionExist
        {
            get
            {
                var function = (NotificationReceivedDelegate)LoadFunction<NotificationReceivedDelegate>("ListNotificationReceived");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public bool IsSetDefaultParamsFunctionExist
        {
            get
            {
                var function = (SetDefaultParamsDelegate)LoadFunction<SetDefaultParamsDelegate>("ListSetDefaultParams");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public bool IsSearchTextFunctionExist
        {
            get
            {
                var function = (SearchTextDelegate)LoadFunction<SearchTextDelegate>("ListSearchText");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public bool IsSearchDialogFunctionExist
        {
            get
            {
                var function = (SearchDialogDelegate)LoadFunction<SearchDialogDelegate>("ListSearchDialog");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public bool IsPrintFunctionExist
        {
            get
            {
                var function = (PrintDelegate)LoadFunction<PrintDelegate>("ListPrint");
                var functionExist = function != null;
                return functionExist;
            }
        }


        #endregion


        #region Methods.Public

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
            if (_moduleHandle == IntPtr.Zero) return true;
            var result = NativeMethods.FreeLibrary(_moduleHandle);
            return result;
        }

        public IntPtr LoadPlugin(IntPtr hwndParent, string fileName)
        {
            var function = (LoadPluginDelegate)LoadFunction<LoadPluginDelegate>("ListLoad");
            var hwndPlugin = function(hwndParent, fileName, 0);
            return hwndPlugin;
        }

        public void UnloadPlugin(IntPtr hwndList)
        {
            var function = (UnloadPluginDelegate)LoadFunction<UnloadPluginDelegate>("ListCloseWindow");
            function(hwndList);
        }

        public string GetDetectString()
        {
            var function = (GetDetectStringDelegate)LoadFunction<GetDetectStringDelegate>("ListGetDetectString");
            var detectString = new StringBuilder(1024 * 10);
            function(detectString, detectString.Capacity);
            return detectString.ToString();
        }

        public void NotificationReceived(IntPtr hwndList, int message, IntPtr wParam, IntPtr lParam)
        {
            var function = (NotificationReceivedDelegate)LoadFunction<NotificationReceivedDelegate>("ListNotificationReceived");
            function(hwndList, message, wParam, lParam);
        }

        public void SetDefaultParams(int interfaceVersionLow, int interfaceVersionHigh, string iniFile)
        {
            var function = (SetDefaultParamsDelegate)LoadFunction<SetDefaultParamsDelegate>("ListSetDefaultParams");
            var defaultParams = new ListDefaultParamStruct();
            defaultParams.interfaceVersionLow = interfaceVersionLow;
            defaultParams.interfaceVersionHigh = interfaceVersionHigh;
            defaultParams.defaultIniFile = iniFile;
            defaultParams.size = Marshal.SizeOf(defaultParams);
            function(defaultParams);
        }

        public int SearchText(IntPtr hwndList, string searchString, int flags)
        {
            var function = (SearchTextDelegate)LoadFunction<SearchTextDelegate>("ListSearchText");
            var result = function(hwndList, searchString, flags);
            return result;
        }

        public int SearchDialog(IntPtr hwndList, int flags)
        {
            var function = (SearchDialogDelegate)LoadFunction<SearchDialogDelegate>("ListSearchDialog");
            var result = function(hwndList, flags);
            return result;
        }

        public int Print(IntPtr hwndList, string fileName, string printerName, int flags, ref Rect margins)
        {
            var function = (PrintDelegate)LoadFunction<PrintDelegate>("ListPrint");
            var result = function(hwndList, fileName, printerName, flags, ref margins);
            return result;
        }

        [HandleProcessCorruptedStateExceptions]
        public static string[] GetSupportedExtensions(string fileName)
        {
            try
            {
                var plugin = new Plugin(fileName);
                var pluginLoaded = plugin.LoadModule();
                if (!pluginLoaded) return new string[0];
                var detectString = plugin.IsGetDetectStringFunctionExist ? plugin.GetDetectString() : string.Empty;
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

        #endregion


        #region Methods.Private

        private Delegate LoadFunction<T>(string functionName)
        {
            if (_moduleHandle == IntPtr.Zero) throw new Exception("Plugin module is not loaded.");
            var functionAddress = NativeMethods.GetProcAddress(_moduleHandle, functionName);
            if (functionAddress == IntPtr.Zero) return null;
            var function = Marshal.GetDelegateForFunctionPointer(functionAddress, typeof(T));
            return function;
        }

        #endregion
    }
}