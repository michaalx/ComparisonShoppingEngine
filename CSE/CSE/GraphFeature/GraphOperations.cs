using CSE.BackEnd;
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
                var paths = ddaf.GetFilesPaths();
                return paths[i-1];
            } else
            {
                var i = (int)store;
                var paths = ddaf.GetPathsDetails();
                return paths[i-1];
            }
            
        }

        public Dictionary<DateTime,decimal> GetListDays(string path, string item)
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

        public Dictionary<DateTime,decimal> GetListYears(Dictionary<DateTime,decimal> listForDays)
        {
            var newList = new List<string>();
            var returnList = new Dictionary<DateTime, decimal>(); 
            foreach(var item in listForDays)
            {
                if (!newList.Contains(item.Key.Year.ToString()))
                {
                    newList.Add(item.Key.Year.ToString());
                }
            }
            for(int i = 0; i < newList.Count(); i++)
            {
                decimal sum = 0;
                decimal avg= 0;
                int count = 0;
                foreach (var item in listForDays)
                {
                    if(item.Key.Year.ToString() == newList[i])
                    {
                        count++;
                        sum += item.Value;
                    }
                }
                if(sum != 0 || newList.Count() != 0)
                {
                    avg = sum / count;
                } else
                {
                    avg = 0;
                }
                returnList.Add(new DateTime(int.Parse(newList[i]), 1, 1), avg);
            }
            return returnList;
        }

        public Dictionary<DateTime,decimal> GetListMonths(Dictionary<DateTime,decimal> list)
        {
            var newList = new List<string>();
            var returnList = new Dictionary<DateTime, decimal>();
            foreach (var item in list)
            {
                var concat = item.Key.Year.ToString() + "-" + item.Key.Month.ToString();
                if (!newList.Contains(concat))
                {
                    newList.Add(item.Key.Year.ToString() + "-" + item.Key.Month.ToString());
                }
            }
            for (int i = 0; i < newList.Count(); i++)
            {
                decimal sum = 0;
                decimal avg = 0;
                int count = 0;
                foreach (var item in list)
                {
                    var concat = item.Key.Year.ToString() + "-" + item.Key.Month.ToString();
                    if (concat == newList[i])
                    {
                        count++;
                        sum += item.Value;
                    }
                }
                if (sum != 0 || newList.Count() != 0)
                {
                    avg = sum / count;
                }
                else
                {
                    avg = 0;
                }
                Char delimiter = '-';
                String[] substrings = newList[i].Split(delimiter);
                returnList.Add(new DateTime(int.Parse(substrings[0]),int.Parse(substrings[1]), 1), avg);
            }
            return returnList;
        }
    }
}
