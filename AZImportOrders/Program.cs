using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AZImportOrders
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                Application.Run(new frmMain(args[0]));
            }
            else
            {
                Application.Run(new frmMain("UNKNOW"));
            }
        }
    }
}
