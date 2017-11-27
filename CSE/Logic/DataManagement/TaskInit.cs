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
        //private readonly IConfiguration _configuration;
        public Receipt Receipt { get; set; }

        public void OnListInitialized(object source, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(() =>
               {
                   DataModel dm = new DataModel(_reader);
                   //var updater = new Updater(_configuration);
                   //updater.UpdatePopularityRates(Receipt);
               }));
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
