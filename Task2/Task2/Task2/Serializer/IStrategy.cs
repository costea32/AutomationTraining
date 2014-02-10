using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Task2
{
    public interface IStrategy
    {
        void Serialize(List<Container> containers);
    }

    public class JsonStrategy : IStrategy
    {
        List<Container> containers;
        string xmlPath = @"c:/Selenium/json.json";

        public void Serialize(List<Container> containers)
        {
            this.containers = containers;
            
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Container>));
            MemoryStream memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, containers);

            string json = Encoding.Default.GetString(memoryStream.ToArray());

            File.WriteAllText(xmlPath, json);
        }
    }

    public class XmlStrategy : IStrategy
    {
        List<Container> containers;
        string xmlPath = @"c:/Selenium/xml.xml";

        public void Serialize(List<Container> containers)
        {
            this.containers = containers;

            DataContractSerializer serializer = new DataContractSerializer(typeof(List<Container>));

            using (Stream stream = new FileStream(xmlPath, FileMode.Create, FileAccess.Write))
            {
                using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8))
                {
                    writer.WriteStartDocument();
                    serializer.WriteObject(writer, containers);
                }
            }
        }
    }

}
