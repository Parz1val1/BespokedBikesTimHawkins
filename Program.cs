using System;
using System.Windows.Forms;
using BespokedBikesTimHawkins.Database;
using BespokedBikesTimHawkins.UI;

namespace BespokedBikesTimHawkins
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
            Application.Run(new BeSpokedBikesForm());
        }
    }
}
