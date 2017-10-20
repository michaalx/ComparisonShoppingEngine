using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSE.BackEnd;

namespace CSE
{
    public class DataDistributionAmongFiles
    {
        public List<Product> products;
        CSV csvTool = new CSV();
      
        private static string _pathToMaxima = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maxima.csv");
        private static string _pathToIKI = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "iki.csv");
        private static string _pathToRimi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rimi.csv");
        private static string _pathToNorfa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "norfa.csv");
        private static string _pathToLidl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lidl.csv");
        private string[] _paths = { _pathToIKI, _pathToLidl, _pathToMaxima, _pathToNorfa, _pathToRimi };
      
        static string pathToMaxima = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maxima.csv");
        static string pathToIKI = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "iki.csv");
        static string pathToRimi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rimi.csv");
        static string pathToNorfa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "norfa.csv");
        static string pathToLidl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lidl.csv");
        static string pathToMaximaDetails = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maximaDetails.csv");
        static string pathToIKIDetails = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ikiDetails.csv");
        static string pathToRimiDetails = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rimiDetails.csv");
        static string pathToNorfaDetails = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "norfaDetails.csv");
        static string pathToLidlDetails = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lidlDetails.csv");
        string[] paths = { pathToMaxima, pathToIKI, pathToRimi, pathToNorfa, pathToLidl };
        string[] pathsDetails = { pathToMaximaDetails, pathToIKIDetails, pathToRimiDetails, pathToNorfaDetails, pathToLidlDetails };

        public void StoreDataToFile(List<Product> products, Store? store)
        {
             switch (store)
             {
                 case Store.Maxima:
                     csvTool.WriteToFileProducts(products, _pathToMaxima);
                     return;
                 case Store.IKI:
                     csvTool.WriteToFileProducts(products, _pathToIKI);
                     return;
                 case Store.Rimi:
                     csvTool.WriteToFileProducts(products, _pathToRimi);
                     return;
                 case Store.Norfa:
                     csvTool.WriteToFileProducts(products, _pathToNorfa);
                     return;
                 case Store.Lidl:
                     csvTool.WriteToFileProducts(products, _pathToLidl);
             return;
            }
        }

        public void ToProductList(string[] products, string[] prices)
        {
            this.products = new List<Product>();
            decimal[] price= Array.ConvertAll(prices, Decimal.Parse);
            for (int i = 0; i < products.Length; i++)
            {
                var temp = new Product(products[i], price[i]);
                this.products.Add(temp);
            }
        }

        public string[] GetFilesPaths()
        {
            return _paths;
        }

        public List<Product> GetProductsList()
        {
            return products;
        }

        public string[] GetPathsDetails()
        {
            return pathsDetails;
        }
    }
}
