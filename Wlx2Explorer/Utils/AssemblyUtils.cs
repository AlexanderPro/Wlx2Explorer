using System.Reflection;
using System.IO;

namespace Wlx2Explorer.Utils
{
    static class AssemblyUtils
    {
        public static string AssemblyLocation
        {
            get
            {
                var location = Assembly.GetExecutingAssembly().Location;
                return location;
            }
        }

        public static string AssemblyDirectory
        {
            get
            {
                var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return directory;
            }
        }

        public static string AssemblyFileName
        {
            get
            {
                var directory = Path.GetFileName(Assembly.GetExecutingAssembly().Location);
                return directory;
            }
        }

        public static string AssemblyFileNameWithoutExtension
        {
            get
            {
                var directory = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location);
                return directory;
            }
        }

        public static string AssemblyTitle
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                var title = ((AssemblyTitleAttribute)attributes[0]).Title;
                return title;
            }
        }

        public static string AssemblyProductName
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                var productName = ((AssemblyProductAttribute)attributes[0]).Product;
                return productName;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                var copyright = ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
                return copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                var company = ((AssemblyCompanyAttribute)attributes[0]).Company;
                return company;
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                return version;
            }
        }

        public static void ExtractFileFromAssembly(string resourceName, string path)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var outputFileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var resouceStream = currentAssembly.GetManifestResourceStream(resourceName);
            resouceStream.CopyTo(outputFileStream);
            resouceStream.Close();
            outputFileStream.Close();
        }
    }
}
