using Logic.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    struct Receipt
    {
        public IEnumerable<Product> Products { get; private set; }
        public Store StoreName { get; private set; }
        public DateTime Timestamp { get; private set; }
        //  public void SetProductsList(IEnumerable<Product> products) => Products = products;
        //public void SetStoreName(Store storeName) => StoreName = storeName;
        //public void SetTimestamp(DateTime timestamp) => Timestamp = timestamp;
        public Receipt(IEnumerable<Product> products, Store storeName, DateTime timestamp)
        {
            Products = products;
            StoreName = storeName;
            Timestamp = timestamp;
        }
    }
}
