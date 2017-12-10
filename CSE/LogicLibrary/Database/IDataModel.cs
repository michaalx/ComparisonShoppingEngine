using System;
using System.Collections.Generic;
using LogicLibrary.Metadata;

namespace LogicLibrary.Database
{
    public interface IDataModel
    {
        IEnumerable<string> ProductData { get; }

        IEnumerable<string> GetAllStores();
        List<Tuple<string, decimal>> GetProducts(Store store);
        List<Tuple<DateTime, decimal>> HistoryData(string productName, int storeName);
        List<string> OneStore(int shopId);
        IEnumerable<Tuple<string, short, decimal, string>> PopularProducts();
    }
}