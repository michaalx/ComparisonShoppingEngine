using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE.BackEnd
{
    public class ProcessReceipt
    {
        List<Product> listOfItems = new List<Product>();
        DataDistributionAmongFiles ddaf = new DataDistributionAmongFiles();
        Dictionary<string, int> productsPopularity = new Dictionary<string, int>();
        public void GetDataFromReceipt(string file)
        {
            try
            {
                var textProcessor = new TextProcessor(TesseractOCR.ImageToText(file).Split('\n'));
                textProcessor.CleanEmptyLines();
                textProcessor.CleanIrrelevantLines();
                textProcessor.SeparateNamePrice();
                textProcessor.FindMatch();
                ///SOMEHOW GET STORE NAME FROM FILE
                var products = textProcessor.GetProductList().Select(x => x.ToString()).ToArray();
                var prices = textProcessor.GetPriceList().Select(x => x.ToString()).ToArray();

                ddaf.ToProductList(products, prices);
                ///ddaf.WriteDataToFile(shop);

            }
            catch (IOException) { }
            catch (ArgumentException) { }
        }
    }
}
