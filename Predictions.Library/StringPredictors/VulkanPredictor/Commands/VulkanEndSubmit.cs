using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands
{
    internal static class VulkanEndSubmit
    {
        public static void EndSubmit(this VulkanMembers members)
        {
            members.CommandBuffer.End();
            SubmitInfo submitInfo = new SubmitInfo()
            {
                CommandBuffers = new CommandBuffer[] { members.CommandBuffer },
                CommandBufferCount = 1
            };
            members.Queue.Submit(submitInfo);
            members.Queue.WaitIdle();
        }
    }
}
