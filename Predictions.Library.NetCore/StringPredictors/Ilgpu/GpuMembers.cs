using ILGPU;
using ILGPU.Runtime;
using Predictions.Library.NetCore.StringPredictors.Ilgpu.Factory;
using Predictions.Library.NetCore.StringPredictors.Ilgpu.Kernels;
using Predictions.Library.NetStandard.SearchData;
using System;
using System.Threading.Tasks;

namespace Predictions.Library.NetCore.StringPredictors.Ilgpu
{
    internal sealed class GpuMembers : IDisposable
    {
        public Accelerator Accelerator { get; private set; }
        public Context Context { get; private set; }
        public Action<Index1, ArrayView<uint>, ArrayView<uint>, ArrayView<uint>, int> MutualPairsKernel { get; private set; }
        public MemoryBuffer<uint> SearchData { get; private set; }
        public MemoryBuffer<uint> OutputData { get; private set; }
        public MemoryBuffer<uint> SearchedWord { get; private set; }
        public int RowOffset { get; private set; }

        public Task InitAsync(string[] phrases, Factory.AcceleratorType type)
        {
            return Task.Run(() =>
            {
                Context = new Context();
                Context.EnableAlgorithms();
                Accelerator = AcceleratorFactory.Instantiate(Context, type);
                bool coalesce = type == Factory.AcceleratorType.Coalesced;
                Action<Index1, ArrayView<uint>, ArrayView<uint>, ArrayView<uint>, int> kernel = coalesce ? CoalescedKernel.Get : SimpleKernel.Get;
                MutualPairsKernel = Accelerator.LoadAutoGroupedStreamKernel(kernel);
                uint[] searchData = phrases.GetSearchData().OptimizeForCoalescing(coalesce);
                RowOffset = phrases.Length + (phrases.Length % 128 > 0 ? (128 - phrases.Length % 128) : 0);
                SearchData = Accelerator.Allocate(searchData);
                OutputData = Accelerator.Allocate<uint>(4 * phrases.Length);
                SearchedWord = Accelerator.Allocate<uint>(41);
            });
        }
        public void Dispose()
        {
            SearchData.Dispose();
            SearchedWord.Dispose();
            OutputData.Dispose();
            Accelerator.Dispose();
            Context.Dispose();
        }
    }
}
