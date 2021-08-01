using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Shaders
{
    internal static class VulkanShaderModule
    {
        public static PipelineShaderStageCreateInfo GetCreateInfo(Device device, string shaderName)
        {
            ShaderModuleCreateInfo createInfo = new ShaderModuleCreateInfo()
            {
                CodeBytes = VulkanSpirvLoader.GetShaderBytes(shaderName),
            };
            ShaderModule shaderModule = device.CreateShaderModule(createInfo);
            return new PipelineShaderStageCreateInfo()
            {
                Name = "main",
                Stage = ShaderStageFlags.Compute,
                Module = shaderModule,
            };
        }
    }
}
