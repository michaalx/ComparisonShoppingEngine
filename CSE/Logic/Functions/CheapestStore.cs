using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Metadata;
using Logic.Models;

namespace Logic.Functions
{
    static class CheapestStore
    {
        public static Tuple<Store,decimal> GetCheapestStore(IEnumerable<Product> products)
        {
            var listOfProducts = Enumerable.Empty<Product>();
            return listOfProducts.GtCheapestStore();
        }
        public static Tuple<Store,decimal> GtCheapestStore(this IEnumerable<Product> products)
        {
            var lowestSumOfCart = decimal.MaxValue;
            var cheapestStore = (Store)(-1); //undefined store 
            var stores = GetStores();
            foreach (var store in stores)
            {
                var sumOfCart = 0m;
                foreach (var product in products)
                {
                    ///Add price of product in this store to sum of cart.
                    ///We have to get list of products of store from database.
                    ///
                    ///pseudocode of getting price from database 
                    ///(should be extracted to Reader.cs file or sth like that):
                    ///SELECT price FROM PRODUCTS 
                    ///WHERE product.ToString() = productName AND store.ToString() = storeName
                    ///
                    ///sumOfCart+= price.Take(1).ToString();
                    sumOfCart += 0;
                }
                ///If none products of store are found in database .
                ///Sum will be 0 but it is pointless to define this store 
                ///as it doesn't contain given products.
                if (sumOfCart < lowestSumOfCart && sumOfCart != 0)
                {
                    cheapestStore = store;
                    lowestSumOfCart = sumOfCart;
                }
            }
            return new Tuple<Store,decimal>(cheapestStore, lowestSumOfCart);
        }
        public static IEnumerable<Store> GetStores()
        {
           return Enum.GetValues(typeof(Store)).Cast<Store>().ToList();
        }
    }
}
