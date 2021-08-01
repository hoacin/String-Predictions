using Predictions.TestConsole.Predictors.ImplementationDetails;

namespace Predictions.TestConsole.Predictors
{
    internal static class ListImplementations
    {
        public static ImplementationDetail[] GetAll()
        {
            return new ImplementationDetail[]
            {
                SingleCorePredictor.Get(),
                MultiCorePredictor.Get(),
                PopCntPredictor.Get(),
                IlgpuSimplePredictor.Get(),
                IlgpuCoalescedPredictor.Get(),
                VulkanPredictor.Get()
            };
        }
    }
}
