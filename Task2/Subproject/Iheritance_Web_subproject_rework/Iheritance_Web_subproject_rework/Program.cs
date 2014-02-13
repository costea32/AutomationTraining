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
            try
            {
                //driver.Url = "https://github.com/costea32/AutomationTraining/tree/ikulpin/Task1/Task1.Test";
                driver.Url = "https://github.com/costea32/AutomationTraining/branches";
                //SourcePage s_page = new SourcePage(driver);
                //List<SourceFile> files =  HandleSourcepage(s_page);
                //WriteToXMLFile(files);

                BranchesPage b_page = new BranchesPage(driver);
                List<BranchFolder> folders = HandleBranchPage(b_page);
                WriteToXMLBranch(folders);
                WriteToJSONBranch(folders);
            }
            finally
            {
                driver.Quit();
                Console.WriteLine("All done!");
            }
            Console.ReadLine();   
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
                    files.Add( new SourceFile {Name=sRow.Name, Type=sRow.Type, Comment=sRow.Comment, Last_updated=sRow.Last_updated , IsAFolder=sRow.HasChildren } );
                }
            }

            return files;
        }

        private static List<BranchFolder> HandleBranchPage(BranchesPage bPage)
        {
            List<BranchFolder> folders = new List<BranchFolder>();

            List<BranchRow> rows = new List<BranchRow>();//only 1 row
            rows.Add(bPage.BranchTable.Rows[0]);

            foreach (BranchRow bRow in rows)
            {
                using (IWebDriver subdriver = new FirefoxDriver())
                {
                    subdriver.Url = bRow.Href;
                    BranchFolder folder = new BranchFolder
                    {
                        Name = bRow.Name,
                        LastUpdated = bRow.Last_updated,
                        Href = bRow.Href,
                        Ahead = bRow.Ahead,
                        Behind = bRow.Behind,
                        Children = HandleSourcepage(new SourcePage(subdriver))
                    };
                    folders.Add(folder);
                }
            }
            return folders;
        }

        private static void WriteToXMLFile(List<SourceFile> files)
        {
            foreach (SourceFile sFile in files)
            {
                DataContractSerializer ser;
                MemoryStream mStream = new MemoryStream();
                StreamWriter sWriter = new StreamWriter(path_xml,true);

                if (sFile.IsAFolder) ser = new DataContractSerializer(typeof(SourceFolder));
                else ser = new DataContractSerializer(typeof(SourceFile));
                
                ser.WriteObject(mStream,sFile);
                string xmlString = Encoding.Default.GetString(mStream.ToArray());
                sWriter.Write(xmlString);
                sWriter.Close();

            }
        }

        private static void WriteToXMLBranch(List<BranchFolder> folders)
        {
            foreach (BranchFolder bFolder in folders)
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(BranchFolder));
                MemoryStream mStream = new MemoryStream();
                StreamWriter sWriter = new StreamWriter(path_xml,true);

                ser.WriteObject(mStream,bFolder);
                string xmlString = Encoding.Default.GetString(mStream.ToArray());
                sWriter.Write(xmlString);
                sWriter.Close();
                mStream.Close();
            }
        }

        private static void WriteToJSONBranch(List<BranchFolder> folders)
        {
            foreach (BranchFolder bFolder in folders)
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BranchFolder));
                MemoryStream mStream = new MemoryStream();
                StreamWriter sWriter = new StreamWriter(path_txt,true);

                ser.WriteObject(mStream,bFolder);
                string xmlString = Encoding.Default.GetString(mStream.ToArray());
                sWriter.Write(xmlString);
                sWriter.Close();
                mStream.Close();
            }
        }
        
    }
}
