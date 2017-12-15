using System;
using System.Collections.Generic;

namespace Business.Features
{
    public interface IGraphData
    {
        Dictionary<DateTime, decimal> GetDaysList(string item, int storeNum);
        List<string> GetProducts(int storeNum);
        List<string> GetStores();
    }
}
