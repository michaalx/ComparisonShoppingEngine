using System;
using System.Windows.Forms;
using CSE.FrontEnd;
using Logic.Database;

namespace CSE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			var dm = new DataModel();
			var list = dm.ProductData;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}
