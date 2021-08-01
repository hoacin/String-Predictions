using Predictions.Library.NetStandard.StringOperations;
using System.Threading.Tasks;

namespace Predictions.TestConsole.Helpers
{
    public static class PopCntPredictAction
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
                            //Counting bits with PopCnt instruction
                            totalMutualPairs += System.Runtime.Intrinsics.X86.Popcnt.PopCount(mutualBits);
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
