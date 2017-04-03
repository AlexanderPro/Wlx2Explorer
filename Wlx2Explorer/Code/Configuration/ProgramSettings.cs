using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;
using System.Text;
using Wlx2Explorer.Code.Common;

namespace Wlx2Explorer.Code.Configuration
{
    class ProgramSettings
    {
        #region Properties.Public

        public IList<PluginInfo> Plugins { get; set; }

        public Int32 ListerFormKey1 { get; set; }

        public Int32 ListerFormKey2 { get; set; }

        public Int32 ListerFormKey3 { get; set; }

        public Int32 SearchDialogKey1 { get; set; }

        public Int32 SearchDialogKey2 { get; set; }

        public Int32 SearchDialogKey3 { get; set; }

        public Int32 PrintDialogKey1 { get; set; }

        public Int32 PrintDialogKey2 { get; set; }

        public Int32 PrintDialogKey3 { get; set; }

        public Int32 ListerFormWidth { get; set; }

        public Int32 ListerFormHeight { get; set; }

        public Boolean ListerFormMaximized { get; set; }

        public Boolean AutoStartProgram { get; set; }

        public Int32 PluginHighVersion { get; set; }

        public Int32 PluginLowVersion { get; set; }

        public String PluginIniFile { get; set; }

        #endregion

        
        #region Methods.Public

        public ProgramSettings()
        {
            Plugins = new List<PluginInfo>();
        }

        public static ProgramSettings Read()
        {
            var fileName = AssemblyUtilities.AssemblyFileNameWithoutExtension + ".xml";
            fileName = Path.Combine(AssemblyUtilities.AssemblyDirectory, fileName);
            var settings = Read(fileName);
            return settings;
        }

        public static ProgramSettings Read(String fileName)
        {
            var document = XDocument.Load(fileName);
            var settings = new ProgramSettings();
            settings.ListerFormKey1 = Int32.Parse(document.XPathSelectElement("//Settings/ListerFormHotKeys").Attribute("key1").Value);
            settings.ListerFormKey2 = Int32.Parse(document.XPathSelectElement("//Settings/ListerFormHotKeys").Attribute("key2").Value);
            settings.ListerFormKey3 = Int32.Parse(document.XPathSelectElement("//Settings/ListerFormHotKeys").Attribute("key3").Value);
            settings.SearchDialogKey1 = Int32.Parse(document.XPathSelectElement("//Settings/SearchDialogHotKeys").Attribute("key1").Value);
            settings.SearchDialogKey2 = Int32.Parse(document.XPathSelectElement("//Settings/SearchDialogHotKeys").Attribute("key2").Value);
            settings.SearchDialogKey3 = Int32.Parse(document.XPathSelectElement("//Settings/SearchDialogHotKeys").Attribute("key3").Value);
            settings.PrintDialogKey1 = Int32.Parse(document.XPathSelectElement("//Settings/PrintDialogHotKeys").Attribute("key1").Value);
            settings.PrintDialogKey2 = Int32.Parse(document.XPathSelectElement("//Settings/PrintDialogHotKeys").Attribute("key2").Value);
            settings.PrintDialogKey3 = Int32.Parse(document.XPathSelectElement("//Settings/PrintDialogHotKeys").Attribute("key3").Value);
            settings.ListerFormMaximized = Boolean.Parse(document.XPathSelectElement("//Settings/ListerForm").Attribute("maximized").Value);
            settings.ListerFormWidth = Int32.Parse(document.XPathSelectElement("//Settings/ListerForm").Attribute("width").Value);
            settings.ListerFormHeight = Int32.Parse(document.XPathSelectElement("//Settings/ListerForm").Attribute("height").Value);
            settings.PluginHighVersion = Int32.Parse(document.XPathSelectElement("//Settings/PluginDefaultSettings").Attribute("highVersion").Value);
            settings.PluginLowVersion = Int32.Parse(document.XPathSelectElement("//Settings/PluginDefaultSettings").Attribute("lowVersion").Value);
            settings.PluginIniFile = document.XPathSelectElement("//Settings/PluginDefaultSettings").Attribute("iniFile").Value;
            settings.PluginIniFile = new FileInfo(settings.PluginIniFile).FullName;
            settings.Plugins = document.XPathSelectElements("//Settings/Plugins/Plugin").Select(el => new PluginInfo(el.Attribute("path").Value,
                                                                                                                     String.IsNullOrWhiteSpace(el.Attribute("extensions").Value) ? new List<String>() :
                                                                                                                                                                              el.Attribute("extensions").Value.Split(';').ToList())).ToList();
            return settings;
        }

        public static void Write(ProgramSettings settings)
        {
            var fileName = AssemblyUtilities.AssemblyFileNameWithoutExtension + ".xml";
            fileName = Path.Combine(AssemblyUtilities.AssemblyDirectory, fileName);
            Write(settings, fileName);
        }

        public static void Write(ProgramSettings settings, String fileName)
        {
            var document = new XDocument(new XDeclaration("1.0", "utf-8", null),
                                new XElement("Settings",
                                    new XElement("Plugins", settings.Plugins.Select(x => new XElement("Plugin",
                                        new XAttribute("path", x.Path),
                                        new XAttribute("extensions", String.Join(";", x.Extensions.ToArray()))))),
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

        #endregion


        #region Methods.Private

        private static void Save(XDocument document, String fileName)
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

        #endregion
    }
}
