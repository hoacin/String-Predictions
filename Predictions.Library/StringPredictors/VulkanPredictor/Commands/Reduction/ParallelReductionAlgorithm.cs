using System.Collections.Generic;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands.Reduction
{
    internal static class ParallelReductionAlgorithm
    {
        public static ParallelReductionInfo[] GetCycles(uint threadGroupSize, int numberOfWords)
        {
            uint numWords = (uint)numberOfWords;
            List<ParallelReductionInfo> steps = new List<ParallelReductionInfo>();
            for (int i = 0; numWords > 1; i++)
            {
                numWords /= 2;
                uint dispatchX = numWords / threadGroupSize;
                if (numWords % threadGroupSize > 0)
                    dispatchX++;
                steps.Add(new ParallelReductionInfo(dispatchX, numWords));
            }
            return steps.ToArray();
        }
    }
}
