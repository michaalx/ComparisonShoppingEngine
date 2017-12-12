using LogicCore.Models;
using System.Collections.Generic;

namespace LogicCore.Functions
{
    public interface IPopularProducts
    {
        IEnumerable<Product> GetPopularProducts();
    }
}
