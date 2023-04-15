using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;
using System.Text;
using Wlx2Explorer.Utils;

namespace Wlx2Explorer.Settings
{
    class ProgramSettings
    {
        public IList<PluginInfo> Plugins { get; set; }

        public int ListerFormKey1 { get; set; }

        public int ListerFormKey2 { get; set; }

        public int ListerFormKey3 { get; set; }

        public int SearchDialogKey1 { get; set; }

        public int SearchDialogKey2 { get; set; }

        public int SearchDialogKey3 { get; set; }

        public int PrintDialogKey1 { get; set; }

        public int PrintDialogKey2 { get; set; }

        public int PrintDialogKey3 { get; set; }

        public int ListerFormWidth { get; set; }

        public int ListerFormHeight { get; set; }

        public bool ListerFormMaximized { get; set; }

        public bool AutoStartProgram { get; set; }

        public int PluginHighVersion { get; set; }

        public int PluginLowVersion { get; set; }

        public string PluginIniFile { get; set; }


        public ProgramSettings()
        {
            Plugins = new List<PluginInfo>();
        }

        public static ProgramSettings Read()
        {
            var fileName = AssemblyUtils.AssemblyFileNameWithoutExtension + ".xml";
            fileName = Path.Combine(AssemblyUtils.AssemblyDirectory, fileName);
            var document = XDocument.Load(fileName);
            var settings = Read(document);
            return settings;
        }

        public static ProgramSettings Read(XDocument document) => new ProgramSettings
        {
            ListerFormKey1 = int.Parse(document.XPathSelectElement("//Settings/ListerFormHotKeys").Attribute("key1").Value),
            ListerFormKey2 = int.Parse(document.XPathSelectElement("//Settings/ListerFormHotKeys").Attribute("key2").Value),
            ListerFormKey3 = int.Parse(document.XPathSelectElement("//Settings/ListerFormHotKeys").Attribute("key3").Value),
            SearchDialogKey1 = int.Parse(document.XPathSelectElement("//Settings/SearchDialogHotKeys").Attribute("key1").Value),
            SearchDialogKey2 = int.Parse(document.XPathSelectElement("//Settings/SearchDialogHotKeys").Attribute("key2").Value),
            SearchDialogKey3 = int.Parse(document.XPathSelectElement("//Settings/SearchDialogHotKeys").Attribute("key3").Value),
            PrintDialogKey1 = int.Parse(document.XPathSelectElement("//Settings/PrintDialogHotKeys").Attribute("key1").Value),
            PrintDialogKey2 = int.Parse(document.XPathSelectElement("//Settings/PrintDialogHotKeys").Attribute("key2").Value),
            PrintDialogKey3 = int.Parse(document.XPathSelectElement("//Settings/PrintDialogHotKeys").Attribute("key3").Value),
            ListerFormMaximized = bool.Parse(document.XPathSelectElement("//Settings/ListerForm").Attribute("maximized").Value),
            ListerFormWidth = int.Parse(document.XPathSelectElement("//Settings/ListerForm").Attribute("width").Value),
            ListerFormHeight = int.Parse(document.XPathSelectElement("//Settings/ListerForm").Attribute("height").Value),
            PluginHighVersion = int.Parse(document.XPathSelectElement("//Settings/PluginDefaultSettings").Attribute("highVersion").Value),
            PluginLowVersion = int.Parse(document.XPathSelectElement("//Settings/PluginDefaultSettings").Attribute("lowVersion").Value),
            PluginIniFile = new FileInfo(document.XPathSelectElement("//Settings/PluginDefaultSettings").Attribute("iniFile").Value).FullName,
            Plugins = document.XPathSelectElements("//Settings/Plugins/Plugin")
            .Select(el => new PluginInfo(el.Attribute("path").Value, string.IsNullOrWhiteSpace(el.Attribute("extensions").Value) ? new List<string>() : el.Attribute("extensions").Value.Split(';').ToList())).ToList()
        };

        public static void Write(ProgramSettings settings)
        {
            var fileName = AssemblyUtils.AssemblyFileNameWithoutExtension + ".xml";
            fileName = Path.Combine(AssemblyUtils.AssemblyDirectory, fileName);
            Write(settings, fileName);
        }

        public static void Write(ProgramSettings settings, string fileName)
        {
            var document = new XDocument(new XDeclaration("1.0", "utf-8", null),
                                new XElement("Settings",
                                    new XElement("Plugins", settings.Plugins.Select(x => new XElement("Plugin",
                                        new XAttribute("path", x.Path),
                                        new XAttribute("extensions", string.Join(";", x.Extensions.ToArray()))))),
                                    new XElement("ListerFormHotKeys",
                                        new XAttribute("key1", settings.ListerFormKey1.ToString()),
                                        new XAttribute("key2", settings.ListerFormKey2.ToString()),
                                        new XAttribute("key3", settings.ListerFormKey3.ToString())),
                                    new XElement("SearchDialogHotKeys",
                                        new XAttribute("key1", settings.SearchDialogKey1.ToString()),
                                        new XAttribute("key2", settings.SearchDialogKey2.ToString()),
                                        new XAttribute("key3", settings.SearchDialogKey3.ToString())),
                                    new XElement("PrintDialogHotKeys",
                                        new XAttribute("key1", settings.PrintDialogKey1.ToString()),
                                        new XAttribute("key2", settings.PrintDialogKey2.ToString()),
                                        new XAttribute("key3", settings.PrintDialogKey3.ToString())),
                                    new XElement("ListerForm",
                                        new XAttribute("maximized", settings.ListerFormMaximized.ToString()),
                                        new XAttribute("width", settings.ListerFormWidth.ToString()),
                                        new XAttribute("height", settings.ListerFormHeight.ToString())),
                                    new XElement("PluginDefaultSettings",
                                        new XAttribute("highVersion", settings.PluginHighVersion.ToString()),
                                        new XAttribute("lowVersion", settings.PluginLowVersion.ToString()),
                                        new XAttribute("iniFile", settings.PluginIniFile))));

            Save(document, fileName);
        }

        private static void Save(XDocument document, string fileName)
        {
            using (TextWriter writer = new Utf8StringWriter())
            {
                document.Save(writer, SaveOptions.None);
                File.WriteAllText(fileName, writer.ToString());
            }
        }

        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }
    }
}
