using Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands.Reduction;
using Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands.Search;
using Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory.Marshaling;
using System.Threading.Tasks;
using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands
{
    internal class VulkanExecute
    {
        private readonly string[] _phrases;
        private readonly uint _searchDispatchX;
        private readonly ParallelReductionInfo[] _reductions;

        public VulkanExecute(string[] phrases)
        {
            _phrases = phrases;
            _searchDispatchX = (uint)DispatchCountProvider.GetDixpatchX(256, phrases.Length);
            _reductions = ParallelReductionAlgorithm.GetCycles(256, phrases.Length);
        }

        public Task<string> RunAsync(VulkanMembers members, string word)
        {
            return Task.Run(() =>
            {
                //Running similarity computations and storing results to output buffer "Search.spv"
                members.BeginSubmit(PipelineType.Search);
                members.PushSearchData(_phrases.Length, word);
                members.CommandBuffer.CmdDispatch(_searchDispatchX, 1, 1);
                members.EndSubmit();

                //Reducing output buffer to get the highest number to 0th position "Reduce.spv"
                foreach (ParallelReductionInfo reduction in _reductions)
                {
                    members.BeginSubmit(PipelineType.Reduce);
                    members.CommandBuffer.CmdPushConstants(members.PipelineLayout, ShaderStageFlags.Compute, 0, 4, reduction.Constants);
                    members.CommandBuffer.CmdDispatch(reduction.DixpatchX, 1, 1);
                    members.EndSubmit();
                }

                //Copying result from 0th position of output buffer host visible location "Result.spv"
                members.BeginSubmit(PipelineType.Result);
                members.CommandBuffer.CmdDispatch(1, 1, 1);
                members.EndSubmit();

                //Reading the result from host visible location
                uint[] memoryContent = members.ShowMemoryContent(VulkanBufferType.Result);
                return Task.FromResult(_phrases[memoryContent[0] & 134217727]);
            });
        }
    }
}
