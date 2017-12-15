using System;
using System.Collections.Generic;

namespace Business.TextProcessing
{
    public interface ITextProcessing
    {
        List<string> SplitString(string text);
        List<string> CleanIrrelevantLines(IEnumerable<string> lines);
        DateTime RecognizeDate(IEnumerable<string> lines);
        string RecognizeStore(IEnumerable<string> lines);
        string FindMatch(string dataToCheck);
        int LevenshteinDistance(string source, string target);
        List<KeyValuePair<string, decimal>> GetNameAndPrice(List<string> lines);
        Dictionary<string, Tuple<decimal, int>> GetDistinctProducts(List<KeyValuePair<string, decimal>> data);
        List<string> FindProductNamesFromDatabase(List<string> data);
        string Compare(string dataToCheck, List<string> data);
    }
}