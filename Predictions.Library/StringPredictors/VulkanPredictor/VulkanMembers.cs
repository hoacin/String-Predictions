using Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Commands;
using Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization;
using Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory;
using Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory.Buffers;
using Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Memory.SearchInitialization;
using System;
using System.Threading.Tasks;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor
{
    internal sealed class VulkanMembers : IDisposable
    {
        private readonly string[] _phrases;

        public uint QueueFamilyIndex { get; private set; }
        public VulkanMemoryIndexing MemoryIndexing { get; private set; }
        public Vulkan.Instance Instance { get; private set; }
        public Vulkan.PhysicalDevice PhysicalDevice { get; private set; }
        public Vulkan.Device Device { get; private set; }
        public Vulkan.QueueFamilyProperties QueueFamilyProperties { get; private set; }
        public Vulkan.Queue Queue { get; private set; }
        public Vulkan.DeviceMemory FastMemory { get; private set; }
        public Vulkan.DeviceMemory SlowMemory { get; private set; }
        public Vulkan.CommandPool CommandPool { get; private set; }
        public Vulkan.CommandBuffer CommandBuffer { get; private set; }
        public Vulkan.DescriptorPool DescriptorPool { get; private set; }
        public Vulkan.DescriptorSetLayout DescriptorSetLayout { get; private set; }
        public Vulkan.DescriptorSet DescriptorSet { get; private set; }
        public Vulkan.PipelineLayout PipelineLayout { get; private set; }

        public Vulkan.Pipeline SearchPipeline { get; private set; }
        public Vulkan.Pipeline SearchInitPipeline { get; private set; }
        public Vulkan.Pipeline ReducePipeline { get; private set; }
        public Vulkan.Pipeline ResultPipeline { get; private set; }

        public Vulkan.Buffer SearchBuffer { get; private set; }
        public Vulkan.Buffer SearchInputBuffer { get; private set; }
        public Vulkan.Buffer OutputBuffer { get; private set; }
        public Vulkan.Buffer ResultBuffer { get; private set; }

        public VulkanMembers(string[] phrases)
        {
            _phrases = phrases;
        }

        public Task InitAsync()
        {
            Instance = VulkanInstance.Create();
            PhysicalDevice = this.GetPhysicalDevice();
            QueueFamilyProperties = this.GetQueueFamilyProperties(out uint queueFamilyIndex);
            QueueFamilyIndex = queueFamilyIndex;
            Device = this.CreateDevice();
            MemoryIndexing = new VulkanMemoryIndexing((uint)_phrases.Length);
            FastMemory = this.AllocateFastMemory();
            SlowMemory = this.AllocateSlowMemory();

            SearchBuffer = this.CreateSearchBuffer();
            OutputBuffer = this.CreateOutputBuffer();
            SearchInputBuffer = this.CreateSearchInputBuffer();
            ResultBuffer = this.CreateResultBuffer();

            this.BindBufferMemory();
            Queue = this.GetQueue();
            DescriptorPool = this.CreateDescriptorPool();
            DescriptorSetLayout = this.GetDescriptorSetLayout();
            DescriptorSet = this.AllocateDescriptorSet();
            this.UpdateDescriptorSet();
            PipelineLayout = this.CreatePipelineLayout();
            this.CreatePipelines(out Vulkan.Pipeline searchPipeline, out Vulkan.Pipeline reducePipeline,
                out Vulkan.Pipeline searchInitPipeline, out Vulkan.Pipeline resultPipeline);
            SearchPipeline = searchPipeline;
            ReducePipeline = reducePipeline;
            SearchInitPipeline = searchInitPipeline;
            ResultPipeline = resultPipeline;

            CommandPool = this.CreateCommandPool();
            CommandBuffer = this.AllocateCommandBuffer();

            return this.FillWithSearchDataAsync(_phrases);
        }
        public void Dispose()
        {
            Device.FreeMemory(FastMemory);
            Device.FreeMemory(SlowMemory);
            Device.FreeCommandBuffer(CommandPool, CommandBuffer);
            Device.FreeDescriptorSet(DescriptorPool, DescriptorSet);
            Instance.Dispose();
        }
    }
}
