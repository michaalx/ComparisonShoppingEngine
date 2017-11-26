using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public  interface IProductRepository : IRepository<Product>
    {
        int UpdateRate(string name, short hits, short storeId);
        int UpdatePrices(string name, decimal price, short storeId);
        List<Product> GetFavoriteProducts();
    }
}
