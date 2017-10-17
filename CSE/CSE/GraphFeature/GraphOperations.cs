using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSE.GraphFeature
{
    class GraphOperations
    {
        ProductDetails[] monthArray = new ProductDetails[12]; 
        CSV csvTool = new CSV();
        DataDistributionAmongFiles ddaf = new DataDistributionAmongFiles();
        List<ProductDetails> prod = new List<ProductDetails>();
        public string GetPath(Store store, string path = "default")
        {
            //same order in enum and array
            if(path.Equals("default"))
            {
                var i = (int)store;
                var paths = ddaf.GetPaths();
                return paths[i-1];
            } else
            {
                var i = (int)store;
                var paths = ddaf.GetPathsDetails();
                return paths[i-1];
            }
            
        }

        public Dictionary<DateTime,decimal> GetList(string path, string item)
        {
            var dateAndPrice = new Dictionary<DateTime,decimal>();
            var listFromFile = csvTool.ParsingDetailsFile(path,item);
            var queryForMatchingItem = from record in listFromFile
                                       where record.Name == item
                                       select record;

            foreach (var product in queryForMatchingItem)
            {
                if(!dateAndPrice.Keys.Contains(product.Timestamp))
                {
                    dateAndPrice.Add(product.Timestamp, product.Price);
                }
            }
            return dateAndPrice;
        } 
    }
}
