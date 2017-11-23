using System;
using System.Collections.Generic;

namespace Logic.Database
{
    public interface IDataModel
    {
        List<Tuple<DateTime, decimal>> HistoryData(string productName, int storeName);
        IEnumerable<Tuple<string, short, decimal, string>> PopularProducts();
    }
}