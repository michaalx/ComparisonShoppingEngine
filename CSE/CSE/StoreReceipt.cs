using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace CSE
{

    public enum Store
    {
        Maxima = 1,
        IKI,
        Rimi,
        Norfa,
        Lidl
    }
    class StoreReceipt
    {
        public List<Product> Products { get; }
        public DateTime Timestamp { get; }
        public Store StoreName { get; }
        public StoreReceipt(List<Product> products, DateTime timestamp, int store )
        {
            Products = products;
            Timestamp = timestamp;
            StoreName = store;
        }
    }
}