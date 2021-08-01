namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory
{
    internal class VulkanMemoryIndexing
    {
        public uint SearchBufferOffsetFast { get; }
        public uint OutputBufferOffsetFast { get; }
        public uint SizeOfOutputDataFast { get; }

        public uint SizeOfSearchData { get; }
        public uint SizeFast { get; }

        public uint SizeSlow { get; }
        public uint SearchBufferOffsetSlow { get; }
        public uint ResultOffsetSlow { get; }

        public VulkanMemoryIndexing(uint numberOfWords)
        {
            SearchBufferOffsetFast = 0;
            SizeOfSearchData = 4 * (41 * numberOfWords + 40 * (numberOfWords % 128 > 0 ? 128 - numberOfWords % 128 : 0));
            OutputBufferOffsetFast = SearchBufferOffsetFast + SizeOfSearchData + 1024 - SizeOfSearchData % 1024;
            SizeOfOutputDataFast = numberOfWords * 4;
            ResultOffsetSlow = OutputBufferOffsetFast;
            SizeFast = OutputBufferOffsetFast + SizeOfOutputDataFast;
            SizeSlow = ResultOffsetSlow + 1024;
        }
    }
}
