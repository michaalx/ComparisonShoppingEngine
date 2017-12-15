using System;
using System.Collections.Generic;

namespace Business.TextProcessing
{
    public interface ITextProcessing
    {
        List<string> SplitToLines(string text);
        List<string> CleanIrrelevantLines(IEnumerable<string> lines);
        DateTime RecognizeDate(IEnumerable<string> lines);
        string RecognizeStore(IEnumerable<string> lines);
        string FindMatchInDatabase(string dataToCheck);
        int LevenshteinDistance(string source, string target);
        List<KeyValuePair<string, decimal>> GetNamesAndPricesFromLines(List<string> lines);
        Dictionary<string, Tuple<decimal, int>> GetDistinctProducts(List<KeyValuePair<string, decimal>> data);
        List<string> GetClosestProductsNames(List<string> data);
        string GetClosestMatch(string dataToCheck, List<string> data);
    }
}