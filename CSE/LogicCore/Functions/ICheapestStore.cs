using LogicCore.Metadata;
using System;
using System.Collections.Generic;

namespace LogicCore.Functions
{
    public interface ICheapestStore
    {
        Tuple<Store, decimal> GetCheapestStore<T>(IEnumerable<T> products);
    }
}
