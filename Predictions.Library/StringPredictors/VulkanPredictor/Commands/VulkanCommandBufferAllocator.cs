using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands
{
    internal static class VulkanCommandBufferAllocator
    {
        public static CommandBuffer AllocateCommandBuffer(this VulkanMembers members)
        {
            CommandBufferAllocateInfo allocateInfo = new CommandBufferAllocateInfo()
            {
                CommandBufferCount = 1,
                CommandPool = members.CommandPool,
                Level = CommandBufferLevel.Primary
            };
            CommandBuffer buffer = members.Device.AllocateCommandBuffers(allocateInfo)[0];
            return buffer;
        }
    }
}
