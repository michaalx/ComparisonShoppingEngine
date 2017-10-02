using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE
{
    class DataDistributionAmongFiles
    {
        CSV csvTool = new CSV();
        string pathToMaxima = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maxima.csv");
        string pathToIKI = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "iki.csv");
        string pathToRimi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rimi.csv");
        string pathToNorfa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "norfa.csv");
        string pathToLidl = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lidl.csv");
        public void WriteDataToFile(List<Product> products, Store store)
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
    }
}
