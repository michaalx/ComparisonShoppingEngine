using System;
using System.Collections.Generic;
using System.Linq;
using DataBase.Context;

namespace Business.Features
{
    public class FavoriteProducts : IFavoriteProducts
    {
        private readonly DataContext _dataContext;

        public FavoriteProducts(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<string> GetFavoriteProducts()
        {
            using(_dataContext)
            {
                var productList = _dataContext.Records
                    .Where(record => (DateTime.Now - record.TimeStamp).TotalDays <= 7)
                    .Join(_dataContext.Products,
                        record => record.ProductId,
                        product => product.Id,
                        ( record, product) => 
                        new
                        {
                            record.Quantity,
                            product.Name
                        })
                    .GroupBy(x => x.Name)
                    .Select(grouping => 
                        new
                        {
                            key= grouping.Key,
                            quantitySum = grouping.Sum(x => x.Quantity)
                        })
                    .OrderByDescending(x => x.quantitySum).Select(x => x.key)
                    .Skip(0)
                    .Take(5)
                    .ToList();
                return productList;
            }
        }
    }
}
