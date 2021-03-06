﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.ExceptionServices;
using System.IO;
using System.Drawing.Printing;
using Wlx2Explorer.Utils;
using Wlx2Explorer.Settings;
using Wlx2Explorer.Native;
using Wlx2Explorer.Hooks;

namespace Wlx2Explorer.Forms
{
    partial class ListerForm : Form, IMessageFilter
    {
        private IntPtr _pluginHandle;
        private Plugin _plugin;
        private string _fileName;
        private ProgramSettings _settings;

        public ListerForm(ProgramSettings settings, IList<Plugin> plugins, string fileName)
        {
            InitializeComponent();

            bool pluginLoaded = TryToLoadPlugin(settings, plugins, fileName, out _pluginHandle, out _plugin);
            if (!pluginLoaded)
            {
                Close();
                return;
            }

            _settings = settings;
            _fileName = fileName;
            Text = "Lister - " + fileName;
            Width = settings.ListerFormWidth;
            Height = settings.ListerFormHeight;
            Opacity = 1.0;
            ShowInTaskbar = true;
            CenterToScreen();
            WindowState = settings.ListerFormMaximized ? FormWindowState.Maximized : WindowState;
            Application.AddMessageFilter(this);
        }

        [HandleProcessCorruptedStateExceptions]
        private bool TryToLoadPlugin(ProgramSettings settings, IList<Plugin> plugins, string fileName, out IntPtr pluginHandle, out Plugin plugin)
        {
            pluginHandle = IntPtr.Zero;
            plugin = null;
            foreach (var sourcePlugin in plugins)
            {
                try
                {
                    PluginInfo pluginInfo = settings.Plugins.FirstOrDefault(x => string.Compare(x.Path, sourcePlugin.ModuleName) == 0);
                    string extension = Path.GetExtension(fileName).TrimStart('.');
                    if (pluginInfo.Extensions.Count == 0 || pluginInfo.Extensions.Contains(extension.ToLower()) || pluginInfo.Extensions.Contains(extension.ToUpper()))
                    {
                        pluginHandle = sourcePlugin.ListLoad(pnlLister.Handle, fileName);
                    }
                }
                catch
                {
                }

                if (pluginHandle != IntPtr.Zero)
                {
                    plugin = sourcePlugin;
                    break;
                }
            }
            return pluginHandle != IntPtr.Zero;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            pnlLister.Focus();
            NativeMethods.SetFocus(_pluginHandle);
        }

        [HandleProcessCorruptedStateExceptions]
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            try
            {
                if (_plugin.ListCloseWindowExist)
                {
                    _plugin.ListCloseWindow(_pluginHandle);
                }
                else
                {
                    NativeMethods.DestroyWindow(_pluginHandle);
                }
                Application.RemoveMessageFilter(this);
            }
            catch
            {
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_pluginHandle == IntPtr.Zero) return;
            NativeMethods.SetWindowPos(_pluginHandle, new IntPtr(0), 0, 0, pnlLister.Width, pnlLister.Height, 0);
        }

        bool IMessageFilter.PreFilterMessage(ref Message m)
        {
            if (m.Msg == NativeConstants.WM_KEYDOWN && WindowUtils.IsChildWindow(m.HWnd, Handle))
            {
                if (m.WParam.ToInt32() == _settings.SearchDialogKey3)
                {
                    var key1 = true;
                    var key2 = true;

                    if ((VirtualKeyModifier)_settings.SearchDialogKey1 != VirtualKeyModifier.None)
                    {
                        int key1State = NativeMethods.GetAsyncKeyState(_settings.SearchDialogKey1) & 0x8000;
                        key1 = Convert.ToBoolean(key1State);
                    }

                    if ((VirtualKeyModifier)_settings.SearchDialogKey2 != VirtualKeyModifier.None)
                    {
                        int key2State = NativeMethods.GetAsyncKeyState(_settings.SearchDialogKey2) & 0x8000;
                        key2 = Convert.ToBoolean(key2State);
                    }

                    if (key1 && key2)
                    {
                        if (!_plugin.ListSearchDialogExist && !_plugin.ListSearchTextExist)
                        {
                            MessageBox.Show("This plugin does not support text search!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            if (_plugin.ListSearchDialogExist)
                            {
                                _plugin.ListSearchDialog(_pluginHandle, 0);
                            }
                            else
                            {
                                var searchDlg = new SearchForm();
                                var result = searchDlg.ShowDialog(this);
                                if (result == DialogResult.OK)
                                {
                                    var flags = 0;
                                    flags |= SearchForm.SearchFromBeginning ? NativeConstants.LCS_FINDFIRST : 0;
                                    flags |= SearchForm.SearchCaseSensitive ? NativeConstants.LCS_MATCHCASE : 0;
                                    flags |= SearchForm.SearchWholeWordsOnly ? NativeConstants.LCS_WHOLEWORDS : 0;
                                    flags |= SearchForm.SearchBackwards ? NativeConstants.LCS_BACKWARDS : 0;
                                    _plugin.ListSearchText(_pluginHandle, SearchForm.SearchingText, flags);
                                }
                            }
                    }
                }

                if (m.WParam.ToInt32() == _settings.PrintDialogKey3)
                {
                    var key1 = true;
                    var key2 = true;

                    if ((VirtualKeyModifier)_settings.PrintDialogKey1 != VirtualKeyModifier.None)
                    {
                        int key1State = NativeMethods.GetAsyncKeyState(_settings.PrintDialogKey1) & 0x8000;
                        key1 = Convert.ToBoolean(key1State);
                    }

                    if ((VirtualKeyModifier)_settings.PrintDialogKey2 != VirtualKeyModifier.None)
                    {
                        int key2State = NativeMethods.GetAsyncKeyState(_settings.PrintDialogKey2) & 0x8000;
                        key2 = Convert.ToBoolean(key2State);
                    }

                    if (key1 && key2)
                    {
                        if (!_plugin.ListPrintExist)
                        {
                            MessageBox.Show("This plugin does not support printing!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Rect rectangle = null;
                            PrinterSettings printerSettings = new PrinterSettings();
                            _plugin.ListPrint(_pluginHandle, _fileName, printerSettings.PrinterName, 0, ref rectangle);
                        }
                    }
                }

                if (m.WParam.ToInt32() == (int)VirtualKey.VK_F3)
                {
                    if (_plugin.ListSearchTextExist && !string.IsNullOrEmpty(SearchForm.SearchingText))
                    {
                        var flags = 0;
                        flags |= SearchForm.SearchFromBeginning ? NativeConstants.LCS_FINDFIRST : 0;
                        flags |= SearchForm.SearchCaseSensitive ? NativeConstants.LCS_MATCHCASE : 0;
                        flags |= SearchForm.SearchWholeWordsOnly ? NativeConstants.LCS_WHOLEWORDS : 0;
                        flags |= SearchForm.SearchBackwards ? NativeConstants.LCS_BACKWARDS : 0;
                        _plugin.ListSearchText(_pluginHandle, SearchForm.SearchingText, flags);
                    }
                }

                if (m.WParam.ToInt32() == (int)VirtualKey.VK_ESCAPE)
                {
                    Close();
                }
            }

            return false;
        }
    }
}