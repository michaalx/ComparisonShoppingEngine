using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE
{
	class ClosestMatch
	{
		private List<string> productDB = new List<string>();

		public ClosestMatch() //For successful identification choose arguments of the list accordingly
		{
			productDB.Add("SEED BATCH");
			productDB.Add("MILK");
			productDB.Add("WHOLE MILK");
			productDB.Add("JS LIGHT SUGAR");
			productDB.Add("MALTESERS");
			productDB.Add("WENSLEY & CRAN");
			productDB.Add("GREEK STYLE YOGURT");
			productDB.Add("VIENNA TIGER ROLLS");
			productDB.Add("GARLIC BAGUETTE");
		}

		public string FindMatch(string[] products, string file)
		{
			List<string> productList = products.ToList();
			int temp;
			int index = 0;
			int closestMatchIndex = -1;

			for (int i = 0; i < productList.Count; i++)
			{
				for (int j = 0; j < productDB.Count; j++)
				{
					temp = ClosestMatch.LevenshteinDistance(productList[i], productDB[j]);
					if (closestMatchIndex > temp || closestMatchIndex == -1)
					{
						closestMatchIndex = temp;
						index = j;
					}
				}

				if (closestMatchIndex != -1)
				{
					if (productList[i] == "\r" || productList[i] == "")
					{
						productList.RemoveAt(i);
						i--;
					}
					else productList[i] = productDB[index];
				}

				closestMatchIndex = -1;
			}
			return string.Join("\r\n", productList.Select(x => x.ToString()).ToArray());
		}

		public static int LevenshteinDistance(string source, string target)
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
	}
}