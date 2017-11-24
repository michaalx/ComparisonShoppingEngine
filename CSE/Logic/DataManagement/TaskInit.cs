using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Database;
using Logic.Metadata;
using System.Threading;
using Logic.Models;

namespace Logic.DataManagement
{
	public class TaskInit
	{
		public Receipt receipt;
		public Receipt Receipt { get; set; }

		public void OnListInitialized(object source, EventArgs e)
		{
			ThreadStart update = new ThreadStart(UpdateThread);
			Thread thread = new Thread(update);
		}

		public void UpdateThread()
		{

			Store store = Store.Iki;
			DataModel dm = new DataModel();
			dm.GetProducts(store);
			var updater = new Updater();
			updater.UpdatePopularityRates(receipt);
		}
	}
}
