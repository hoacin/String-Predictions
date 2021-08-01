namespace Predictions.TestConsole.Predictors.ImplementationDetails
{
    internal static class MultiCorePredictor
    {
        public static ImplementationDetail Get()
        {
            return new ImplementationDetail()
            {
                Description = "Predictor utilizing Parallel.For loop running on multiple cores.",
                DisplayName = "Parallel.For",
                Key = 'm',
                Implementation = PredictorType.CSharpMultiCore
            };
        }
    }
}
