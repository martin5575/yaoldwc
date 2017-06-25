using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Newtonsoft.Json;

namespace OpenLigaApi.Test
{
    [TestClass]
    public class DeserializerTest
    {
        private string ReadResource(string fileName)
        {
            var type = typeof(DeserializerTest);
            var assembly = type.Assembly;
            string resourceName = type.Namespace + ".Data." + fileName;
            using (Stream s = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader sr = new StreamReader(s))
                return sr.ReadToEnd();
        }



        [TestMethod]
        public void JsonDeserializerFullSeasonTest()
        {
            var json = ReadResource("bl1_2016.json");
            var data = JsonConvert.DeserializeObject<Match[]>(json);
            Assert.IsNotNull(data);
            Assert.AreEqual(306, data.Length);
        }
    }
}
