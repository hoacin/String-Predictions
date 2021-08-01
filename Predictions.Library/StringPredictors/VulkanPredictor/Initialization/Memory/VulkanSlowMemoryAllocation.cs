using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory
{
    internal static class VulkanSlowMemoryAllocation
    {
        public static DeviceMemory AllocateSlowMemory(this VulkanMembers members)
        {
            uint memoryTypeIndex = VulkanFindMemoryType.GetIndex(members.PhysicalDevice, members.MemoryIndexing.SizeSlow, false);

            MemoryAllocateInfo memoryAllocateInfo = new MemoryAllocateInfo()
            {
                MemoryTypeIndex = memoryTypeIndex,
                AllocationSize = members.MemoryIndexing.SizeSlow
            };
            return members.Device.AllocateMemory(memoryAllocateInfo);
        }
    }
}
