using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization
{
    internal static class VulkanDevice
    {
        public static Device CreateDevice(this VulkanMembers members)
        {
            DeviceQueueCreateInfo deviceQueueCreateInfos = new DeviceQueueCreateInfo()
            {
                QueueFamilyIndex = members.QueueFamilyIndex,
                QueuePriorities = new float[] { 1f },
                QueueCount = 1,
            };
            DeviceCreateInfo deviceCreateInfo = new DeviceCreateInfo()
            {
                QueueCreateInfos = new DeviceQueueCreateInfo[] { deviceQueueCreateInfos },
                QueueCreateInfoCount = 1,
            };
            return members.PhysicalDevice.CreateDevice(deviceCreateInfo);
        }
    }
}
