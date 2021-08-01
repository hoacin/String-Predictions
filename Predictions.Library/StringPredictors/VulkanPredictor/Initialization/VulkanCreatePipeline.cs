using Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Shaders;
using Vulkan;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization
{
    internal static class VulkanCreatePipeline
    {
        public static void CreatePipelines(this VulkanMembers members, out Pipeline searchPipeline, out Pipeline reducePipeline, out Pipeline searchInitPipeline, out Pipeline resultPipeline)
        {
            ComputePipelineCreateInfo searchCreateInfo = new ComputePipelineCreateInfo()
            {
                Layout = members.PipelineLayout,
                Stage = VulkanShaderModule.GetCreateInfo(members.Device, "Search")
            };
            ComputePipelineCreateInfo reduceCreateInfo = new ComputePipelineCreateInfo()
            {
                Layout = members.PipelineLayout,
                Stage = VulkanShaderModule.GetCreateInfo(members.Device, "Reduce")
            };
            ComputePipelineCreateInfo searchInitCreateInfo = new ComputePipelineCreateInfo()
            {
                Layout = members.PipelineLayout,
                Stage = VulkanShaderModule.GetCreateInfo(members.Device, "Init")
            };
            ComputePipelineCreateInfo resultCreateInfo = new ComputePipelineCreateInfo()
            {
                Layout = members.PipelineLayout,
                Stage = VulkanShaderModule.GetCreateInfo(members.Device, "Result")
            };

            Pipeline[] pipelines = members.Device.CreateComputePipelines(null, new ComputePipelineCreateInfo[] { searchCreateInfo, reduceCreateInfo, searchInitCreateInfo, resultCreateInfo });
            searchPipeline = pipelines[0];
            reducePipeline = pipelines[1];
            searchInitPipeline = pipelines[2];
            resultPipeline = pipelines[3];
        }
    }
}
