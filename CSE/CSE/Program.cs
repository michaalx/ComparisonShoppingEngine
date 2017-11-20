using System;
using System.Windows.Forms;
using CSE.FrontEnd;
using Logic.Database;
using Logic.Metadata;

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
