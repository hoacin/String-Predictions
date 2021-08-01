using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands
{
    internal static class VulkanSubmitBeginning
    {
        public static void BeginSubmit(this VulkanMembers members, PipelineType pipelineType)
        {
            CommandBufferBeginInfo commandBufferBeginInfo = new CommandBufferBeginInfo()
            {
                Flags = CommandBufferUsageFlags.OneTimeSubmit
            };
            members.CommandBuffer.Begin(commandBufferBeginInfo);
            members.CommandBuffer.CmdBindDescriptorSet(PipelineBindPoint.Compute, members.PipelineLayout, 0, members.DescriptorSet, null);
            Pipeline pipeline = pipelineType switch
            {
                PipelineType.SearchInit => members.SearchInitPipeline,
                PipelineType.Search => members.SearchPipeline,
                PipelineType.Reduce => members.ReducePipeline,
                PipelineType.Result => members.ResultPipeline,
                _ => throw new System.NotImplementedException(),
            };
            members.CommandBuffer.CmdBindPipeline(PipelineBindPoint.Compute, pipeline);
        }
    }
}
