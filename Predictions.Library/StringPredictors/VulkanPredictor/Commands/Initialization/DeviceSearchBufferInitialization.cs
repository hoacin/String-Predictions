namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands.Initialization
{
    internal static class DeviceSearchBufferInitialization
    {
        public static void InitLocalSearchBuffer(this VulkanMembers members)
        {
            //Copying data from host visible to device local memory with "Init.spv"
            members.BeginSubmit(PipelineType.SearchInit);
            members.CommandBuffer.CmdDispatch(members.MemoryIndexing.SizeOfSearchData / 4, 1, 1);
            members.EndSubmit();
        }
    }
}
