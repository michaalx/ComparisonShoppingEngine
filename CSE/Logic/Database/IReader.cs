using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Database
{
    public interface IReader
    {
        void CloseConnection();
        void OpenConnection();
        IEnumerable<string> ReadProductData();
        List<Tuple<DateTime, decimal>> ReadHistoryData(string productName, int storeName);
        List<Tuple<string, short, decimal, string>> ReadPopularity();
    }
}