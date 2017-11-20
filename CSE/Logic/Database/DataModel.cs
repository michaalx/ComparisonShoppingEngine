using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
					productData = reader.ReadData("SELECT DISTINCT name FROM product");
					reader.CloseConnection();
				}
				return productData;
			}
		}

		/*public IEnumerable<string> historyData;

		public IEnumerable<string> HistoryData
		{
			get
			{
				if (historyData == null)
				{
					var reader = new Reader();
					reader.OpenConnection();
					historyData = reader.ReadData("SELECT DISTINCT h.product, h.price, r.shopid, r.date" +
													"FROM history AS h, receipt AS r" +
													 "WHERE h.receiptid = r.id");
					reader.CloseConnection();
				}
				return historyData;
			}
		}*/

		/*public void HistoryData
		{

		}*/
	}
}
