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
        string[] paths = { pathToIKI, pathToLidl, pathToMaxima, pathToNorfa, pathToRimi };

        public void WriteDataToFile(string store)
        {
            switch (store)
            {
                case "Maxima":
                    csvTool.WriteToFileProducts(products, pathToMaxima);
                    return;
                case "IKI":
                    csvTool.WriteToFileProducts(products, pathToIKI);
                    return;
                case "Rimi":
                    csvTool.WriteToFileProducts(products, pathToRimi);
                    return;
                case "Norfa":
                    csvTool.WriteToFileProducts(products, pathToNorfa);
                    return;
                case "Lidl":
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

        public string[] GetFilesPaths()
        {
            return paths;
        }
    }
}
