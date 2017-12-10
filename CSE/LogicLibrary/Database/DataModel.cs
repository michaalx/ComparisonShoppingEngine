using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLibrary.Metadata;
using System.Diagnostics;

namespace LogicLibrary.Database
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
				if (_productData == null)
				{
					_reader.OpenConnection();
					_productData = _reader.ReadProductData();
					_reader.CloseConnection();
				}
				return _productData;
			}
		}

		public List<Tuple<DateTime, decimal>> HistoryData(string productName, int storeName)
		{
			_reader.OpenConnection();
			var history =_reader.ReadHistoryData(productName, storeName);
			_reader.CloseConnection();
			return history;
		}
        //FOR TESTING
        
        //To select from one store
        public List<string> OneStore(int shopId)
        {
            _reader.OpenConnection();
            var storeProducts = _reader.ReadOneStore(shopId);
            _reader.CloseConnection();
            return storeProducts;
        }

        //To find cheapest store
        public List<Tuple<string, decimal>> GetProducts(Store store)
        {
            _reader.OpenConnection();
            var products = _reader.ReadForCheapest(store);
            _reader.CloseConnection();
            return products;
        }

        public IEnumerable<string> GetAllStores()
        {
            _reader.OpenConnection();
            var products = _reader.ReadProductData().ToList();
            _reader.CloseConnection();
            return products;
        }

        public IEnumerable<Tuple<string, short, decimal, string>> PopularProducts()
        {
            _reader.OpenConnection();
            var popularProducts = _reader.ReadPopularity();
            _reader.CloseConnection();
            return popularProducts;
        }
    }
}
