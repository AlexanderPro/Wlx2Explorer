using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Wlx2Explorer.App_Code.Common;

namespace Wlx2Explorer.App_Code.Forms
{
    public partial class TestForm : Form
    {
        private const String _pluginFile = @"C:\Projects\Wlx2Explorer\Plugins\sumatrapdf\SumatraPDF.wlx";
        private const String _file = @"C:\Books\1.pdf";


        private Plugin _plugin;
        private IntPtr _pluginHandle;

        public TestForm()
        {
            InitializeComponent();
            Opacity = 1.0;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Maximized;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _plugin = new Plugin(_pluginFile);
            _plugin.LoadModule();
            _pluginHandle = _plugin.LoadPlugin(panel1.Handle, _file);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_pluginHandle == IntPtr.Zero) return;
            NativeMethods.SetWindowPos(_pluginHandle, new IntPtr(0), 0, 0, panel1.Width, panel1.Height, 0);
        }

        private void LoadModuleClick(object sender, EventArgs e)
        {
            _plugin = new Plugin(_pluginFile);
            _plugin.LoadModule();
        }

        private void UnLoadModuleClick(object sender, EventArgs e)
        {
            _plugin.UnloadModule();
        }

        private void ListLoadClick(object sender, EventArgs e)
        {
            _pluginHandle = _plugin.LoadPlugin(panel1.Handle, _file);
        }

        private void ListCloseClick(object sender, EventArgs e)
        {
            _plugin.UnloadPlugin(_pluginHandle);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeConstants.WM_COMMAND:
                case NativeConstants.WM_NOTIFY:
                case NativeConstants.WM_MEASUREITEM:
                case NativeConstants.WM_DRAWITEM:
                    {
                        if (_plugin.IsNotificationReceivedFunctionExist)
                        {
                            _plugin.NotificationReceived(_pluginHandle, m.Msg, m.WParam, m.LParam);
                        }
                    } break;
            }
            base.WndProc(ref m);
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
