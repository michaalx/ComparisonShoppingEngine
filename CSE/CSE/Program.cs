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
			//FOR TESTING

			int store = (int)Store.IKI;
			var dm = new DataModel();
			var history = dm.HistoryData("Pienas", store);

			foreach (Tuple<DateTime, decimal> e in history)
				Console.WriteLine(e.Item1.ToString() + " " + e.Item2.ToString());

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new StartForm());
		}
	}
}
