using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory.Buffers
{
    internal static class VulkanResultMemoryBuffer
    {
        public static Vulkan.Buffer CreateResultBuffer(this VulkanMembers members)
        {
            BufferCreateInfo bufferCreateInfo = new BufferCreateInfo()
            {
                SharingMode = SharingMode.Exclusive,
                Usage = BufferUsageFlags.StorageBuffer,
                QueueFamilyIndices = new uint[] { members.QueueFamilyIndex },
                Size = 4,
            };
            return members.Device.CreateBuffer(bufferCreateInfo);
        }
    }
}
