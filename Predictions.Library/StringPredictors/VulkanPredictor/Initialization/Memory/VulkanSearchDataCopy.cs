using Predictions.Library.NetStandard.SearchData;
using Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands.Initialization;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory.SearchInitialization
{
    internal static class VulkanSearchDataCopy
    {
        public static Task FillWithSearchDataAsync(this VulkanMembers members, string[] phrases)
        {
            return Task.Run(() =>
            {
                uint[] searchData = phrases.GetSearchData().OptimizeForCoalescing(true);
                byte[] data = new byte[searchData.Length * 4];
                IntPtr memoryPtr = members.Device.MapMemory(members.SlowMemory, members.MemoryIndexing.SearchBufferOffsetSlow, members.MemoryIndexing.SizeOfSearchData);
                System.Buffer.BlockCopy(searchData, 0, data, 0, data.Length);
                Marshal.Copy(data, 0, memoryPtr, data.Length);
                members.Device.UnmapMemory(members.SlowMemory);
                members.InitLocalSearchBuffer();
            });
        }
    }
}
