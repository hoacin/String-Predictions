using Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands;
using System;
using System.Threading.Tasks;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor
{
    public sealed class VulkanStringPredictor : IStringPredictor
    {
        private readonly VulkanMembers _members;
        private readonly VulkanExecute _vulkanExecute;

        public VulkanStringPredictor(string[] phrases)
        {
            string[] localPhrases = new string[phrases.Length];
            Array.Copy(phrases, localPhrases, phrases.Length);
            _members = new VulkanMembers(localPhrases);
            _vulkanExecute = new VulkanExecute(localPhrases);
        }
        public Task InitAsync()
        {
            return _members.InitAsync();
        }

        public Task<string> PredictAsync(string input)
        {
            return _vulkanExecute.RunAsync(_members, input);
        }
        public void Dispose()
        {
            _members.Dispose();
        }
    }
}
