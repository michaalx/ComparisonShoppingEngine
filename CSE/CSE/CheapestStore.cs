using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSE
{
    public class CheapestStore
    {
        Dictionary<string, decimal> countDictionary = new Dictionary<string, decimal>();
        DataDistributionAmongFiles ddaf = new DataDistributionAmongFiles();
        CSV csvtool = new CSV();

        //Extracting store name from filepath (there should be another way to do it, maybe with enum)
        public string GetStoreName(string file)
        {
            return Regex.Match(file, @".*\\([^\\]+(?=\.))").Groups[1].Value;
        }

        public string GetCheapestStore(ListView cart)
        {
            countDictionary.Clear();
            var allstores = new Dictionary<string, List<Product>>();
            List<Product> uniqueStoreList = new List<Product>();
            string[] paths = ddaf.GetFilesPaths();
            foreach(var file in paths)
            {
                var filename = GetStoreName(file);
                uniqueStoreList = csvtool.ParsingForChosenItems(cart, file);
                if(uniqueStoreList.Count == cart.Items.Count)
                    allstores.Add(filename,uniqueStoreList);
            }
            foreach(var store in allstores)
            {
                GetStorePriceSum(store);
            }
            var result = GetCheapest();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public KeyValuePair<string, decimal> GetCheapestStoreNameAndSum(ListView cart)
        {
            string storeName = GetCheapestStore(cart);
            decimal sum = countDictionary[storeName];
            return new KeyValuePair<string,decimal>(storeName, sum);
        }
        //Get store's price sum
        private void GetStorePriceSum(KeyValuePair<string, List<Product>> store)
        {
            decimal count = 0;
            foreach (var item in store.Value)
            {
                count += item.Price;
            }
            if (countDictionary.ContainsKey(store.Key))
                countDictionary[store.Key] = count;
            else
                countDictionary.Add(store.Key, count);
        }
        
        //Getting minimum count
        public string GetCheapest()
        {
            decimal minNum = countDictionary.First().Value;
            string minStore = countDictionary.First().Key;
            foreach(var num in countDictionary)
            {
                if(num.Value < minNum)
                {
                    minNum = num.Value;
                    minStore = num.Key;
                }
            }
            return minStore;
        }
    }
}
