using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataBase.Models;
using DataBase.Repositories;
using Microsoft.Extensions.Configuration;

namespace Business.TextProcessing
{
    public class TextProcessing : ITextProcessing
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Product> _productRepository;
        public TextProcessing(IConfiguration configuration, IRepository<Product> productRepository)
        {
            _configuration = configuration;
            _productRepository = productRepository;
        }

        public List<string> SplitString(string text)
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
                if (line.Contains(_configuration["Maxima"]))
                {
                    return "Maxima";
                }
                else if (line.Contains(_configuration["Rimi"]))
                {
                    return "Rimi";
                }
                else if (line.Contains(_configuration["Iki"]))
                {
                    return "Iki";
                }
                else if (line.Contains(_configuration["Norfa"]))
                {
                    return "Norfa";
                }
                else if (line.Contains(_configuration["Lidl"]))
                {
                    return "Lidl";
                }
            }
            return null;
        }

        public async Task<string> FindMatch(string dataToCheck)
        {
           // var productsInDatabase = _reader.ReadProductData().ToList();
            var productsInDatabase = await _productRepository.GetAll();
            var closestMatchIndex = -1;
            var index = -1;
            var counter = default(int);
            foreach (var product in productsInDatabase)
            {
                var distance = LevenshteinDistance(dataToCheck, product.Name);
                if (closestMatchIndex > distance || closestMatchIndex == -1)
                {
                    closestMatchIndex = distance;
                    index = counter;
                }
                counter++;
            }
            return productsInDatabase[index].Name;
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
