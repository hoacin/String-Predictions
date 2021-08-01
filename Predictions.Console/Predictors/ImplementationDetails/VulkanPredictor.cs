namespace Predictions.TestConsole.Predictors.ImplementationDetails
{
    internal static class VulkanPredictor
    {
        public static ImplementationDetail Get()
        {
            return new ImplementationDetail()
            {
                Description = "Prototype of predictor utilizing cross-platform Vulkan library.",
                DisplayName = "Vulkan",
                Key = 'v',
                Implementation = PredictorType.Vulkan
            };
        }
    }
}
