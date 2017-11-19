using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Metadata;
using Logic.Models;

namespace Logic.Functions
{
    interface ICheapestStore<T>
    {
        Store GetCheapestStore(IEnumerable<T> products);
    }
}
