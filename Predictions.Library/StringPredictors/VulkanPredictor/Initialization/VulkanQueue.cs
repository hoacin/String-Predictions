using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization
{
    internal static class VulkanQueue
    {
        public static Queue GetQueue(this VulkanMembers members)
        {
            return members.Device.GetQueue(members.QueueFamilyIndex, 0);
        }
    }
}
