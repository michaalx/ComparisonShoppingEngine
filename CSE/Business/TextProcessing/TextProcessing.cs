using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using DataBase.Context;
using Microsoft.Extensions.Configuration;

namespace Business.TextProcessing
{
    public class TextProcessing : ITextProcessing
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;

        public TextProcessing(IConfiguration configuration, DataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        public List<string> SplitToLines(string text)
        {
            return text.Split('\n').ToList();
        }

        public List<string> CleanIrrelevantLines(IEnumerable<string> lines)
        {

            var pattern = @"\d+[.,]\d{2}\s[A-Z]\b";
            var result = from relevantLines in lines
                where Regex.Match(relevantLines, pattern).Success
                      && !(relevantLines == "\r" || relevantLines == "")
                select relevantLines;
            return result.ToList();
        }

        public DateTime RecognizeDate(IEnumerable<string> lines)
        {
            var regex = new Regex(@"\b\d{4}\-\d{2}.\d{2}\b");
            foreach (var line in lines)
            {
                foreach (Match match in regex.Matches(line))
                {
                    if (DateTime.TryParseExact(match.Value, "yyyy-MM-dd", null, DateTimeStyles.None, out var datetime))
                        return datetime;
                }
            }
            return new DateTime(0000, 00, 00);
        }

        public string RecognizeStore(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                if (line.ToUpper().Contains(_configuration["Maxima"]))
                {
                    return "Maxima";
                }
                if (line.Contains(_configuration["Rimi"]))
                {
                    return "Rimi";
                }
                if (line.Contains(_configuration["Iki"]))
                {
                    return "Iki";
                }
                if (line.Contains(_configuration["Norfa"]))
                {
                    return "Norfa";
                }
                if (line.Contains(_configuration["Lidl"]))
                {
                    return "Lidl";
                }
            }
            return null;
        }

        public string GetClosestMatch(string dataToCheck, List<string> data)
        {
            var closestMatchIndex = -1;
            var index = -1;
            var counter = default(int);
            foreach (var product in data)
            {
                var distance = LevenshteinDistance(dataToCheck, product);
                if (closestMatchIndex > distance || closestMatchIndex == -1)
                {
                    closestMatchIndex = distance;
                    index = counter;
                }
                counter++;
            }
            return data[index];
        }

        public string FindMatchInDatabase(string dataToCheck)
        {
            var productsInDatabase = _dataContext.Products.Select(p=>p.Name).ToList();
            var x = GetClosestMatch(dataToCheck, productsInDatabase);
            return x;
        }

        public int LevenshteinDistance(string source, string target)
        {
            if (string.IsNullOrEmpty(source))
            {
                if (string.IsNullOrEmpty(target)) return 0;
                return target.Length;
            }
            if (string.IsNullOrEmpty(target)) return source.Length;

            if (source.Length > target.Length)
            {
                var temp = target;
                target = source;
                source = temp;
            }

            var m = target.Length;
            var n = source.Length;
            var distance = new int[2, m + 1];

            for (var j = 1; j <= m; j++) distance[0, j] = j;

            var currentRow = 0;
            for (var i = 1; i <= n; ++i)
            {
                currentRow = i & 1;
                distance[currentRow, 0] = i;
                var previousRow = currentRow ^ 1;
                for (var j = 1; j <= m; j++)
                {
                    var cost = (target[j - 1] == source[i - 1] ? 0 : 1);
                    distance[currentRow, j] = Math.Min(Math.Min(
                            distance[previousRow, j] + 1,
                            distance[currentRow, j - 1] + 1),
                        distance[previousRow, j - 1] + cost);
                }
            }
            return distance[currentRow, m];
        }

        public List<KeyValuePair<string, decimal>> GetNamesAndPricesFromLines(List<string> lines)
        {
            var result = new List<KeyValuePair<string, decimal>>();
            var pattern = @"\d,\d{2}";
            foreach (var line in lines)
            {
                var match = Regex.Match(line, pattern);
                var decimalValue = match.Value;
                var indexOfRegex = match.Index;
                var x= decimalValue.Replace(',', '.');
                if (!decimal.TryParse(x, out decimal price))
                {
                    continue; 
                }
            
                var name = line.Substring(0, indexOfRegex + 1);
                result.Add(new KeyValuePair<string, decimal>(name,price));
            }
            return result;
        }

        public Dictionary<string,Tuple<decimal, int>> GetDistinctProducts(List<KeyValuePair<string, decimal>> data) 
        {
            var dictionary = new Dictionary<string, Tuple<decimal, int>> ();
            foreach (var datum in data)
            {
                if (dictionary.ContainsKey(datum.Key))
                {
                    var record = dictionary[datum.Key];
                    dictionary[datum.Key] = new Tuple<decimal, int>(record.Item1, record.Item2 +1);
                }
                else
                {
                    dictionary.Add(datum.Key,new Tuple<decimal, int>(datum.Value,1));
                }
            }
            return dictionary;
        }

        public List<string> GetClosestProductsNames(List<string> data) => data
            .Select(FindMatchInDatabase)
            .ToList();
    }
}