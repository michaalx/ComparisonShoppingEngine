using Logic.CSVFiles;
using Logic.Database;
using Logic.Metadata;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Graph
{
    public class GraphOperations
    {
        List<Dictionary<DateTime, decimal>> listOfLists = new List<Dictionary<DateTime, decimal>>();
        Dictionary<DateTime,decimal> listForDays;
        Dictionary<DateTime, decimal> listForMonths;
        Dictionary<DateTime, decimal> listForYears;
        DataModel dm = new DataModel();
        public GraphOperations(string item, int storeName)
        {
            listForDays = GetListDays(item,storeName);
            listForMonths = GetListMonths(listForDays);
            listForYears = GetListYears(listForDays);
            listOfLists.Add(listForDays);
            listOfLists.Add(listForMonths);
            listOfLists.Add(listForYears);
        }

        public List<Dictionary<DateTime,decimal>> GetList()
        {
            return listOfLists;
        }

        public Dictionary<DateTime, decimal> GetListDays(string item, int storeName)
        {
            var list = dm.HistoryData(item, storeName);
            try
            {
                var dateAndPrice = new Dictionary<DateTime, decimal>();
                foreach (var product in list)
                {
                    if (!dateAndPrice.Keys.Contains(product.Item1))
                    {
                        dateAndPrice.Add(product.Item1, product.Item2);
                    }
                }
                return dateAndPrice;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Dictionary<DateTime, decimal> GetListYears(Dictionary<DateTime, decimal> listForDays)
        {
            var newList = new List<string>();
            var returnList = new Dictionary<DateTime, decimal>();
            foreach (var item in listForDays)
            {
                if (!newList.Contains(item.Key.Year.ToString()))
                {
                    newList.Add(item.Key.Year.ToString());
                }
            }
            for (int i = 0; i < newList.Count(); i++)
            {
                decimal sum = 0;
                decimal avg = 0;
                int count = 0;
                foreach (var item in listForDays)
                {
                    if (item.Key.Year.ToString() == newList[i])
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
                returnList.Add(new DateTime(int.Parse(newList[i]), 1, 1), avg);
            }
            return returnList;
        }

        public Dictionary<DateTime, decimal> GetListMonths(Dictionary<DateTime, decimal> list)
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
                returnList.Add(new DateTime(int.Parse(substrings[0]), int.Parse(substrings[1]), 1), avg);
            }
            return returnList;
        }
    }
}
