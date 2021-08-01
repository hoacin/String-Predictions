using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory
{
    internal static class VulkanWriteDescriptorSet
    {
        public static void UpdateDescriptorSet(this VulkanMembers members)
        {
            DescriptorBufferInfo[] bufferInfos = new DescriptorBufferInfo[]
            {
                new DescriptorBufferInfo()
                {
                    Buffer = members.SearchBuffer,
                    Range = members.MemoryIndexing.SizeOfSearchData
                },
                new DescriptorBufferInfo()
                {
                    Buffer = members.OutputBuffer,
                    Range = members.MemoryIndexing.SizeOfOutputDataFast
                },
                new DescriptorBufferInfo()
                {
                    Buffer = members.SearchInputBuffer,
                    Range = members.MemoryIndexing.SizeOfSearchData
                },
                new DescriptorBufferInfo()
                {
                    Buffer = members.ResultBuffer,
                    Range = 4
                },
            };
            WriteDescriptorSet writeDescriptorSet = new WriteDescriptorSet()
            {
                BufferInfo = bufferInfos,
                DstSet = members.DescriptorSet,
                DescriptorType = DescriptorType.StorageBuffer,
                DescriptorCount = 4,
            };
            members.Device.UpdateDescriptorSet(writeDescriptorSet, null);
        }
    }
}
