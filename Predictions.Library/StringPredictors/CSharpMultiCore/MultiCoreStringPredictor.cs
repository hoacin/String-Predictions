using Predictions.Library.NetStandard.SearchData;
using System;
using System.Threading.Tasks;

namespace Predictions.Library.NetStandard.StringPredictors.CSharpMultiCore
{
    public sealed class MultiCoreStringPredictor : IStringPredictor
    {
        private readonly string[] _phrases;
        private readonly Func<string, uint[], string[], Task<string>> _predictFunction;
        private uint[] _searchData = null;

        public MultiCoreStringPredictor(string[] phrases, Func<string, uint[], string[], Task<string>> predictAction = null)
        {
            _phrases = new string[phrases.Length];
            _predictFunction = predictAction ?? FallbackPredictAction.PredictAsync;
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
            return _predictFunction(input, _searchData, _phrases);
        }
        public void Dispose()
        {
        }
    }
}
