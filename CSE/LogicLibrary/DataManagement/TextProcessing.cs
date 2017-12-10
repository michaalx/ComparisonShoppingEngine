using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;
using LogicLibrary.Metadata;
using Microsoft.Extensions.Configuration;
using LogicLibrary.Database;

namespace LogicLibrary.DataManagement
{
    public class TextProcessing : ITextProcessing
    {
        private readonly IConfiguration _configuration;
        private readonly IReader _reader;

        public TextProcessing(IConfiguration configuration, IReader reader)
        {
            _configuration = configuration;
            _reader = reader;
        }

        public IEnumerable<string> SplitString(string text)
        {
            return text.Split('\n');
        }

        public IEnumerable<string> CleanIrrelevantLines(IEnumerable<string> lines)
        {

            var pattern = @"\d+[.,]\d{2}\s[A-Z]\b";
            var result = from relevantLines in lines
                         where Regex.Match(relevantLines, pattern).Success
                         && !(relevantLines == "\r" || relevantLines == "")
                         select relevantLines;
            return result;
        }

        public IEnumerable<KeyValuePair<string, decimal>> GetListOfNamesAndPrices(IEnumerable<string> lines)
        {
            var result = new List<KeyValuePair<string, decimal>>();
            var patternOfPrice = @"\d,\d{2}";
            foreach (var line in lines)
            {
                var match = Regex.Match(line, patternOfPrice);
                var decimalValue = match.Value;
                var indexOfRegex = match.Index;
                decimalValue.Replace(',', '.');
                if (!Decimal.TryParse(decimalValue, out decimal price)) continue;
                var name = line.Substring(0, indexOfRegex + 1);
                var matchedName = FindMatch(name);
                result.Add(new KeyValuePair<string, decimal>(name, price));
            }
            return result;
        }

        public DateTime RecognizeDate(IEnumerable<string> lines)
        {
            var regex = new Regex(@"\b\d{4}\-\d{2}.\d{2}\b");
            DateTime datetime;
            foreach (var line in lines)
            {
                foreach (Match match in regex.Matches(line))
                {
                    if (DateTime.TryParseExact(match.Value, "yyyy-MM-dd", null, DateTimeStyles.None, out datetime))
                        return datetime;
                }
            }
            return datetime = new DateTime(0000, 00, 00);
        }

        public Store RecognizeStore(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                if (line.Contains(_configuration["Maxima"]))
                {
                    return Store.Maxima;
                }
                else if (line.Contains(_configuration["Rimi"]))
                {
                    return Store.Rimi;
                }
                else if (line.Contains(_configuration["Iki"]))
                {
                    return Store.Iki;
                }
                else if (line.Contains(_configuration["Norfa"]))
                {
                    return Store.Norfa;
                }
                else if (line.Contains(_configuration["Lidl"]))
                {
                    return Store.Lidl;
                }
            }
            return 0;
        }
    
        public string FindMatch(string dataToCheck)
        {
            var productsInDatabase = _reader.ReadProductData().ToList();
            var distance = default(int);
            var closestMatchIndex = -1;
            var index = -1;
            var counter = default(int);
            foreach (var product in productsInDatabase)
            {
                distance = LevenshteinDistance(dataToCheck, product);
                if (closestMatchIndex > distance || closestMatchIndex == -1)
                {
                    closestMatchIndex = distance;
                    index = counter;
                }
                counter++;
            }
            return productsInDatabase[index];
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
    }
}
