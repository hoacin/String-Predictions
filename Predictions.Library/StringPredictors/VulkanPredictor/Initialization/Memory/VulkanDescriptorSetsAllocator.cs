using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory
{
    internal static class VulkanDescriptorSetsAllocator
    {
        public static DescriptorSet AllocateDescriptorSet(this VulkanMembers members)
        {
            DescriptorSetAllocateInfo allocateInfo = new DescriptorSetAllocateInfo()
            {
                DescriptorPool = members.DescriptorPool,
                SetLayouts = new DescriptorSetLayout[] { members.DescriptorSetLayout },
                DescriptorSetCount = 1
            };
            DescriptorSet[] sets = members.Device.AllocateDescriptorSets(allocateInfo);
            return sets[0];
        }
    }
}
