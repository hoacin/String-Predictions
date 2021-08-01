using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory
{
    internal static class VulkanDescriptorSetLayouts
    {
        public static DescriptorSetLayout GetDescriptorSetLayout(this VulkanMembers members)
        {
            DescriptorSetLayoutBinding[] descriptorSetLayoutBindings = new DescriptorSetLayoutBinding[4];
            for (int i = 0; i < 4; i++)
                descriptorSetLayoutBindings[i] = new DescriptorSetLayoutBinding()
                {
                    Binding = (uint)i,
                    DescriptorType = DescriptorType.StorageBuffer,
                    StageFlags = ShaderStageFlags.Compute,
                    DescriptorCount = 1
                };
            DescriptorSetLayoutCreateInfo descriptorSetLayoutCreateInfo = new DescriptorSetLayoutCreateInfo()
            {
                Bindings = descriptorSetLayoutBindings,
                BindingCount = (uint)descriptorSetLayoutBindings.Length,
            };
            DescriptorSetLayout descriptorSetLayout = members.Device.CreateDescriptorSetLayout(descriptorSetLayoutCreateInfo);

            return descriptorSetLayout;
        }
    }
}
