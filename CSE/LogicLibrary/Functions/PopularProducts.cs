using System.Collections.Generic;
using LogicLibrary.Models;
using LogicLibrary.Database;
using LogicLibrary.Metadata;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LogicLibrary.Functions
{
    public class PopularProducts : IPopularProducts
    {
        private readonly IDataModel _dataModel;

        public PopularProducts(IDataModel dataModel) => _dataModel = dataModel;

        public IEnumerable<Product> GetPopularProducts()
        {
            var sqlResult = _dataModel.PopularProducts();
            var productsList = new List<Product>();
            foreach(var query in sqlResult)
            {
              //  var storeName = (Store)Enum.Parse(typeof(Store), query.Item4);
                productsList.Add(new Product(query.Item1, query.Item3, query.Item2, query.Item4));
            }
            return productsList;
        }
    }
}
