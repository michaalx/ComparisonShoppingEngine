using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;
using Logic.Metadata;
using Logic.Database;

namespace Logic.ImageAnalysis
{
    public class TextProcessing
    {
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
                result.Add(new KeyValuePair<string, decimal>(name, price));
            }
            return result;
        }

        public DateTime RecognizeDate(IEnumerable<string> lines)
        {
            var regex = new Regex(@"\b\d{4}\-\d{2}.\d{2}\b");
            DateTime datetime;
            foreach (String line in lines)
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
            foreach (string line in lines)
            {
                if (line.Contains("MAXIMA"))
                {
                    return Store.Maxima;
                }
                else if (line.Contains("RIMI"))
                {
                    return Store.Rimi;
                }
                else if (line.Contains("IKI"))
                {
                    return Store.IKI;
                }
                else if (line.Contains("NORFA"))
                {
                    return Store.Norfa;
                }
                else if (line.Contains("LIDL"))
                {
                    return Store.Lidl;
                }
            }
            return 0;
        }
        /// <summary>
        /// Todo:
        /// implement alternative method that we have used 
        /// previously, this time involve database.
        /// </summary>
        public void FindMatch()
        {

        }


    }
}
