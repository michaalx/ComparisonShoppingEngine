using System;
using System.Collections.Generic;
using Logic.Metadata;

namespace Logic.Database
{
    public interface IReader
    {
        void CloseConnection();
        void OpenConnection();
        List<Tuple<string, decimal>> ReadForCheapest(Store store);
        List<Tuple<DateTime, decimal>> ReadHistoryData(string productName, int storeName);
        List<string> ReadOneStore(int storeId);
        List<Tuple<string, short, decimal, string>> ReadPopularity();
        IEnumerable<string> ReadProductData();
    }
}