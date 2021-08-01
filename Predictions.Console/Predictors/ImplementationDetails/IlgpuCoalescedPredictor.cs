namespace Predictions.TestConsole.Predictors.ImplementationDetails
{
    internal static class IlgpuCoalescedPredictor
    {
        public static ImplementationDetail Get()
        {
            return new ImplementationDetail()
            {
                Description = "Predictor showing performance boost caused by memory coalescing.",
                DisplayName = "ILGPU coalescing",
                Key = 'c',
                Implementation = PredictorType.IlgpuCudaCoalesced
            };
        }
    }
}
