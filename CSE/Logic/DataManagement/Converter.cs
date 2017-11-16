using System.Collections.Generic;
using Logic.ImageAnalysis;
using Logic.Models;
using Logic.ImageAnalysis;
using System.Drawing;

namespace Logic.DataManagement
{
    static class Converter
    {
        /// <summary>
        /// I think this should be async.
        /// Still not sure if this method is useful now.
        /// (Where to use?)
        /// </summary>
        /// <param name="detailsOfProducts"></param>
        /// <returns></returns>
        public static IEnumerable<Product> ConvertDataToListOfProducts(IEnumerable<KeyValuePair<string, decimal>> detailsOfProducts)
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
        public static Receipt ConvertImageToReceipt(this TextProcessing textProcessing, Bitmap image)
        {
            var imageProcessing = new ImageProcessing();
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
