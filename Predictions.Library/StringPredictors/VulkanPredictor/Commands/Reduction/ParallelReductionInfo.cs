using System;
using System.Runtime.InteropServices;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands.Reduction
{
    internal sealed class ParallelReductionInfo : IDisposable
    {
        public uint DixpatchX { get; }
        public uint Wall { get; }
        public IntPtr Constants { get; }

        public ParallelReductionInfo(uint dispatchX, uint wall)
        {
            Wall = wall;
            DixpatchX = dispatchX;

            byte[] wallBytes = BitConverter.GetBytes(wall);
            Constants = Marshal.AllocHGlobal(4);
            Marshal.Copy(wallBytes, 0, Constants, 4);
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(Constants);
        }
    }
}
