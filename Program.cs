using System;
using System.Windows.Forms;

namespace Log_File_Reader_and_Plotter
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
            //Application.Run(new FormChartSettings());
            Application.Run(new FormPlotter());
        }
    }
}
