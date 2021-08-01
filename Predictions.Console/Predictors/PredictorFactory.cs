using Predictions.Library.NetCore.StringPredictors.Ilgpu;
using Predictions.Library.NetCore.StringPredictors.Ilgpu.Factory;
using Predictions.Library.NetStandard;
using Predictions.Library.NetStandard.StringPredictors.CSharpDefault;
using Predictions.Library.NetStandard.StringPredictors.CSharpMultiCore;
using Predictions.Library.NetStandard.StringPredictors.VulkanPredictor;
using Predictions.TestConsole.Helpers;
using System;

namespace Predictions.TestConsole.Predictors
{
    static class PredictorFactory
    {
        public static IStringPredictor Instantiate(string[] phrases, PredictorType predictorType)
        {

            return predictorType switch
            {
                PredictorType.CSharpSingleCore => new SingleCoreStringPredictor(phrases),
                PredictorType.CSharpMultiCore => new MultiCoreStringPredictor(phrases),
                PredictorType.CSharpMultiCorePopCnt => new MultiCoreStringPredictor(phrases, PopCntPredictAction.PredictAsync),
                PredictorType.IlgpuCudaSimple => new IlgpuStringPredictor(phrases, AcceleratorType.Simple),
                PredictorType.IlgpuCudaCoalesced => new IlgpuStringPredictor(phrases, AcceleratorType.Coalesced),
                PredictorType.Vulkan => new VulkanStringPredictor(phrases),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
