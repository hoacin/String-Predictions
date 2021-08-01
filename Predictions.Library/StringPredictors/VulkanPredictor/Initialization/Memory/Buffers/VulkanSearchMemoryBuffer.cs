using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory.Buffers
{
    internal static class VulkanSearchMemoryBuffer
    {
        public static Vulkan.Buffer CreateSearchBuffer(this VulkanMembers members)
        {
            BufferCreateInfo bufferCreateInfo = new BufferCreateInfo()
            {
                SharingMode = SharingMode.Exclusive,
                Usage = BufferUsageFlags.StorageBuffer,
                QueueFamilyIndices = new uint[] { members.QueueFamilyIndex },
                Size = members.MemoryIndexing.SizeOfSearchData,
            };

            return members.Device.CreateBuffer(bufferCreateInfo);
        }
    }
}
