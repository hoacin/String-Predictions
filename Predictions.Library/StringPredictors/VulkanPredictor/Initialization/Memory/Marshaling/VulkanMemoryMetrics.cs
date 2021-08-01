using System;
using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory.Marshaling
{
    internal static class VulkanMemoryMetrics
    {
        public static uint GetMemoryOffset(this VulkanMembers members, VulkanBufferType bufferType)
        {
            return bufferType switch
            {
                VulkanBufferType.SearchDataInit => members.MemoryIndexing.SearchBufferOffsetFast,
                VulkanBufferType.Result => members.MemoryIndexing.ResultOffsetSlow,
                VulkanBufferType.LocalSearchData => members.MemoryIndexing.SearchBufferOffsetFast,
                VulkanBufferType.LocalOutputData => members.MemoryIndexing.OutputBufferOffsetFast,
                _ => throw new NotImplementedException()
            };
        }
        public static uint GetMemorySize(this VulkanMembers members, VulkanBufferType bufferType)
        {
            return bufferType switch
            {
                VulkanBufferType.SearchDataInit => members.MemoryIndexing.SizeOfSearchData,
                VulkanBufferType.Result => 4,
                VulkanBufferType.LocalSearchData => members.MemoryIndexing.SizeOfSearchData,
                VulkanBufferType.LocalOutputData => members.MemoryIndexing.SizeOfOutputDataFast,
                _ => throw new NotImplementedException()
            };
        }
        public static DeviceMemory GetMemory(this VulkanMembers members, VulkanBufferType bufferType)
        {
            return bufferType switch
            {
                VulkanBufferType.SearchDataInit => members.SlowMemory,
                VulkanBufferType.Result => members.SlowMemory,
                VulkanBufferType.LocalSearchData => members.FastMemory,
                VulkanBufferType.LocalOutputData => members.FastMemory,
                _ => throw new NotImplementedException()
            };
        }
    }
}
