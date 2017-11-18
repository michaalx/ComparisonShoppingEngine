using System.Collections.Generic;
using Logic.ImageAnalysis;
using Logic.Models;
using System.Drawing;

namespace Logic.DataManagement
{
    public class Converter
    {
        public IEnumerable<Product> ConvertDataToListOfProducts(IEnumerable<KeyValuePair<string, decimal>> detailsOfProducts)
        {
            var result = new List<Product>();
            foreach (var item in detailsOfProducts)
            {
                result.Add(new Product(item.Key, item.Value));
            }
            return result;
        }
        /// <summary>
        /// Main method of converting image to 
        /// Receipt instance that holds:
        ///     list of products;
        ///     timestamp;
        ///     store name.
        /// Reason to use:
        ///     statistics. Receipt is stored in Database,
        ///     and therefore we can gather information about 
        ///     receipts and draw some conclusions.
        ///     
        /// </summary>
        /// <param name="textProcessing"></param>
        /// <param name="image"></param>
        /// <returns>Receipt instance.</returns>
        public Receipt ConvertImageToReceipt(Bitmap image)
        {
            var imageProcessing = new ImageProcessing();
            ///TODO: textProcessing should be constructed
            ///with configuration instance of application.
            var textProcessing = new TextProcessing();

            var textFromImage =  imageProcessing.GetTextFromImage(image);
            var recognizedLines = textProcessing.SplitString(textFromImage.Result);
            var goodRecognizedLines = textProcessing.CleanIrrelevantLines(recognizedLines);
            var storeName = textProcessing.RecognizeStore(recognizedLines);
            var timestamp = textProcessing.RecognizeDate(recognizedLines);
            var listOfProductDetails = textProcessing.GetListOfNamesAndPrices(goodRecognizedLines);
            var listOfProducts = ConvertDataToListOfProducts(listOfProductDetails);
            return new Receipt(listOfProducts, storeName, timestamp);
        }
    }
}
