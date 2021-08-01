namespace Predictions.TestConsole.Predictors.ImplementationDetails
{
    internal static class SingleCorePredictor
    {
        public static ImplementationDetail Get()
        {
            return new ImplementationDetail()
            {
                Description = "Simple predictor running on one CPU core.",
                DisplayName = "Single core",
                Key = 's',
                Implementation = PredictorType.CSharpSingleCore
            };
        }
    }
}
