using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory.Buffers
{
    internal static class VulkanOutputMemoryBuffer
    {
        public static Buffer CreateOutputBuffer(this VulkanMembers members)
        {
            BufferCreateInfo bufferCreateInfo = new BufferCreateInfo()
            {
                SharingMode = SharingMode.Exclusive,
                Usage = BufferUsageFlags.StorageBuffer,
                QueueFamilyIndices = new uint[] { members.QueueFamilyIndex },
                Size = members.MemoryIndexing.SizeOfOutputDataFast,
            };
            return members.Device.CreateBuffer(bufferCreateInfo);
        }
    }
}
