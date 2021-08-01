namespace Predictions.TestConsole.Predictors.ImplementationDetails
{
    internal static class IlgpuSimplePredictor
    {
        public static ImplementationDetail Get()
        {
            return new ImplementationDetail()
            {
                Description = "Simple predictor utilizing graphics card with ILGPU library.",
                DisplayName = "ILGPU",
                Key = 'i',
                Implementation = PredictorType.IlgpuCudaSimple
            };
        }
    }
}
