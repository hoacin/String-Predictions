using ILGPU;

namespace Predictions.Library.NetCore.StringPredictors.Ilgpu.Kernels
{
    internal static class SimpleKernel
    {
        public static void Get(Index1 word, ArrayView<uint> searchedWord, ArrayView<uint> searchData, ArrayView<uint> outputData, int _)
        {
            int indexInSearchData = 41 * word;
            uint totalMutualPairs = 0;
            for (int i = 0; i < 41; i++, indexInSearchData++)
            {
                uint mutualBits = searchedWord[i] & searchData[indexInSearchData];
                mutualBits -= ((mutualBits >> 1) & 0x55555555);
                mutualBits = (mutualBits & 0x33333333) + ((mutualBits >> 2) & 0x33333333);
                totalMutualPairs += (((mutualBits + (mutualBits >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
            }

            if (totalMutualPairs > 31)
                totalMutualPairs = 31;
            totalMutualPairs = totalMutualPairs << 27 | (uint)word;
            outputData[word] = totalMutualPairs;
        }
    }
}
