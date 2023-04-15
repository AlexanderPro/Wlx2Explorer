using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Linq;
using Wlx2Explorer.Forms;
using Wlx2Explorer.Utils;
using Wlx2Explorer.Settings;

namespace Wlx2Explorer
{
    static class Program
    {
        private static Mutex _mutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainUnhandledException;
            Application.ThreadException += OnThreadException;
            Environment.CurrentDirectory = AssemblyUtils.AssemblyDirectory;

            // Command Line Interface
            var toggleParser = new ToggleParser(args);
            if (toggleParser.HasToggle("h") || toggleParser.HasToggle("help"))
            {
                var messageBoxForm = new MessageBoxForm();
                messageBoxForm.Message = BuildHelpString();
                messageBoxForm.Text = "Help";
                messageBoxForm.ShowDialog();
                return;
            }

            if (toggleParser.HasToggle("f") || toggleParser.HasToggle("file"))
            {
                var suppressmsg = toggleParser.HasToggle("f") || toggleParser.HasToggle("suppressmsg");
                var fileName = toggleParser.GetToggleValueOrDefault("f", null) ?? toggleParser.GetToggleValueOrDefault("file", null);
                if (!File.Exists(fileName))
                {
                    if (!suppressmsg)
                    {
                        MessageBox.Show($"{fileName} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ProgramSettings settings;
                    try
                    {
                        settings = ProgramSettings.Read();
                    }
                    catch
                    {
                        if (!suppressmsg)
                        {
                            MessageBox.Show("Failed to read a program setting file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }

                    var plugins = new List<Plugin>();
                    foreach (var pluginInfo in settings.Plugins)
                    {
                        var plugin = new Plugin(pluginInfo.Path);
                        var pluginLoaded = false;
                        var pluginInitialized = true;

                        try
                        {
                            pluginLoaded = plugin.LoadModule();
                        }
                        catch
                        {
                            pluginLoaded = false;
                        }

                        try
                        {
                            if (plugin.ListSetDefaultParamsExist)
                            {
                                var pluginExtension = Path.GetExtension(pluginInfo.Path);
                                var pluginIniFile = Path.GetFullPath(pluginInfo.Path).Replace(pluginExtension, ".ini");
                                if (!File.Exists(pluginIniFile))
                                {
                                    plugin.ListSetDefaultParams(settings.PluginLowVersion, settings.PluginHighVersion, settings.PluginIniFile);
                                }
                            }
                        }
                        catch
                        {
                            pluginInitialized = false;
                        }

                        if (pluginLoaded && pluginInitialized)
                        {
                            plugins.Add(plugin);
                        }
                        else if (!pluginLoaded)
                        {
                            if (!suppressmsg)
                            {
                                MessageBox.Show($@"Failed to load the plugin {Environment.NewLine} ""{pluginInfo.Path}"".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            if (!suppressmsg)
                            {
                                MessageBox.Show($@"Failed to initialize the plugin with default settings {Environment.NewLine} ""{pluginInfo.Path}"".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    if (plugins.Any())
                    {
                        var listerForm = new ListerForm(settings, plugins, fileName);
                        listerForm.ShowDialog();
                    }
                }
                return;
            }

            var mutexName = "Wlx2Explorer";
            _mutex = new Mutex(false, mutexName, out var createNew);
            if (!createNew)
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void OnCurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            ex = ex ?? new Exception("OnCurrentDomainUnhandledException");
            OnThreadException(sender, new ThreadExceptionEventArgs(ex));
        }

        static void OnThreadException(object sender, ThreadExceptionEventArgs e) =>
            MessageBox.Show(e.Exception.ToString(), AssemblyUtils.AssemblyProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        static string BuildHelpString() =>
@"-h --help             The help
-f --file             Path to file
-s --suppressmsg      Suppress messages

Example:
Wlx2Explorer.exe -s --file ""C:\Temp\Image.jpeg""";
    }
}
