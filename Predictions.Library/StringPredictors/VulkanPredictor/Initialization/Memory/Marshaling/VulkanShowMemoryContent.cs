using System;
using System.Runtime.InteropServices;
using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory.Marshaling
{
    internal static class VulkanShowMemoryContent
    {
        public static uint[] ShowMemoryContent(this VulkanMembers members, VulkanBufferType bufferType)
        {
            uint memorySize = members.GetMemorySize(bufferType);
            DeviceMemory memory = members.GetMemory(bufferType);

            IntPtr memoryPointer = members.Device.MapMemory(memory, members.GetMemoryOffset(bufferType), memorySize);
            byte[] bytes = new byte[memorySize];
            uint[] retVal = new uint[memorySize / 4];
            Marshal.Copy(memoryPointer, bytes, 0, bytes.Length);
            System.Buffer.BlockCopy(bytes, 0, retVal, 0, bytes.Length);
            members.Device.UnmapMemory(memory);
            return retVal;
        }
    }
}
