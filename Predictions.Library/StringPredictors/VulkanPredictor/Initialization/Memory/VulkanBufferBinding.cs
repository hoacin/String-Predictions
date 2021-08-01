namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory
{
    internal static class VulkanBufferBinding
    {
        public static void BindBufferMemory(this VulkanMembers members)
        {
            members.Device.BindBufferMemory(members.SearchBuffer, members.FastMemory, members.MemoryIndexing.SearchBufferOffsetFast);
            members.Device.BindBufferMemory(members.OutputBuffer, members.FastMemory, members.MemoryIndexing.OutputBufferOffsetFast);
            members.Device.BindBufferMemory(members.SearchInputBuffer, members.SlowMemory, members.MemoryIndexing.SearchBufferOffsetSlow);
            members.Device.BindBufferMemory(members.ResultBuffer, members.SlowMemory, members.MemoryIndexing.ResultOffsetSlow);
        }
    }
}
