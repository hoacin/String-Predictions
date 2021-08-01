using System;
using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization
{
    internal static class VulkanQueueFamilyProperties
    {
        public static QueueFamilyProperties GetQueueFamilyProperties(this VulkanMembers members, out uint queueFamilyIndex)
        {
            QueueFamilyProperties[] queueFamilyProperties = members.PhysicalDevice.GetQueueFamilyProperties();
            uint bestQueueFamilyIndex = 0xFFFFFFFF;
            for (int i = 0; i < queueFamilyProperties.Length; i++)
            {
                QueueFlags flags = queueFamilyProperties[i].QueueFlags;
                if (flags.HasFlag(QueueFlags.Compute))
                {
                    bestQueueFamilyIndex = (uint)i;
                    if (!flags.HasFlag(QueueFlags.Graphics) && !flags.HasFlag(QueueFlags.SparseBinding) && !flags.HasFlag(QueueFlags.Transfer))
                        break;
                }
            }
            if (bestQueueFamilyIndex == 0xFFFFFFFF)
                throw new Exception("No compute queue available.");
            queueFamilyIndex = bestQueueFamilyIndex;
            return queueFamilyProperties[queueFamilyIndex];
        }
    }
}
