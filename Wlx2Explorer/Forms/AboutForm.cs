using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using Wlx2Explorer.Utils;

namespace Wlx2Explorer.Forms
{
    partial class AboutForm : Form
    {
        private const string URL = "http://illarionov.pro";

        public AboutForm()
        {
            InitializeComponent();
            Text = "About " + AssemblyUtils.AssemblyProductName;
            lblProductName.Text = string.Format("{0} v{1}", AssemblyUtils.AssemblyProductName, AssemblyUtils.AssemblyVersion); ;
            lblProductTitle.Text = AssemblyUtils.AssemblyTitle;
            lblCopyright.Text = "Copyright © 2014 - " + DateTime.Now.Year;
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
            CloseClick(sender, (EventArgs)e);
        }
    }
}
