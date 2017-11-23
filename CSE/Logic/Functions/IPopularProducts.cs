using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Functions
{
    public interface IPopularProducts
    {
        IEnumerable<Product> GetPopularProducts();
    }
}
