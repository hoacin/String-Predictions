using System.IO;
using System.Reflection;

namespace Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Shaders
{
    internal static class VulkanSpirvLoader
    {
        public static byte[] GetShaderBytes(string shaderName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = $"Predictions.Library.NetStandard.StringPredictors.VulkanPredictor.Initialization.Shaders.Data.{shaderName}.spv";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
