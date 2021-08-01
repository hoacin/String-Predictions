namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory.Marshaling
{
    internal enum VulkanBufferType
    {
        SearchDataInit,
        Result,
        LocalSearchData, //Won't work in production
        LocalOutputData, //Won't work in production
    }
}
