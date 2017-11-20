using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Metadata;

namespace Logic.Database
{
	public class DataModel
	{
		public IEnumerable<string> productData;

		public IEnumerable<string> ProductData
		{
			get
			{
				if (productData == null)
				{
					var reader = new Reader();
					reader.OpenConnection();
					productData = reader.ReadProductData();
					reader.CloseConnection();
				}
				return productData;
			}
		}
		//FOR TESTING

		//var dm = new DataModel();
		//var product = dm.ProductData;

		//foreach (var e in product)
		//	Console.WriteLine(e.ToString());

		public List<Tuple<DateTime, decimal>> HistoryData(string productName, int storeName)
		{
			var reader = new Reader();
			reader.OpenConnection();
			var history = reader.ReadHistoryData(productName, storeName);
			reader.CloseConnection();
			return history;
		}
		//FOR TESTING

		//int store = (int)Store.IKI;
		//var dm = new DataModel();
		//var history = dm.HistoryData("Pienas", store);

		//foreach (Tuple<DateTime, decimal> e in history)
		//	Console.WriteLine(e.Item1.ToString() + " " + e.Item2.ToString());
	}
}
