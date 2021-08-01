using Predictions.Library.NetStandard;
using System.Threading.Tasks;

namespace Predictions.Library.NetCore.StringPredictors.Ilgpu
{
    public sealed class IlgpuStringPredictor : IStringPredictor
    {
        private readonly string[] _phrases;
        private readonly GpuMembers _gpuMembers;
        private readonly Factory.AcceleratorType _type;

        public IlgpuStringPredictor(string[] phrases, Factory.AcceleratorType type)
        {
            _phrases = new string[phrases.Length];
            phrases.CopyTo(_phrases, 0);
            _type = type;
            _gpuMembers = new GpuMembers();
        }
        public Task InitAsync()
        {
            return _gpuMembers.InitAsync(_phrases, _type);
        }
        public Task<string> PredictAsync(string input)
        {
            return PredictAction.PredictAsync(_gpuMembers, input, _phrases);
        }
        public void Dispose()
        {
            _gpuMembers.Dispose();
        }
    }
}
