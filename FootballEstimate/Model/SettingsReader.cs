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
        public static T ReadData<T>(string folder, string fileName)
        {
            string fileContent = ReadContent(folder, fileName);
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

        private static string ReadContent(string folder, string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, folder, fileName);
            if (!File.Exists(path))
                return null;
            return File.ReadAllText(path);
        }

        public static void WriteData(string folder, string fileName, object o)
        {
            string content = JsonConvert.SerializeObject(o);
            WriteContent(folder, fileName, content);
        }

        private static void WriteContent(string folder, string fileName, string content)
        {
            string path = Path.Combine(Environment.CurrentDirectory, folder);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string fullPath = Path.Combine(Environment.CurrentDirectory, folder, fileName);
            File.WriteAllText(fullPath, content);
        }
    }
}
