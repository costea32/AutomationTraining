using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Xml;
using System.Runtime.Serialization;

namespace Task2v2
{
    class ConvertToXml : Converter
    {
        public void ConvertToFile(List<Branch> branchList)
        {
            string timeStamp = DateTime.Now.ToString().Replace("/","_").Replace(":","-");
            string output = @"C:\Users\goncharenkoa\Documents\Task2_output\XML_output_" + timeStamp + ".xml";

            FileStream writer = new FileStream(output, FileMode.Create);
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<Branch>));
            
            foreach (Branch b in branchList)
            {
                serializer.WriteObject(writer, b);
            }

            writer.Close();
            Console.WriteLine("\nXML file created.\n");
        }
    }
}
