using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Iheritance_Web_subproject_rework
{
    class SourceStrategy:IPageStrategy
    {
        const string path_txt = @"C:\temp\out_txt.txt";
        const string path_xml = @"C:\temp\out_xml.xml";

        public void Algorithm(IWebDriver driver)
        {
            SourcePage s_page = new SourcePage(driver);
            List<SourceFile> files = HandleSourcepage(s_page);
            WriteToXMLFile(files);
            WriteToJSONFile(files);
        }

        private static List<SourceFile> HandleSourcepage(SourcePage sPage)
        {
            List<SourceFile> files = new List<SourceFile>();
            foreach (SourceRow sRow in sPage.Table.Rows)
            {
                if (sRow.HasChildren)
                {
                    using (IWebDriver subdriver = new FirefoxDriver())
                    {
                        subdriver.Url = sRow.Href;
                        SourceFolder folder = new SourceFolder
                        {
                            Name = sRow.Name,
                            Type = sRow.Type,
                            Last_updated = sRow.Last_updated,
                            Comment = sRow.Comment,
                            IsAFolder = sRow.HasChildren,
                            Children = HandleSourcepage(new SourcePage(subdriver))
                        };
                        files.Add(folder);
                    }
                }
                else
                {
                    files.Add(new SourceFile { Name = sRow.Name, Type = sRow.Type, Comment = sRow.Comment, Last_updated = sRow.Last_updated, IsAFolder = sRow.HasChildren });
                }
            }

            return files;
        }

        private static void WriteToXMLFile(List<SourceFile> files)
        {
            foreach (SourceFile sFile in files)
            {
                DataContractSerializer ser;
                MemoryStream mStream = new MemoryStream();
                StreamWriter sWriter = new StreamWriter(path_xml, true);

                if (sFile.IsAFolder) ser = new DataContractSerializer(typeof(SourceFolder));
                else ser = new DataContractSerializer(typeof(SourceFile));

                ser.WriteObject(mStream, sFile);
                string xmlString = Encoding.Default.GetString(mStream.ToArray());
                sWriter.Write(xmlString);
                sWriter.Close();

            }
        }

        private static void WriteToJSONFile(List<SourceFile> files)
        {
            foreach (SourceFile sFile in files)
            {
                DataContractJsonSerializer ser;
                MemoryStream mStream = new MemoryStream();
                StreamWriter sWriter = new StreamWriter(path_txt, true);

                if (sFile.IsAFolder) ser = new DataContractJsonSerializer(typeof(SourceFolder));
                else ser = new DataContractJsonSerializer(typeof(SourceFile));

                ser.WriteObject(mStream, sFile);
                string jsonString = Encoding.Default.GetString(mStream.ToArray());
                sWriter.Write(jsonString);
                sWriter.Close();

            }
        }

    }
}
