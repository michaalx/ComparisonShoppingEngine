using System.Collections.Generic;
using System.Linq;
using Logic.Models;

namespace Logic.Functions
{
    class PopularProducts: IPopularProducts<Product>
    {
        /// <summary>
        /// Sketch method of getting list of popular products.
        /// Sketch, because we don't know so far, what type will 
        /// request to SQL return.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetPopularProducts()
        {
            ///Get from database "list" of product names and rates.
            ///pseudocode:
            ///SELECT name, rate FROM PRODUCTS
            ///ORDER BY rate DESCENDING
            ///
            var orderedList = new Dictionary<string, decimal>();
            var sqlResult = orderedList.Take(5);
            var productsList = new List<Product>();
            foreach(var query in sqlResult)
            {
                productsList.Add(new Product(query.Key, query.Value));
            }
            return productsList;
        }
    }
}
