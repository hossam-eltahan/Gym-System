using System;
using System.Windows.Forms;
using WindowsFormsApp;

namespace WindowsFormsApp2
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
            Application.Run(new viewmember()); // تأكد أن Form1 موجودة ومُعرفة
        }
    }
}

