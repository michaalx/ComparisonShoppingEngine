using System.Collections.Generic;
using Logic.Metadata;
using Logic.Models;
using System;

namespace Logic.Functions
{
    public interface ICheapestStore
    {
        Tuple<Store,decimal> GetCheapestStore<T>(IEnumerable<T> products);
    }
}
