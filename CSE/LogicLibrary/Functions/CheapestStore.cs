using System;
using System.Collections.Generic;
using System.Linq;
using LogicLibrary.Metadata;
using LogicLibrary.Models;
using LogicLibrary.Database;
using System.Diagnostics;

namespace LogicLibrary.Functions
{
    public class CheapestStore : ICheapestStore
    {
        private readonly IDataModel _dataModel;

        public CheapestStore(IDataModel dataModel) => _dataModel = dataModel;

        public Tuple<Store, decimal> GetCheapestStore<T>(IEnumerable<T> products)
        {
            var lowestSumOfCart = decimal.MaxValue;
            var cheapestStore = (Store)(-1); //undefined store 
            var stores = GetStores();
            
            foreach (var store in stores)
            {
                var sumOfCart = 0m;
                var storeProducts = _dataModel.GetProducts(store);
                foreach(var product in products)
                {
                    var query = from record in storeProducts
                                where record.Item1.Trim() == product.ToString()
                                select record;
                    foreach (var matching in query)
                    {
                        sumOfCart += matching.Item2;
                    }
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
            return Tuple.Create(cheapestStore, lowestSumOfCart);
        }
        public static IEnumerable<Store> GetStores()
        {
           return Enum.GetValues(typeof(Store)).Cast<Store>().ToList();
        }
    }
}
