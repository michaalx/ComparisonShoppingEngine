using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSE.FrontEnd;
using System.Diagnostics;

namespace CSE.BackEnd
{
    class DataToolkit
    {
        private CSV _csvHelper;
        private CheapestStore _cheapestStore;
        public DataToolkit()
        {
            _csvHelper = new CSV();
            _cheapestStore = new CheapestStore();
        }
        public List<Tuple<string, string, decimal>> PreparePopularProducts()
        {
            List<Tuple<string,string,decimal>> result = new List<Tuple<string, string, decimal>>();
            var popularProducts = GetPopularProducts(5);
            foreach(var item in popularProducts)
            {
                KeyValuePair<string,decimal> partialResult = _cheapestStore.GetCheapestStoreForOneProduct(item.Key);
                result.Add(new Tuple<string, string, decimal>(item.Key,partialResult.Key,partialResult.Value));
            }
            return result;

        }
        public List<KeyValuePair<string, int>> GetPopularProducts(int quantity)
        {
            return _csvHelper.GetAllProductsByPopularity().Take(quantity).ToList();
        }
    }
}
