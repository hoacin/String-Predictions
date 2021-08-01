namespace Predictions.Library.NetStandard.SearchData
{
    public static class GlobalMemoryAccess
    {
        public static uint[] OptimizeForCoalescing(this uint[] data, bool useCoalescing)
        {
            int rowOffset = 0;
            if (!useCoalescing)
                return data;

            int words = data.Length / 41;
            if (words % 128 > 0)
                rowOffset = 128 - words % 128;
            uint[] retArray = new uint[data.Length + 40 * rowOffset];
            rowOffset += words;
            //Making memory transformation so that instead of word being on 41 consecutive uints there is one milion first letters, then one milion second letters,...
            for (int word = 0; word < words; word++)
                for (int i = 0; i < 41; i++)
                    retArray[rowOffset * i + word] = data[41 * word + i];
            return retArray;
        }
    }
}
