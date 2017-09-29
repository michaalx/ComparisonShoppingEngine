using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace CSE
{

    public enum StoreList
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
        public int Store { get; }
        public StoreReceipt(List<Product> products, DateTime timestamp, int store )
        {
            Products = products;
            Timestamp = timestamp;
            Store = store;
        }
    }
}