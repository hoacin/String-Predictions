using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization
{
    internal static class VulkanCreatePipelineLayout
    {
        public static PipelineLayout CreatePipelineLayout(this VulkanMembers members)
        {
            DescriptorSetLayout descriptorSetLayout = members.DescriptorSetLayout;
            PipelineLayoutCreateInfo pipelineLayoutCreateInfo = new PipelineLayoutCreateInfo()
            {
                SetLayouts = new DescriptorSetLayout[] { descriptorSetLayout },
                SetLayoutCount = 1
            };

            return members.Device.CreatePipelineLayout(pipelineLayoutCreateInfo);
        }
    }
}
