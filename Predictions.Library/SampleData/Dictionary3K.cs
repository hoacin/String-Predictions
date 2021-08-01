using System.IO;
using System.Reflection;

namespace Predictions.Library.NetStandard.SampleData
{
    public static class Dictionary3K
    {
        public static string[] GetSampleData()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "Predictions.Library.NetStandard.SampleData.Words3k.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd().Trim();
                return result.Split("\r\n");
            }
        }
        public static string[] GetSampleData9M()
        {
            string[] dictionary = GetSampleData();
            int simpleSize = dictionary.Length;
            int poweredSize = simpleSize * simpleSize;
            string[] poweredDictionary = new string[poweredSize];
            for (int i = 0; i < poweredSize; i++)
                poweredDictionary[i] = $"{dictionary[i / 3000]} {dictionary[i % 3000]}";
            return poweredDictionary;
        }

    }
}
