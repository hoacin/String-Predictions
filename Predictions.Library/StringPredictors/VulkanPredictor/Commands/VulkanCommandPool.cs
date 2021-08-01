using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands
{
    internal static class VulkanCommandPool
    {
        public static CommandPool CreateCommandPool(this VulkanMembers members)
        {
            CommandPoolCreateInfo createInfo = new CommandPoolCreateInfo()
            {
                QueueFamilyIndex = members.QueueFamilyIndex,
            };
            return members.Device.CreateCommandPool(createInfo);
        }
    }
}
