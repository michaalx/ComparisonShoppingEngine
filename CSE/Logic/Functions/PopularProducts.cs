using System.Collections.Generic;
using Logic.Models;
using Logic.Database;
using Logic.Metadata;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using DataAccess.Repositories;

namespace Logic.Functions
{
    public class PopularProducts : IPopularProducts
    {
        private readonly IDataModel _dataModel;
        private readonly IProductRepository _productRepository;

        public PopularProducts(IDataModel dataModel) => _dataModel = dataModel;

        public PopularProducts(IProductRepository productRepository) => _productRepository = productRepository;

        public IEnumerable<Product> GetPopularProducts()
        {
          //  var sqlResult = _dataModel.PopularProducts();
            var productsList = new List<Product>();
            /*foreach(var query in sqlResult)
            {
              //  var storeName = (Store)Enum.Parse(typeof(Store), query.Item4);
                productsList.Add(new Product(query.Item1, query.Item3, query.Item2, query.Item4));
            }
            */
            var items = _productRepository.GetFavoriteProducts();
            foreach(var item in items)
            {
                productsList.Add(new Product(item.Name,item.Price));
            }

            return productsList;
        }
    }
}
