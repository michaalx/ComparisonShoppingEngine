using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSE
{
    class DataDistributionAmongFiles
    {
        List<Product> products = new List<Product>();
        CSV csvTool = new CSV();
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
        public void WriteDataToFile(Store store)
        {
            switch (store)
            {
                case Store.Maxima:
                    csvTool.WriteToFileProducts(products, pathToMaxima);
                    return;
                case Store.IKI:
                    csvTool.WriteToFileProducts(products, pathToIKI);
                    return;
                case Store.Rimi:
                    csvTool.WriteToFileProducts(products, pathToRimi);
                    return;
                case Store.Norfa:
                    csvTool.WriteToFileProducts(products, pathToNorfa);
                    return;
                case Store.Lidl:
                    csvTool.WriteToFileProducts(products, pathToLidl);
                    return;
            }
        }

        public void ToProductList(string[] products, string[] prices)
        {
            decimal[] price= Array.ConvertAll(prices, Decimal.Parse);
            for (int i = 0; i < products.Length; i++)
            {
                var temp = new Product(products[i], price[i]);
                this.products.Add(temp);
            }
        }

        public string[] GetPaths()
        {
            return paths;
        }

        public string[] GetPathsDetails()
        {
            return pathsDetails;
        }
    }
}
