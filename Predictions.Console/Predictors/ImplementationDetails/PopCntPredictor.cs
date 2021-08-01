namespace Predictions.TestConsole.Predictors.ImplementationDetails
{
    internal static class PopCntPredictor
    {
        public static ImplementationDetail Get()
        {
            return new ImplementationDetail()
            {
                Description = "Predictor utilizing Parallel.For and X86 PopCnt instruction.",
                DisplayName = "Parallel PopCnt",
                Key = 'p',
                Implementation = PredictorType.CSharpMultiCorePopCnt
            };
        }
    }
}
