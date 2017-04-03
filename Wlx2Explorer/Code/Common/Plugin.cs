using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;

namespace Wlx2Explorer.Code.Common
{
    class Plugin
    {
        #region Fields.Private

        private IntPtr _moduleHandle;
        private delegate IntPtr LoadPluginDelegate(IntPtr hwndParent, String fileName, Int32 flags);
        private delegate void UnloadPluginDelegate(IntPtr hwndList);
        private delegate void GetDetectStringDelegate(StringBuilder detectString, Int32 size);
        private delegate void NotificationReceivedDelegate(IntPtr hwndList, Int32 message, IntPtr wParam, IntPtr lParam);
        private delegate void SetDefaultParamsDelegate(ListDefaultParamStruct defaultParams);
        private delegate Int32 SearchTextDelegate(IntPtr hwndList, String searchString, Int32 flags);
        private delegate Int32 SearchDialogDelegate(IntPtr hwndList, Int32 flags);
        private delegate Int32 PrintDelegate(IntPtr hwndList, String fileName, String printerName, Int32 flags, ref Rect margins);

        #endregion


        #region Properties.Private

        public String ModuleName
        {
            get;
            private set;
        }

        public Boolean IsLoadPluginFunctionExist
        {
            get
            {
                var function = (LoadPluginDelegate)LoadFunction<LoadPluginDelegate>("ListLoad");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public Boolean IsUnloadPluginFunctionExist
        {
            get
            {
                var function = (UnloadPluginDelegate)LoadFunction<UnloadPluginDelegate>("ListCloseWindow");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public Boolean IsGetDetectStringFunctionExist
        {
            get
            {
                var function = (GetDetectStringDelegate)LoadFunction<GetDetectStringDelegate>("ListGetDetectString");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public Boolean IsNotificationReceivedFunctionExist
        {
            get
            {
                var function = (NotificationReceivedDelegate)LoadFunction<NotificationReceivedDelegate>("ListNotificationReceived");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public Boolean IsSetDefaultParamsFunctionExist
        {
            get
            {
                var function = (SetDefaultParamsDelegate)LoadFunction<SetDefaultParamsDelegate>("ListSetDefaultParams");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public Boolean IsSearchTextFunctionExist
        {
            get
            {
                var function = (SearchTextDelegate)LoadFunction<SearchTextDelegate>("ListSearchText");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public Boolean IsSearchDialogFunctionExist
        {
            get
            {
                var function = (SearchDialogDelegate)LoadFunction<SearchDialogDelegate>("ListSearchDialog");
                var functionExist = function != null;
                return functionExist;
            }
        }

        public Boolean IsPrintFunctionExist
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

        public Plugin(String moduleName)
        {
            ModuleName = moduleName;
            _moduleHandle = IntPtr.Zero;
        }

        public Boolean LoadModule()
        {
            UnloadModule();
            _moduleHandle = NativeMethods.LoadLibrary(ModuleName);
            var result = _moduleHandle != IntPtr.Zero;
            return result;
        }

        public Boolean UnloadModule()
        {
            if (_moduleHandle == IntPtr.Zero) return true;
            var result = NativeMethods.FreeLibrary(_moduleHandle);
            return result;
        }

        public IntPtr LoadPlugin(IntPtr hwndParent, String fileName)
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

        public String GetDetectString()
        {
            var function = (GetDetectStringDelegate)LoadFunction<GetDetectStringDelegate>("ListGetDetectString");
            var detectString = new StringBuilder(1024 * 10);
            function(detectString, detectString.Capacity);
            return detectString.ToString();
        }

        public void NotificationReceived(IntPtr hwndList, Int32 message, IntPtr wParam, IntPtr lParam)
        {
            var function = (NotificationReceivedDelegate)LoadFunction<NotificationReceivedDelegate>("ListNotificationReceived");
            function(hwndList, message, wParam, lParam);
        }

        public void SetDefaultParams(Int32 interfaceVersionLow, Int32 interfaceVersionHigh, String iniFile)
        {
            var function = (SetDefaultParamsDelegate)LoadFunction<SetDefaultParamsDelegate>("ListSetDefaultParams");
            var defaultParams = new ListDefaultParamStruct();
            defaultParams.interfaceVersionLow = interfaceVersionLow;
            defaultParams.interfaceVersionHigh = interfaceVersionHigh;
            defaultParams.defaultIniFile = iniFile;
            defaultParams.size = Marshal.SizeOf(defaultParams);
            function(defaultParams);
        }

        public Int32 SearchText(IntPtr hwndList, String searchString, Int32 flags)
        {
            var function = (SearchTextDelegate)LoadFunction<SearchTextDelegate>("ListSearchText");
            var result = function(hwndList, searchString, flags);
            return result;
        }

        public Int32 SearchDialog(IntPtr hwndList, Int32 flags)
        {
            var function = (SearchDialogDelegate)LoadFunction<SearchDialogDelegate>("ListSearchDialog");
            var result = function(hwndList, flags);
            return result;
        }

        public Int32 Print(IntPtr hwndList, String fileName, String printerName, Int32 flags, ref Rect margins)
        {
            var function = (PrintDelegate)LoadFunction<PrintDelegate>("ListPrint");
            var result = function(hwndList, fileName, printerName, flags, ref margins);
            return result;
        }

        [HandleProcessCorruptedStateExceptions]
        public static String[] GetSupportedExtensions(String fileName)
        {
            try
            {
                var plugin = new Plugin(fileName);
                var pluginLoaded = plugin.LoadModule();
                if (!pluginLoaded) return new String[0];
                var detectString = plugin.IsGetDetectStringFunctionExist ? plugin.GetDetectString() : String.Empty;
                var regExp = new Regex("EXT=\\\"(\\w+)\\\"", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                var matches = regExp.Matches(detectString);
                var result = matches.Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
                plugin.UnloadModule();
                return result;
            }
            catch
            {
                return new String[0];
            }
        }

        #endregion


        #region Methods.Private

        private Delegate LoadFunction<T>(String functionName)
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