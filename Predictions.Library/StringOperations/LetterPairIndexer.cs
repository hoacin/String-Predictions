namespace Predictions.Library.NetStandard.StringOperations
{
    internal static class LetterPairIndexer
    {
        public static int GetLetterPairIndex(char firstLetter, char secondLetter)
        {
            int firstLetterIndex = firstLetter.SearchLetterIndex();
            int secondLetterIndex = secondLetter.SearchLetterIndex();
            return 36 * firstLetterIndex + secondLetterIndex; //Giving '00' letter pair index 0 and letter pair 'zz' index 1295. And all combinations in between.
        }
    }
}
