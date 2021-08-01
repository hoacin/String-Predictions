using System;
using System.Threading.Tasks;

namespace Predictions.Library.NetStandard
{
    public interface IStringPredictor : IDisposable
    {
        Task InitAsync();
        Task<string> PredictAsync(string input);
    }
}
