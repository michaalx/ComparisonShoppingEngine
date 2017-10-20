using CSE.FrontEnd;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSE.BackEnd
{
    public class ProcessReceipt
    {
        public List<Product> ListOfItems { get; }
        public DataDistributionAmongFiles Ddaf { get; }
        public Dictionary<string, int> PopularProducts { get; }
        public TextProcessor TextProcessorUsed { get; }
        public ProcessReceipt(string file)
        {
            ListOfItems = new List<Product>();
            Ddaf = new DataDistributionAmongFiles();
            PopularProducts = new Dictionary<string, int>();
            TesseractOCR tesseractOCR = new TesseractOCR();
            TextProcessorUsed = new TextProcessor(tesseractOCR.ImageToText(file).Split('\n'));
        }
        /// <summary>
        /// Not sure about norfa, rimi.
        /// Return as enum type.
        /// Question mark allows null to be returned.
        /// </summary>
        /// <returns></returns>
        public Store? GetStoreName()
        {
            List<string> recognizedTextLines = TextProcessorUsed.GetListOfLines();
            foreach (string item in recognizedTextLines)
            {
                string textToCompare = item.ToUpper();
                if (textToCompare.Contains("UAB PALINK"))
                {
                    return Store.IKI;
                }
                else if (textToCompare.Contains("MAXIMA"))
                {
                    return Store.Maxima;
                }
                else if (textToCompare.Contains("NORFA"))
                {
                    return Store.Norfa;
                }
                else if (textToCompare.Contains("UAB LIDL LIETUVA"))
                {
                    return Store.Lidl;
                }
                else if (textToCompare.Contains("UAB RIMI"))
                {
                    return Store.Lidl;
                }
            }
            return null;
        }
        public List<Product> GetProductsFromReceipt()
        {
            try
            {
                
                TextProcessorUsed.CleanEmptyLines();
                TextProcessorUsed.CleanLines();
                TextProcessorUsed.SeparateNamePrice();
                TextProcessorUsed.FindMatch();

                var names = TextProcessorUsed.GetProductList().Select(x => x.ToString()).ToArray();
                var prices = TextProcessorUsed.GetPriceList().Select(x => x.ToString()).ToArray();
                Ddaf.ToProductList(names, prices);
                return Ddaf.GetProductsList();
            }
            catch (IOException) { return null; }
        }
        /// <summary>
        /// Complex method for processing receipt and retrieving data from it.
        /// Steps:
        /// 1. Recognize store name.
        /// 2. Get products from database.
        /// 3. Process text in receipt and get data from it.
        /// 4. Compare products in receipt with products in database and
        ///     update product list accordingly to condition.
        /// 5. Organize data to be stored in database.
        /// 6. Store data in database.
        /// </summary>
        public void ManipulateData()
        {
            var storeName = GetStoreName();
            if (storeName != null)
            {
                string file = storeName.ToString() + ".csv";
                CSV csvTool = new CSV();
                List<Product> productsInDatabase = csvTool.ParsingProductsOfStore(file);

                List<string> namesOfProductsInDatabase = csvTool.ParsingUniqueProducts();
                TextProcessorUsed.SetProductDB(namesOfProductsInDatabase);

                List<Product> productsInReceipt = GetProductsFromReceipt();
                List<Product> finalProductsList = new List<Product>();

                List<KeyValuePair<string, int>> productsByPopularity = csvTool.GetAllProductsByPopularity();
                foreach (var productInReceipt in productsInReceipt)
                {
                    foreach(var productInDatabase in productsInDatabase)
                    {
                        if (productInReceipt.Name == productInDatabase.Name)
                        {
                            if (productInReceipt.Price < productInDatabase.Price)
                            {
                                finalProductsList.Add(productInReceipt);
                            }
                            else
                            {
                                finalProductsList.Add(productInDatabase);
                            }
                            //Reduces the number of loop steps.
                            productsInDatabase.Remove(productInDatabase);
                            break;
                        }
                    }
                }


                ///Update popularity list in database.
                ///For every product in receipt, increase number of hits
                ///for that product in popularity list.
                foreach(var product in productsInReceipt)
                {
                    for(int index=0;index<productsByPopularity.Count;index++)
                    {
                        if (product.Name == productsByPopularity[index].Key)
                        {
                            var newPair = new KeyValuePair<string, int>(productsByPopularity[index].Key, productsByPopularity[index].Value + 1);
                            productsByPopularity[index] = newPair;
                            break;
                        }
                    }
                }

                ///Usual case, if receipt contains not all 
                ///products that are in store database.
                ///So we fill list with products from database.
                foreach(var product in productsInDatabase)
                {
                    finalProductsList.Add(product);
                }
                ///Check if product exists in database, but
                ///does not in store file.
                foreach(var product in productsInReceipt)
                {
                    if (!finalProductsList.Contains(product))
                    {
                        finalProductsList.Add(product);
                    }
                }
                finalProductsList = finalProductsList.OrderBy(x => x.Name).ToList();
                csvTool.UpdatePopularity(productsByPopularity);
                Ddaf.StoreDataToFile(finalProductsList, storeName);
            }
            else
            {
                ///Store is not recognized.
                FormsToolkit.DisplayMessageBox("Sorry, store is not detected.");
                return;
            }
        }
    }

}
