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
			var reader = new Reader();
			Store store = Store.IKI;
			//reader.OpenConnection();
			//reader.CloseConnection();
			//reader.ReadHistoryData(store, "Pienas");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new StartForm());
		}
	}
}
