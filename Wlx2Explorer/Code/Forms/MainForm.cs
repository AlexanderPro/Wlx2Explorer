using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Wlx2Explorer.Code.Common;
using Wlx2Explorer.Code.Configuration;

namespace Wlx2Explorer.Code.Forms
{
    partial class MainForm : Form
    {
        private IList<Plugin> _plugins;
        private KeyboardHook _keyboardKook;
        private ProgramSettings _settings;
        private ListerForm _listerForm;
        private AboutForm _aboutForm;
        private ProgramSettingsForm _settingsForm;
        private Boolean _isProgramStarted;

        public MainForm()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainUnhandledException;
            Application.ThreadException += OnThreadException;

            Environment.CurrentDirectory = AssemblyUtils.AssemblyDirectory;
            iconSystemTray.Text = AssemblyUtils.AssemblyTitle;

            Start();
            ChangeMenuStartStopText();
        }

        protected override void OnLoad(EventArgs e)
        {
            BeginInvoke(new Action(Hide));
            base.OnLoad(e);
        }

        private void Start()
        {
            Environment.CurrentDirectory = AssemblyUtils.AssemblyDirectory;
            _isProgramStarted = false;
            try
            {
                _settings = ProgramSettings.Read();
            }
            catch
            {
                MessageBox.Show("Failed to read a program setting file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_listerForm != null && _listerForm.IsHandleCreated)
            {
                _listerForm.Close();
            }

            _plugins = _plugins ?? new List<Plugin>();
            foreach (var plugin in _plugins)
            {
                try
                {
                    plugin.UnloadModule();
                }
                catch
                {
                    var message = String.Format("Failed to unload a plugin \"{0}\".", plugin.ModuleName);
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _plugins.Clear();

            foreach (var pluginInfo in _settings.Plugins)
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
                    if (plugin.IsSetDefaultParamsFunctionExist)
                    {
                        var pluginExtension = Path.GetExtension(pluginInfo.Path);
                        var pluginIniFile = Path.GetFullPath(pluginInfo.Path).Replace(pluginExtension, ".ini");
                        if (!File.Exists(pluginIniFile))
                        {
                            plugin.SetDefaultParams(_settings.PluginLowVersion, _settings.PluginHighVersion, _settings.PluginIniFile);
                        }
                    }
                }
                catch
                {
                    pluginInitialized = false;
                }

                if (pluginLoaded && pluginInitialized)
                {
                    _plugins.Add(plugin);
                }
                else
                    if (!pluginLoaded)
                    {
                        var message = String.Format("Failed to load the plugin {0} \"{1}\".", Environment.NewLine, pluginInfo.Path);
                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var message = String.Format("Failed to initialize the plugin with default settings {0} \"{1}\".", Environment.NewLine, pluginInfo.Path);
                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }

            try
            {
                _keyboardKook = _keyboardKook ?? new KeyboardHook();
                _keyboardKook.Stop();
                _keyboardKook.Hooked -= KeyHooked;
                _keyboardKook.Hooked += KeyHooked;
                Boolean result = _keyboardKook.Start(_settings.ListerFormKey1, _settings.ListerFormKey2, _settings.ListerFormKey3);
                if (!result) throw new Exception("Failed to run a keyboard hook.");
                _isProgramStarted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Stop()
        {
            if (_listerForm != null && _listerForm.IsHandleCreated)
            {
                _listerForm.Close();
            }

            _plugins = _plugins ?? new List<Plugin>();
            foreach (var plugin in _plugins)
            {
                try
                {
                    plugin.UnloadModule();
                }
                catch
                {
                    var message = String.Format("Failed to unload a plugin \"{0}\".", plugin.ModuleName);
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _plugins.Clear();
            _keyboardKook = _keyboardKook ?? new KeyboardHook();
            _keyboardKook.Stop();
            _keyboardKook.Hooked -= KeyHooked;
            _isProgramStarted = false;
        }

        private void KeyHooked(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ShowListerForm));
            }
            else
            {
                ShowListerForm();
            }
        }

        private void ShowListerForm()
        {
            IList<String> files = new List<String>();
            try
            {
                files = ExplorerUtils.GetSelectedFilesFromForegroundExplorerWindow();
            }
            catch
            {
                MessageBox.Show("Failed to get selected file in windows explorer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (files.Count != 1) return;

            Environment.CurrentDirectory = AssemblyUtils.AssemblyDirectory;

            if (_listerForm != null && _listerForm.IsHandleCreated)
            {
                _listerForm.Close();
            }

            if (_listerForm == null || _listerForm.IsDisposed)
            {
                _listerForm = new ListerForm(_settings, _plugins, files[0]);
            }

            if (_listerForm.IsDisposed)
            {
                _listerForm = null;
            }
            else
            {
                _listerForm.Show();
                _listerForm.Activate();
            }
        }

        private void MenuItemStartStopClick(object sender, EventArgs e)
        {
            if (_isProgramStarted)
            {
                Stop();
            }
            else
            {
                Start();
            }
            ChangeMenuStartStopText();
        }

        private void MenuItemSettingsClick(object sender, EventArgs e)
        {
            if (_settingsForm == null || _settingsForm.IsDisposed || !_settingsForm.IsHandleCreated)
            {
                if (_settings != null)
                {
                    _settings.AutoStartProgram = AutoStarter.IsAutoStartEnabled(AssemblyUtils.AssemblyProductName, AssemblyUtils.AssemblyLocation);
                }
                Environment.CurrentDirectory = AssemblyUtils.AssemblyDirectory;
                _settingsForm = new ProgramSettingsForm(_settings);
            }

            if (!_settingsForm.Visible)
            {
                DialogResult result = _settingsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        ProgramSettings.Write(_settingsForm.Settings);
                    }
                    catch
                    {
                        MessageBox.Show("Failed to save program settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_settingsForm.Settings.AutoStartProgram)
                    {
                        AutoStarter.SetAutoStart(AssemblyUtils.AssemblyProductName, AssemblyUtils.AssemblyLocation);
                    }
                    else
                        if (AutoStarter.IsAutoStartEnabled(AssemblyUtils.AssemblyProductName, AssemblyUtils.AssemblyLocation))
                        {
                            AutoStarter.UnsetAutoStart(AssemblyUtils.AssemblyProductName);
                        }
                    Stop();
                    Start();
                }
            }
        }

        private void MenuItemAboutClick(object sender, EventArgs e)
        {
            if (_aboutForm == null || _aboutForm.IsDisposed || !_aboutForm.IsHandleCreated)
            {
                _aboutForm = new AboutForm();
            }
            _aboutForm.Show();
            _aboutForm.Activate();
        }

        private void MenuItemExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangeMenuStartStopText()
        {
            if (_isProgramStarted)
            {
                miStartStop.Image = Wlx2Explorer.Properties.Resources.Stop;
                miStartStop.Text = "Stop";
            }
            else
            {
                miStartStop.Image = Wlx2Explorer.Properties.Resources.Start;
                miStartStop.Text = "Start";
            }
        }

        private void OnCurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            ex = ex ?? new Exception("OnCurrentDomainUnhandledException");
            OnThreadException(sender, new ThreadExceptionEventArgs(ex));
        }

        private void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), AssemblyUtils.AssemblyProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
