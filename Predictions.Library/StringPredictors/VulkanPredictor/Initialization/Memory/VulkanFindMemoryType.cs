using System;
using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory
{
    internal static class VulkanFindMemoryType
    {
        public static uint GetIndex(PhysicalDevice physicalDevice, uint requiredSize, bool deviceMemory)
        {
            PhysicalDeviceMemoryProperties properties = physicalDevice.GetMemoryProperties();
            uint memoryTypeIndex = 0xFFFFFFFF;
            for (uint i = 0; i < properties.MemoryTypeCount; i++)
            {
                MemoryPropertyFlags flags = properties.MemoryTypes[i].PropertyFlags;
                if (deviceMemory && flags.HasFlag(MemoryPropertyFlags.DeviceLocal) ||
                    !deviceMemory && flags.HasFlag(MemoryPropertyFlags.HostVisible) && flags.HasFlag(MemoryPropertyFlags.HostCoherent))
                {
                    if (properties.MemoryHeaps[properties.MemoryTypes[i].HeapIndex].Size > requiredSize)
                    {
                        memoryTypeIndex = i;
                        break;
                    }
                }
            }
            if (memoryTypeIndex == 0xFFFFFFFF)
                throw new Exception("No memory available.");
            return memoryTypeIndex;
        }
    }
}
