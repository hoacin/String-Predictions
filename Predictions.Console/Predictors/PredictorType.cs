namespace Predictions.TestConsole.Predictors
{
    internal enum PredictorType
    {
        CSharpSingleCore,
        CSharpMultiCore,
        CSharpMultiCorePopCnt,
        IlgpuCudaSimple,
        IlgpuCudaCoalesced,
        Vulkan
    }
}
