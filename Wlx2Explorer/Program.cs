using System;
using System.Windows.Forms;
using System.Threading;
using Wlx2Explorer.Forms;


namespace Wlx2Explorer
{
    static class Program
    {
        private static Mutex _mutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
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
    }
}
