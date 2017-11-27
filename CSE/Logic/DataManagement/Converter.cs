using System.Collections.Generic;
using Logic.ImageAnalysis;
using Logic.Models;
using System.Drawing;
using System.Linq;
using System.IO;
using System;
using System.Threading;
using Logic.Database;
using System.Diagnostics;

namespace Logic.DataManagement
{
	public class Converter : IConverter
	{
		private readonly ITextProcessing _textProcessing;
		private readonly IUpdater _updater;

		public delegate void ListInitializedEventHandler(object source, EventArgs args);
		public event ListInitializedEventHandler ListInitialized;


		public Converter(ITextProcessing textProcessing, IUpdater updater)
		{
			_textProcessing = textProcessing;
			_updater = updater;
		}

		public IEnumerable<Product> GetProducts(IEnumerable<KeyValuePair<string, decimal>> detailsOfProducts)
		{
			var dictionary = new Dictionary<string, Product>();
			foreach (var item in detailsOfProducts)
			{
				if (dictionary.ContainsKey(item.Key))
				{
					var hits = (short)(dictionary[item.Key].Quantity + 1);
					dictionary[item.Key] = new Product(item.Key, item.Value, hits);
				}
				else
				{
					dictionary.Add(item.Key, new Product(item.Key, item.Value));
				}
			}
			return dictionary.Values.ToList();
		}
		/// <summary>
		/// Main method of converting image to 
		/// Receipt instance that holds:
		///     list of products;
		///     timestamp;
		///     store name.
		/// </summary>
		/// <param name="textProcessing"></param>
		/// <param name="image"></param>
		/// <returns>Receipt instance.</returns>


		public Receipt ConvertImageToReceipt(byte[] imageArgs)
		{
			var ti = new TaskInit(_updater);
			var imageProcessing = new ImageProcessing();

			// var image = (Bitmap)Image.FromStream(new MemoryStream(Convert.FromBase64String(imageArgs)));
			var image = new Bitmap("filename"); //TBD; depends on deserialization.
			var textFromImage = imageProcessing.GetTextFromImage(image);
			var recognizedLines = _textProcessing.SplitString(textFromImage.Result);
			var storeName = _textProcessing.RecognizeStore(recognizedLines);
			var timestamp = _textProcessing.RecognizeDate(recognizedLines);
			var goodRecognizedLines = _textProcessing.CleanIrrelevantLines(recognizedLines);
			var listOfProductDetails = _textProcessing.GetListOfNamesAndPrices(goodRecognizedLines);
			var listOfProducts = GetProducts(listOfProductDetails);

			ListInitialized += ti.OnListInitialized;
			ti.Receipt = new Receipt(listOfProducts, storeName, timestamp);
			OnListInitialized();

			return ti.Receipt;
		}

		protected virtual void OnListInitialized()
		{
			ListInitialized?.Invoke(this, EventArgs.Empty);
		}

		public int SaveReceipt(byte[] image)
		{
			var receipt = ConvertImageToReceipt(image);
			var response = _updater.UpdatePopularityRates(receipt);
			_updater.UpdatePrices(receipt);
			return response;
		}
	}
}
