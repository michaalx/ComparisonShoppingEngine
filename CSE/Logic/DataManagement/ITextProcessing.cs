using System;
using System.Collections.Generic;
using Logic.Metadata;

namespace Logic.DataManagement
{
    public interface ITextProcessing
    {
        IEnumerable<string> CleanIrrelevantLines(IEnumerable<string> lines);
        string FindMatch(string dataToCheck);
        IEnumerable<KeyValuePair<string, decimal>> GetListOfNamesAndPrices(IEnumerable<string> lines);
        int LevenshteinDistance(string source, string target);
        DateTime RecognizeDate(IEnumerable<string> lines);
        Store RecognizeStore(IEnumerable<string> lines);
        IEnumerable<string> SplitString(string text);
    }
}