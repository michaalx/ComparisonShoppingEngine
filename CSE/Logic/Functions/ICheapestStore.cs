using System.Collections.Generic;
using Logic.Metadata;
using Logic.Models;
using System;

namespace Logic.Functions
{
    interface ICheapestStore
    {
        Tuple<Store,decimal> GetCheapestStore<T>(IEnumerable<T> products);
    }
}
