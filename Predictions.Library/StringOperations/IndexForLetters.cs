using System;

namespace Predictions.Library.NetStandard.StringOperations
{
    internal static class IndexForLetters
    {
        public static int SearchLetterIndex(this char letter)
        {
            if (letter <= '9' && letter >= '0')
                return letter - '0';
            if (letter <= 'z' && letter >= 'a')
                return letter - 'a' + 10;
            throw new Exception("This letter is not allowed for search data. Normalize the text first.");
        }
    }
}
