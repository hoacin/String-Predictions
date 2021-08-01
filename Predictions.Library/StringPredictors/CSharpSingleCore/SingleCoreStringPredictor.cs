using Predictions.Library.NetStandard.SearchData;
using Predictions.Library.NetStandard.StringPredictors.CSharpSingleCore;
using System.Threading.Tasks;

namespace Predictions.Library.NetStandard.StringPredictors.CSharpDefault
{
    public sealed class SingleCoreStringPredictor : IStringPredictor
    {
        private readonly string[] _phrases;
        private uint[] _searchData = null;

        public SingleCoreStringPredictor(string[] phrases)
        {
            _phrases = new string[phrases.Length];
            phrases.CopyTo(_phrases, 0);
        }
        public Task InitAsync()
        {
            return Task.Run(() =>
            {
                _searchData = _phrases.GetSearchData();
            });
        }
        public Task<string> PredictAsync(string input)
        {
            return PredictAction.PredictAsync(input, _searchData, _phrases);
        }
        public void Dispose()
        {
        }
    }
}
