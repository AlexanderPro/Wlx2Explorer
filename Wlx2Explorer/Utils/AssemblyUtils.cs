﻿using System.Reflection;
using System.IO;
using System.Linq;

namespace Wlx2Explorer.Utils
{
    static class AssemblyUtils
    {
        public static string AssemblyLocation => Assembly.GetExecutingAssembly().Location;

        public static string AssemblyDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string AssemblyFileNameWithoutExtension => Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);

        public static string AssemblyTitle => Assembly
            .GetExecutingAssembly()
            .GetCustomAttributes(typeof(AssemblyTitleAttribute), false)
            .OfType<AssemblyTitleAttribute>()
            .FirstOrDefault()?.Title ?? string.Empty;


        public static string AssemblyProductName => Assembly
            .GetExecutingAssembly()
            .GetCustomAttributes(typeof(AssemblyProductAttribute), false)
            .OfType<AssemblyProductAttribute>()
            .FirstOrDefault()?.Product ?? string.Empty;


        public static string AssemblyProductVersion
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return $"{version.Major}.{version.Minor}.{version.Build}";
            }
        }
    }
}
