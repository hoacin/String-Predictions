using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization
{
    internal static class VulkanInstance
    {
        public static Instance Create()
        {
            ApplicationInfo appInfo = new ApplicationInfo()
            {
                ApplicationName = "Hello Vulkan",
                ApplicationVersion = Vulkan.Version.Make(1, 0, 0),
                EngineName = "No Engine",
                EngineVersion = Vulkan.Version.Make(1, 0, 0),
                ApiVersion = Vulkan.Version.Make(1, 0, 0)
            };

            InstanceCreateInfo createInfo = new InstanceCreateInfo()
            {
                ApplicationInfo = appInfo,
            };

            return new Instance(createInfo);
        }
    }
}
