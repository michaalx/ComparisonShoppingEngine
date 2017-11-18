using System;
using System.Windows.Forms;
using CSE.FrontEnd;
using Logic.ImageAnalysis;

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
			var tp = new TextProcessing();
			var list = tp.ProductDB;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}