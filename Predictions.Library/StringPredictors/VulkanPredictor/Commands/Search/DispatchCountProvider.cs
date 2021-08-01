namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands.Search
{
    internal static class DispatchCountProvider
    {
        public static int GetDixpatchX(int threadsPerBlock, int numberOfWords)
        {
            if (numberOfWords % threadsPerBlock > 0)
                return numberOfWords / threadsPerBlock + 1;
            return numberOfWords / threadsPerBlock;
        }
    }
}
