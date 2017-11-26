using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) => _context = context;

        public List<Product> GetFavoriteProducts()
        {
            var items = _dbEntity.OrderByDescending(x => x.Popularity).Take(5).ToList();
            return items;
        }

        public int UpdatePrices(string name, decimal price, short storeId)
        {
            try
            {
                var item = _dbEntity.SingleOrDefault(x => (x.Name == name && x.ShopID == storeId));
                if(item == null)
                {
                    return -1;
                }
                item.Price = (item.Price< price) ? item.Price : price;
                Save();
                return 0;
            }
            catch (Exception) // More than one element is found in sequence
            {
                return -2;
            }
        }

        public int UpdateRate(string name, short hits, short storeId)
        {
            try
            {
                var items = _dbEntity.SingleOrDefault(x => (x.Name == name && x.ShopID == storeId));
                if(items == null)
                {
                    return -1;
                }
                items.Popularity = (short)(items.Popularity + hits);
                Save();
                return 0;
            }
            catch (Exception)
            {
                return -2;
            }
        }
    }
}
