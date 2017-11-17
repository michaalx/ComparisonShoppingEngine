using System;
using System.Windows.Forms;
using CSE.FrontEnd;

using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

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
				Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}