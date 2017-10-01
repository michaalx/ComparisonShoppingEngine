using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE
{
    class DataDistributionAmongFiles
    {
        CSV csvTool = new CSV();
        public void WriteDataToFile(List<Product> products, Store store)
        {
            switch (store)
            {
                case Store.Maxima:
                    csvTool.WriteToFileProducts(products, "FILEPATH_OF_FILE_OF_MAXIMA");
                    return;
                case Store.IKI:
                    csvTool.WriteToFileProducts(products, "FILEPATH_OF_FILE_OF_IKI");
                    return;
                case Store.Rimi:
                    csvTool.WriteToFileProducts(products, "FILEPATH_OF_FILE_OF_RIMI");
                    return;
                case Store.Norfa:
                    csvTool.WriteToFileProducts(products, "FILEPATH_OF_FILE_OF_NORFA");
                    return;
                case Store.Lidl:
                    csvTool.WriteToFileProducts(products, "FILEPATH_OF_FILE_OF_LIDL");
                    return;
                
            }
        }
    }
}
