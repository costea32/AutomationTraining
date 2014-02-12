using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Text;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Iheritance_Web_subproject_rework
{   
    class Program
    {
        const string path_txt = @"C:\temp\out_txt.txt";
        const string path_xml = @"C:\temp\out_xml.xml";
        
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            StreamWriter xml_writer = new StreamWriter(path_xml,true);
            try
            {
                driver.Url = "https://github.com/costea32/AutomationTraining/tree/ikulpin/Task1/Task1.Test";
                //driver.Url = "https://github.com/costea32/AutomationTraining/branches";
                SourcePage s_page = new SourcePage(driver);
                HandleSourcepage(s_page);                
            }
            finally
            {
                driver.Quit();
            }


            Console.ReadLine();
            
        }

        private static void WriteStringToFile(string s)
        {
            StreamWriter outWriter = new StreamWriter(path_txt, true);
            outWriter.Write(s);
            outWriter.Close();
        }

        private static void WriteXMLStringToFile(string s)
        {
            StreamWriter outXMLWriter = new StreamWriter(path_xml,true);
            outXMLWriter.WriteLine(s);
            outXMLWriter.Close();
        }

        private static void HandleSourcepage(SourcePage sPage)
        {
            foreach (SourceRow sRow in sPage.Table.Rows)
            {
                string jsonString = ConvertSourceRowToJSONString(sRow);
                string xmlString = ConvertSourceRowToXMLString(sRow);

                if (sRow.HasChildren)
                {
                    jsonString = HandleString(jsonString);
                    xmlString = HandleStringXML(xmlString);

                    WriteStringToFile(jsonString);
                    WriteXMLStringToFile(xmlString);

                    IWebDriver subdriver = new FirefoxDriver();
                    subdriver.Url = sRow.Href;
                    HandleSourcepage(new SourcePage(subdriver));

                    WriteStringToFile("}]");
                    WriteXMLStringToFile("</Children>");
                }
                else
                {
                    WriteStringToFile("\r\n" + jsonString);
                    WriteXMLStringToFile("\r\n"+xmlString);
                }
            }
        }

        private static string HandleString(string s)
        {
            s = s.Substring(0,s.Length-1);
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(s);
            sb.Append(" , \"Children:\"");
            return sb.ToString() ;
        }

        private static string HandleStringXML(string s)
        {
            s = s + "<Children>";
            return s;
        }
        private static string ConvertSourceRowToJSONString(SourceRow sRow)
        {
            
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(SourceRowDataContract ));
            SourceRowDataContract source_json = new SourceRowDataContract(sRow);
            MemoryStream m_stream = new MemoryStream();

            ser.WriteObject(m_stream, source_json);
            string json_string = Encoding.Default.GetString(m_stream.ToArray());

            return json_string;
        }

        private static string ConvertSourceRowToXMLString(SourceRow sRow)
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(SourceRowDataContract));
            SourceRowDataContract sourceXML = new SourceRowDataContract(sRow);
            MemoryStream mStream = new MemoryStream();

            ser.WriteObject(mStream,sourceXML);
            string xmlString = Encoding.Default.GetString(mStream.ToArray());

            return xmlString;
        }


    }
}
