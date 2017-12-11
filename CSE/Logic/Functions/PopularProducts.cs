using System.Collections.Generic;
using Logic.Database;

namespace Logic.Functions
{
    public class PopularProducts : IPopularProducts
    {
        private readonly IDataModel _dataModel;

        public PopularProducts(IDataModel dataModel) => _dataModel = dataModel;

        public IEnumerable<string> GetPopularProducts()
        {
            var sqlResult = _dataModel.PopularProducts();
            var productsList = new List<string>();
            foreach(var query in sqlResult)
            {
              //  var storeName = (Store)Enum.Parse(typeof(Store), query.Item4);
                productsList.Add(query.Item1);
            }
            return productsList;
        }
    }
}
