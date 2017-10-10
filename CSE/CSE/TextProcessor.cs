using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE
{
	class TextProcessor
	{
		private List<string> productDB = new List<string>();
		private List<string> recognizedTextLines = new List<string>();
		private List<string> productList = new List<string>();
		private List<double> priceList = new List<double>();


		public TextProcessor(string[] recognizedTextLines)
		{
			this.recognizedTextLines = recognizedTextLines.ToList();
			DataBaseInit();
		}

		public void DataBaseInit()
		{
            var fp = new DataDistributionAmongFiles();
            
            /*
			productDB.Add("SEED BATCH");
			productDB.Add("MILK");
			productDB.Add("WHOLE MILK");
			productDB.Add("JS LIGHT SUGAR");
			productDB.Add("MALTESERS");
			productDB.Add("WENSLEY & CRAN");
			productDB.Add("GREEK STYLE YOGURT");
			productDB.Add("VIENNA TIGER ROLLS");
			productDB.Add("GARLIC BAGUETTE");
            */
		}

		public void CleanEmptyLines()
		{
			for (int i = 0; i < recognizedTextLines.Count; i++)
			{
				if (recognizedTextLines[i] == "\r" || recognizedTextLines[i] == "")
				{
					recognizedTextLines.RemoveAt(i);
					i--;
				}
			}
		}

		public void CleanIrrelevantLines()
		{
			char[] temp = new char[6];
			for (int i = 0; i < recognizedTextLines.Count; i++)
			{	
				recognizedTextLines[i].CopyTo(recognizedTextLines[i].Count()-7, temp, 0, 6);
				if (!(Char.IsDigit(temp[0]) &&
						(temp[1].Equals(',') || temp[1].Equals('.')) &&
						Char.IsDigit(temp[2]) &&
						Char.IsDigit(temp[3]) &&
						temp[4].Equals(' ') &&
						(temp[5].Equals('A') || temp[5].Equals('C'))))
				{
					recognizedTextLines.RemoveAt(i);
					i--;
				}
			}
		}

		public void SeparateNamePrice()
		{
			int size;
			for (int i = 0; i < recognizedTextLines.Count; i++)
			{
				char[] temp = recognizedTextLines[i].ToCharArray();
				for (int j = 0; j < temp.Count() - 5; j++)
				{
					if (Char.IsDigit(temp[j]) &&
						(temp[j + 1].Equals(',') || temp[j + 1].Equals('.')) &&
						Char.IsDigit(temp[j + 2]) &&
						Char.IsDigit(temp[j + 3]) &&
						temp[j + 4].Equals(' ') &&
						(temp[j + 5].Equals('A') || temp[j + 5].Equals('C')))
					{
						int k = j - 1;
						while (Char.IsDigit(temp[k])) k--;
						size = temp.Count() - k - 4;
						char[] temp2 = new char[size];
						recognizedTextLines[i].CopyTo(k + 1, temp2, 0, temp.Count() - (k + 4));
						temp2[temp2.Count() - 3] = '.';
						priceList.Add(Convert.ToDouble(string.Join("", temp2)));
						recognizedTextLines[i].Remove(k);
						break;
					}
				}

			}


		}

		public void FindMatch()
		{
			int temp;
			int index = 0;
			int closestMatchIndex = -1;

			for (int i = 0; i < recognizedTextLines.Count; i++)
			{
				for (int j = 0; j < productDB.Count; j++)
				{
					temp = LevenshteinDistance(recognizedTextLines[i], productDB[j]);
					if (closestMatchIndex > temp || closestMatchIndex == -1)
					{
						closestMatchIndex = temp;
						index = j;
					}
				}

				productList.Add(productDB[index]);
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

		public List<double> GetPriceList()
		{
			return priceList;
		}

		public List<string> GetProductList()
		{
			return productList;
		}

		public int GetCount()
		{
			if (productList.Count == priceList.Count)
				return productList.Count;
			else
				throw new IndexOutOfRangeException();
		}
	}
}