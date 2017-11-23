using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Metadata;
using System.Diagnostics;

namespace Logic.Database
{
	public class DataModel : IDataModel
    {
		private IEnumerable<string> _productData;
        private IReader _reader;

        public DataModel(IReader reader) => _reader= reader;

		public IEnumerable<string> ProductData
		{
			get
			{
                //Lazy
				if (_productData == null)
				{
					_reader.OpenConnection();
					_productData = _reader.ReadProductData();
					_reader.CloseConnection();
				}
				return _productData;
			}
		}
		//FOR TESTING

		//var dm = new DataModel();
		//var product = dm.ProductData;

		//foreach (var e in product)
		//	Console.WriteLine(e.ToString());

		public List<Tuple<DateTime, decimal>> HistoryData(string productName, int storeName)
		{
			_reader.OpenConnection();
			var history =_reader.ReadHistoryData(productName, storeName);
			_reader.CloseConnection();
			return history;
		}
        //FOR TESTING

        //int store = (int)Store.IKI;
        //var dm = new DataModel();
        //var history = dm.HistoryData("Pienas", store);

        //foreach (Tuple<DateTime, decimal> e in history)
        //	Console.WriteLine(e.Item1.ToString() + " " + e.Item2.ToString());
        public IEnumerable<Tuple<string, short, decimal, string>> PopularProducts()
        {
            _reader.OpenConnection();
            var popularProducts = _reader.ReadPopularity();
            _reader.CloseConnection();
            return popularProducts;
        }
    }
}
