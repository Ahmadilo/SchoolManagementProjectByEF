using SchoolManagementSystem.WinForm.Apps;
using SchoolManagementSystem.WinForm.Gates;
using SchoolManagementSystem.WinForm.Reports;
using System;
using System.Windows.Forms;

namespace SchoolManagementSystem.WinForm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmReoprtSelecter());
        }
    }
}
