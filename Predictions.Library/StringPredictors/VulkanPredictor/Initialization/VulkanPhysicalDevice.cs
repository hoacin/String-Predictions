using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization
{
    internal static class VulkanPhysicalDevice
    {
        public static PhysicalDevice GetPhysicalDevice(this VulkanMembers members)
        {
            PhysicalDevice[] devices = members.Instance.EnumeratePhysicalDevices();
            return devices[0];
        }
    }
}
