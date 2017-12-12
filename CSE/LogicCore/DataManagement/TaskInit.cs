using LogicCore.Database;
using LogicCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LogicCore.DataManagement
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
