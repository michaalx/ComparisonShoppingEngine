using Logic.Metadata;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.CSVFiles
{
    class DataDistributionAmongFiles
    {
        private List<Product> _products;
        private CSV _csvTool = new CSV();

        private static string _pathToMaxima = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maxima.csv");
        private static string _pathToIKI = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "iki.csv");
        private static string _pathToRimi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rimi.csv");
        private static string _pathToNorfa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "norfa.csv");
        private static string _pathToLidl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lidl.csv");
        private string[] _paths = { _pathToMaxima, _pathToIKI, _pathToRimi, _pathToNorfa, _pathToLidl };

        private static string _pathToMaximaDetails = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maximaDetails.csv");
        private static string _pathToIKIDetails = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ikiDetails.csv");
        private static string _pathToRimiDetails = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rimiDetails.csv");
        private static string _pathToNorfaDetails = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "norfaDetails.csv");
        private static string _pathToLidlDetails = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lidlDetails.csv");
        private string[] _pathsDetails = { _pathToMaximaDetails, _pathToIKIDetails, _pathToRimiDetails, _pathToNorfaDetails, _pathToLidlDetails };

        public void StoreDataToFile(List<Product> products, Store? store)
        {
            switch (store)
            {
                case Store.Maxima:
                    _csvTool.WriteToFileProducts(products, _pathToMaxima);
                    return;
                case Store.IKI:
                    _csvTool.WriteToFileProducts(products, _pathToIKI);
                    return;
                case Store.Rimi:
                    _csvTool.WriteToFileProducts(products, _pathToRimi);
                    return;
                case Store.Norfa:
                    _csvTool.WriteToFileProducts(products, _pathToNorfa);
                    return;
                case Store.Lidl:
                    _csvTool.WriteToFileProducts(products, _pathToLidl);
                    return;
            }
        }

        public void ToProductList(string[] products, string[] prices)
        {
            this._products = new List<Product>();
            decimal[] price = Array.ConvertAll(prices, Decimal.Parse);
            for (int i = 0; i < products.Length; i++)
            {
                var temp = new Product(products[i], price[i]);
                this._products.Add(temp);
            }
        }

        public List<Product> GetProductsList()
        {
            return _products;
        }

        public string[] GetFilesPaths()
        {
            return _paths;
        }

        public string[] GetPathsDetails()
        {
            return _pathsDetails;
        }
    }
}
}
