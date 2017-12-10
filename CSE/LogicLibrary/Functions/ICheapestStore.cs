using System.Collections.Generic;
using LogicLibrary.Metadata;
using LogicLibrary.Models;
using System;

namespace LogicLibrary.Functions
{
    public interface ICheapestStore
    {
        Tuple<Store,decimal> GetCheapestStore<T>(IEnumerable<T> products);
    }
}
