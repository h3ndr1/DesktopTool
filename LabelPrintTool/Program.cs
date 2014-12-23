using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace CodeX.DesktopTool.Print
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool isLicensed = ValidateLicense();
            if (isLicensed)
            {
                Application.Run(new MainForm(isLicensed)); 
            }
        }


        private static bool ValidateLicense()
        {
            string fileName = string.Format(@"{0}\{1}", Application.StartupPath, "ronin.snk");
            FileInfo file = new FileInfo(fileName);
            if (!file.Exists)
            {
                MessageBox.Show("Illegal copy", "CodeX - Label Printing Utility Utility - License Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
