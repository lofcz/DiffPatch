using System.IO;
using System.Reflection;

namespace DiffPatch.Tests
{
    class DataSetHelper
    {
        public static async Task<string?> ReadFileContent(string dataSetId, string filename)
        {
            Assembly assembly = typeof(DiffParserTests).GetTypeInfo().Assembly;
            string assemblyName = assembly.GetName().Name;
            string resourceName = $"{assemblyName}.DataSets.{dataSetId}.{filename}";

            await using Stream stream = assembly.GetManifestResourceStream(resourceName);

            if (stream is null)
            {
                return null;
            }
            
            using StreamReader reader = new StreamReader(stream);
            string fileContent = await reader.ReadToEndAsync();
            return fileContent;
        }
    }
}
