using LogicCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicCore.Database
{
    public interface IUpdater
    {
        int UpdatePopularityRates(Receipt receipt);
        int UpdatePrices(Receipt receipt);
    }
}
