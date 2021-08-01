using Predictions.Library.NetStandard.StringOperations;
using System;
using System.Runtime.InteropServices;
using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands.Search
{
    internal static class SearchDataPushing
    {
        public static void PushSearchData(this VulkanMembers members, int numberOfWords, string searchedWord)
        {
            uint[] pushDataUint = new uint[43];
            uint[] searchData = searchedWord.GetSearchData();
            pushDataUint[0] = (uint)numberOfWords;
            pushDataUint[1] = (uint)(numberOfWords + (numberOfWords % 128 > 0 ? (128 - numberOfWords % 128) : 0));
            Array.Copy(searchData, 0, pushDataUint, 2, 41);
            byte[] pushData = new byte[172];
            System.Buffer.BlockCopy(pushDataUint, 0, pushData, 0, pushData.Length);
            IntPtr unmanagedPointer = Marshal.AllocHGlobal(pushData.Length);
            Marshal.Copy(pushData, 0, unmanagedPointer, pushData.Length);
            members.CommandBuffer.CmdPushConstants(members.PipelineLayout, ShaderStageFlags.Compute, 0, (uint)pushData.Length, unmanagedPointer);
            Marshal.FreeHGlobal(unmanagedPointer);
        }
    }
}
