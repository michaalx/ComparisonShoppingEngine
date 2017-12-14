using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.TextProcessing
{
    public interface ITextProcessing
    {
        List<string> SplitString(string text);
        List<string> CleanIrrelevantLines(IEnumerable<string> lines);
        DateTime RecognizeDate(IEnumerable<string> lines);
        string RecognizeStore(IEnumerable<string> lines);
        Task<string> FindMatch(string dataToCheck);
        int LevenshteinDistance(string source, string target);
    }
}