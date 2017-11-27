using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Database;
using Logic.Metadata;
using System.Threading;
using Logic.Models;
using Microsoft.Extensions.Configuration;

namespace Logic.DataManagement
{
	public class TaskInit
	{
		private readonly IUpdater _updater;
		public Receipt Receipt { get; set; }


		public TaskInit(IUpdater updater) => _updater = updater;


		public void OnListInitialized(object source, EventArgs e)
		{
			Thread thread = new Thread(new ThreadStart(() =>
			{
				_updater.UpdatePopularityRates(Receipt);
			}))
			{
				IsBackground = true
			};
			thread.Start();
		}
	}
}
