using System;
using System.Diagnostics;
using System.Windows.Forms;
using Wlx2Explorer.Utils;

namespace Wlx2Explorer.Forms
{
    partial class AboutForm : Form
    {
        private const string URL = "https://github.com/AlexanderPro/Wlx2Explorer";

        public AboutForm()
        {
            InitializeComponent();
            Text = $"About {AssemblyUtils.AssemblyProductName}";
            lblProductName.Text = $"{AssemblyUtils.AssemblyProductName} v{AssemblyUtils.AssemblyProductVersion}";
            lblProductTitle.Text = AssemblyUtils.AssemblyTitle;
            lblCopyright.Text = $"Copyright © 2014 - {DateTime.Now.Year}";
            linkUrl.Text = URL;
        }

        private void CloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void LinkClick(object sender, EventArgs e)
        {
            Process.Start(URL);
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            CloseClick(sender, e);
        }
    }
}
