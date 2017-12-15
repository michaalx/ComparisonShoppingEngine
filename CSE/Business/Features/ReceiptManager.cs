using System.Collections.Generic;
using System.Linq;
using Business.TextProcessing;
using DataBase.Context;
using DataBase.Models;

namespace Business.Features
{
    public class ReceiptManager : IReceiptManager
    {
        private readonly ITextProcessing _textProcessing;
        private readonly DataContext _dataContext;

        public ReceiptManager(ITextProcessing textProcessing, DataContext dataContext)
        {
            _textProcessing = textProcessing;
            _dataContext = dataContext;
        }

        public int Insert(string textFromImage)
        {
            #region TextProcessing
            var recognizedLines = _textProcessing.SplitToLines(textFromImage);
            var goodRecognizedLines = _textProcessing.CleanIrrelevantLines(recognizedLines);
            var storeName = _textProcessing.RecognizeStore(recognizedLines);
            var timestamp = _textProcessing.RecognizeDate(recognizedLines);

            var namesAndPrices = _textProcessing.GetNamesAndPricesFromLines(goodRecognizedLines);

            var namesInDb = namesAndPrices.Select(x => x.Key).ToList();
            var prices = namesAndPrices.Select(x => x.Value).ToList();
            var recognizedProductNames = _textProcessing.GetClosestProductsNames(namesInDb);
            #endregion
            var namesInDbAndPrices = new List<KeyValuePair<string, decimal>>();
            var status = true;

            for (int i = 0; i < namesAndPrices.Count; i++)
            {
                namesInDbAndPrices.Add(new KeyValuePair<string, decimal>(recognizedProductNames[i], prices[i]));
            }

            var distinctProducts = _textProcessing.GetDistinctProducts(namesInDbAndPrices);

            using (_dataContext)
            {
                foreach (var item in distinctProducts)
                {
                    var storeId = _dataContext.Stores.FirstOrDefault(y => y.Name == storeName).Id;
                    var productId = _dataContext.Products.FirstOrDefault(y => y.Name == item.Key).Id;

                    if (storeId == default(short) || productId == default(int))
                    {
                        status = false;
                        continue;
                    }

                    var x = new Record
                    {
                        Price = item.Value.Item1,
                        Quantity = item.Value.Item2,
                        TimeStamp = timestamp,
                        StoreId = storeId,
                        ProductId = productId
                    };
                    _dataContext.Records.Add(x);
                }
                _dataContext.SaveChanges();
                return status ? 0 : 1; 
            }
        }
    }
}