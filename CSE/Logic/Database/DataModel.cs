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

		public Dictionary<decimal, DateTime> HistoryData(Store storeName, string productName)
		{
			var reader = new Reader();
			reader.OpenConnection();
			var history = reader.ReadHistoryData(storeName, productName);
			reader.CloseConnection();
			return history;
		}
	}
}
