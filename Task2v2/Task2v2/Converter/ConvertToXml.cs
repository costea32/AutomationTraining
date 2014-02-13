using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Xml;
using System.Xml.Serialization;

namespace Task2v2
{
    class ConvertToXml : Converter
    {
        public void ConvertToFile(List<Branch> branchList)
        {
            string output = @"C:\Users\goncharenkoa\Documents\Task2_output\XML_output.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(List<Branch>));
            TextWriter testXML = new StreamWriter(output);
            serializer.Serialize(testXML, branchList);
/*            XmlTextWriter testXML = new XmlTextWriter(output, Encoding.UTF8); //new XML file created
            testXML.WriteStartDocument(); //header line added
            testXML.WriteStartElement("Branches"); //<Branches> tag added
            testXML.WriteEndElement(); //</Branches> tag closed
*/
            testXML.Close(); //XML file closed
            Console.WriteLine("\nXML file created.\n");
/*
            XmlDocument content = new XmlDocument(); //object to add content to the XML file
            content.Load(output);
*/
        }
    }
}
