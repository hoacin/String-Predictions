using ILGPU.Algorithms;
using ILGPU.Algorithms.ScanReduceOperations;
using Predictions.Library.NetStandard.StringOperations;
using System.Threading.Tasks;

namespace Predictions.Library.NetCore.StringPredictors.Ilgpu
{
    internal static class PredictAction
    {
        internal static Task<string> PredictAsync(GpuMembers gpu, string input, string[] phrases)
        {
            return Task.Run(() =>
            {
                //Preparing searched word
                uint[] searchDataHelper = input.GetSearchData();
                gpu.SearchedWord.CopyFrom(searchDataHelper, 0, 0, 41);
                //Calculating mutual pairs for every word with GPU kernel
                gpu.MutualPairsKernel(phrases.Length, gpu.SearchedWord, gpu.SearchData, gpu.OutputData, gpu.RowOffset);
                //Looking for max value in output array with parallel reduction
                uint maxValue = gpu.Accelerator.Reduce<uint, MaxUInt32>(gpu.Accelerator.DefaultStream, gpu.OutputData.View);
                return phrases[maxValue & 134217727];
            });
        }

    }
}
