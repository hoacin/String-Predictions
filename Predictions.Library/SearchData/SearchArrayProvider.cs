using Predictions.Library.NetStandard.StringOperations;

namespace Predictions.Library.NetStandard.SearchData
{
    public static class SearchArrayProvider
    {
        public static uint[] GetSearchData(this string[] phrases)
        {
            //For each phrase we store 41 consecutive uint values as their search data
            uint[] searchData = new uint[41 * phrases.Length];
            for (int i = 0; i < phrases.Length; i++)
            {
                uint[] phraseSearchData = phrases[i].GetSearchData();
                phraseSearchData.CopyTo(searchData, 41 * i);
            }
            return searchData;
        }
    }
}
