using Predictions.Library.NetStandard.StringOperations;
using System.Threading.Tasks;

namespace Predictions.Library.NetStandard.StringPredictors.CSharpMultiCore
{
    internal static class FallbackPredictAction
    {
        public static Task<string> PredictAsync(string input, uint[] searchData, string[] phrases)
        {
            return Task.Run(() =>
            {
                uint globalMax = 0;
                uint[] searchedWord = input.GetSearchData();
                _ = Parallel.For(0, phrases.Length,
                    () => uint.MinValue,
                    (word, _, localMax) =>
                    {
                        uint totalMutualPairs = 0;
                        int indexInSearchData = 41 * word;
                        for (int i = 0; i < 41; i++, indexInSearchData++)
                        {
                            uint mutualBits = searchData[indexInSearchData] & searchedWord[i];
                            //Counting bits simple way
                            mutualBits -= ((mutualBits >> 1) & 0x55555555);
                            mutualBits = (mutualBits & 0x33333333) + ((mutualBits >> 2) & 0x33333333);
                            totalMutualPairs += (((mutualBits + (mutualBits >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
                        }
                        if (totalMutualPairs > 31)
                            totalMutualPairs = 31;
                        totalMutualPairs = totalMutualPairs << 27 | (uint)word;
                        if (totalMutualPairs > localMax)
                            return totalMutualPairs;
                        return localMax;
                    },
                    localMax =>
                    {
                        lock (searchedWord)
                            if (localMax > globalMax)
                                globalMax = localMax;
                    });
                return phrases[globalMax & 134217727];
            });
        }
    }
}
