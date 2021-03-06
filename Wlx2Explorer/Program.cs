﻿using System;
using System.Windows.Forms;
using System.Diagnostics;
using Wlx2Explorer.Extensions;
using Wlx2Explorer.Forms;

namespace Wlx2Explorer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Process.GetCurrentProcess().ExistProcessWithSameNameAndDesktop()) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
