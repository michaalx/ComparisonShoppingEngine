using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSE
{
    public class TextProcessor
	{
		private List<string> _productDB = new List<string>();
		private List<string> _recognizedTextLines = new List<string>();
		private List<string> _productList = new List<string>();
		private List<decimal> _priceList = new List<decimal>();


		public TextProcessor(string[] recognizedTextLines)
		{
			this._recognizedTextLines = recognizedTextLines.ToList();
			DataBaseInit();
		}

		public void DataBaseInit()
		{
            var fp = new DataDistributionAmongFiles();
			var csv = new CSV();
			var list = csv.ParsingUniqueProducts(fp.GetFilesPaths());
			foreach (Product product in list)
            {
                _productDB.Add(product.Name);
            }
		}

		public void CleanEmptyLines()
		{
			for (int i = 0; i < _recognizedTextLines.Count; i++)
			{
				if (_recognizedTextLines[i] == "\r" || _recognizedTextLines[i] == "")
				{
					_recognizedTextLines.RemoveAt(i);
					i--;
				}
			}
		}

        public int RecogniseStore()
        {
            foreach(String line in _recognizedTextLines)
            {
                if(line.Contains("MAXIMA LT, UAB"))
                {
                    return -1;
                }
                else if(line.Contains("UAB \"RIMI LIETUVA\""))
                {
                    return -2;
                }
                else if(line.Contains("UAB PALINK"))
                {
                    return -3;
                }
                else if(line.Contains("UAB NORFOS MAZMENA")||line.Contains("UAB \"NORFOS MAŽMENA\""))
                {
                    return -4;
                }
                else if(line.Contains("UAB \"Lidl Lietuva\""))
                {
                    return -5;
                }
            }
            return 0;
        }

        public DateTime RecogniseDate()
        {
            var regex = new Regex(@"\b\d{4}\-\d{2}.\d{2}\b");
            DateTime datetime;
            foreach (String line in _recognizedTextLines)
            {
                foreach (Match match in regex.Matches(line))
                {
                    if (DateTime.TryParseExact(match.Value, "yyyy-MM-dd", null, DateTimeStyles.None, out datetime))
                        return datetime;
                }
            }
            return datetime = new DateTime(0000, 00, 00);
        }

        public void CleanLines()
        {
            char[] temp = new char[6];
            for (int i = 0; i < _recognizedTextLines.Count; i++)
            {
                if (!Regex.Match((_recognizedTextLines[i]), @"\d+[.,]\d{2}\s[A-Z]\b").Success)
                {
                    _recognizedTextLines.RemoveAt(i);
                    i--;
                }
            }
        }

		public void SeparateNamePrice()
		{
            string temp;
            double temp2;
            foreach (String line in _recognizedTextLines)
            {
                var match = Regex.Match(line, @"\d+,\d{2}");
                temp = match.Value;
                temp = temp.Replace(',', '.');
                Double.TryParse(temp, out temp2);
                _priceList.Add(Convert.ToDecimal(temp2));
            }
        }

		public void FindMatch()
		{
			int temp;
			int index = 0;
			int closestMatchIndex = -1;
         
			for (int i = 0; i < _recognizedTextLines.Count; i++)
			{
				for (int j = 0; j < _productDB.Count; j++)
				{
					temp = LevenshteinDistance(_recognizedTextLines[i], _productDB[j]);
					if (closestMatchIndex > temp || closestMatchIndex == -1)
					{
						closestMatchIndex = temp;
						index = j;
					}
				}

				_productList.Add(_productDB[index]);
				closestMatchIndex = -1;
			}
		}

		public int LevenshteinDistance(string source, string target)
		{

			if (String.IsNullOrEmpty(source))
			{
				if (String.IsNullOrEmpty(target)) return 0;
				return target.Length;
			}
			if (String.IsNullOrEmpty(target)) return source.Length;

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
        public void SetProductDB(List<string> products)
        {
            this._productDB = products;
        }
        public List<string> GetListOfLines()
        {
            return _recognizedTextLines;
        }

		public List<decimal> GetPriceList()
		{
			return _priceList;
		}

		public List<string> GetProductList()
		{
			return _productList;
		}

		public int GetCount()
		{
			if (_productList.Count == _priceList.Count)
				return _productList.Count;
			else
				throw new IndexOutOfRangeException();
		}
	}
}