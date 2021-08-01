using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory
{
    internal static class VulkanFastMemoryAllocation
    {
        public static DeviceMemory AllocateFastMemory(this VulkanMembers members)
        {
            uint memoryTypeIndex = VulkanFindMemoryType.GetIndex(members.PhysicalDevice, members.MemoryIndexing.SizeFast, true);

            MemoryAllocateInfo memoryAllocateInfo = new MemoryAllocateInfo()
            {
                MemoryTypeIndex = memoryTypeIndex,
                AllocationSize = members.MemoryIndexing.SizeFast
            };
            return members.Device.AllocateMemory(memoryAllocateInfo);
        }
    }
}
