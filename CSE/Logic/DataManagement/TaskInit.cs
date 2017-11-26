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
		private readonly IReader _reader;
		private readonly IConfiguration _configuration;
		public Receipt receipt { get; set; }

		
		public void OnListInitialized(object source, EventArgs e)
		{
			ThreadStart update = new ThreadStart(UpdateThread);
			Thread thread = new Thread(update);
		}

		
		public void UpdateThread()
		{
			DataModel dm = new DataModel(_reader);
			var updater = new Updater(_configuration);
			updater.UpdatePopularityRates(Receipt);	
		}
	}
}
