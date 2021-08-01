using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory
{
    internal static class VulkanDescriptorPool
    {
        public static DescriptorPool CreateDescriptorPool(this VulkanMembers members)
        {
            DescriptorPoolCreateInfo createInfo = new DescriptorPoolCreateInfo()
            {
                MaxSets = 3,
            };
            return members.Device.CreateDescriptorPool(createInfo);
        }
    }
}
