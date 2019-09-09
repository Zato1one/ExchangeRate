using ExchangeRate.BLL.Services.Models.Contracts;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ExchangeRate.BLL.Services.Services.Helpers
{
    internal static class XmlParser<T> where T : IXmlModel
    {
        public static T DeserializeXMLFile(string xmlFilePath)
        {
            using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                return Deserialize(fileStream);
            }
        }

        public static T DeserializeXMLString(string xmlString)
        {
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                return Deserialize(memoryStream);
            }
        }

        private static T Deserialize(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var reader = new XmlTextReader(stream))
            {
                if (serializer.CanDeserialize(reader))
                {
                    stream.Position = 0;
                    var result = (T)serializer.Deserialize(stream);
                    return result;
                }
                throw new Exception();
            }
        }
    }
}
