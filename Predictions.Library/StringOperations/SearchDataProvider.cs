using System.Collections;

namespace Predictions.Library.NetStandard.StringOperations
{
    public static class SearchDataProvider
    {
        public static uint[] GetSearchData(this string text)
        {
            //Starting with text normalization for predictions, removing symbols that will not be part of search
            string normalizedString = text.NormalizeForPredictions();

            //Setting all bits for letter pairs that exist in searched word for true. Does string contain "ax" sequence? "50" sequence?
            BitArray bitArray = new BitArray(41 * 32);
            for (int i = 0; i < normalizedString.Length - 1; i++)
            {
                int letterPairIndex = LetterPairIndexer.GetLetterPairIndex(normalizedString[i], normalizedString[i + 1]);
                bitArray.Set(letterPairIndex, true);
            }
            //Converting to uint[] array and returning
            uint[] searchData = new uint[41];
            bitArray.CopyTo(searchData, 0);
            return searchData;
        }
    }
}
