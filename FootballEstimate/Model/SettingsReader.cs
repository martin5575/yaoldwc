using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballEstimate.Model
{
    class SettingsReader
    {
        public static T ReadData<T>(string fileName)
        {
            string fileContent = ReadContent(fileName);
            if (fileContent == null)
                return default(T);
            try {
                return JsonConvert.DeserializeObject<T>(fileContent);
            }
            catch(Exception e)
            {
                throw new InvalidDataException($"Could not read {fileName}!", e);
            }
        }

        private static string ReadContent(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            if (!File.Exists(path))
                return null;
            return File.ReadAllText(path);
        }

        public static void WriteData(string fileName, object o)
        {
            string content = JsonConvert.SerializeObject(o);
            WriteContent(fileName, content);
        }

        private static void WriteContent(string fileName, string content)
        {
            string fullPath = Path.Combine(Environment.CurrentDirectory, fileName);
            if (!File.Exists(fullPath))
            {
                var dir = Path.GetDirectoryName(fullPath);
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(fullPath, content);
        }
    }
}
