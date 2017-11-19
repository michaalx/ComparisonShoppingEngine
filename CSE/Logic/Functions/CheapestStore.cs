using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Metadata;
using Logic.Models;

namespace Logic.Functions
{
    class CheapestStore : ICheapestStore<string>
    {
        public CheapestStore() { }

        public Store GetCheapestStore(IEnumerable<string> products)
        {
            var lowestSumOfCart = decimal.MaxValue;
            var cheapestStore = Store.Maxima;
            var stores = GetStores();
            foreach (var store in stores)
            {
                var sumOfCart = 0m;
                foreach(var product in products)
                {
                    ///Add price of product in this store to sum of cart.
                    ///We have to get list of products of store from database.
                    ///
                    ///pseudocode of getting price from database 
                    ///(should be extracted to Reader.cs file or sth like that):
                    ///SELECT price FROM ProductsTable 
                    ///WHERE product = productName AND store.ToString() = storeName
                    ///
                    ///sumOfCart+= price.Take(1).ToString();
                    sumOfCart += 0;
                }
                if (sumOfCart < lowestSumOfCart)
                {
                    cheapestStore = store;
                    lowestSumOfCart = sumOfCart;
                }
            }
            return cheapestStore;
        }
        public IEnumerable<Store> GetStores()
        {
            return Enum.GetValues(typeof(Store)).Cast<Store>().ToList();
        }
    }
}
