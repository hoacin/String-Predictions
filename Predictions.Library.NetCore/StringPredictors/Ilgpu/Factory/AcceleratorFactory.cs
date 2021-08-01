using ILGPU;
using ILGPU.Runtime;
using ILGPU.Runtime.CPU;
using ILGPU.Runtime.Cuda;

namespace Predictions.Library.NetCore.StringPredictors.Ilgpu.Factory
{
    internal static class AcceleratorFactory
    {
        public static Accelerator Instantiate(Context context, AcceleratorType acceleratorType)
        {
            return acceleratorType switch
            {
                AcceleratorType.Simple => new CudaAccelerator(context),
                AcceleratorType.Coalesced => new CudaAccelerator(context),
                _ => new CPUAccelerator(context),
            };

        }
    }
}
