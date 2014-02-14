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
    class BranchStrategy : IPageStrategy
    {
        const string path_txt = @"C:\temp\out_txt.txt";
        const string path_xml = @"C:\temp\out_xml.xml";

        public void Algorithm(IWebDriver driver)
        {
            BranchesPage b_page = new BranchesPage(driver);
            List<BranchFolder> folders = HandleBranchPage(b_page);
            WriteToXMLBranch(folders);
            WriteToJSONBranch(folders);
        }

        private static List<BranchFolder> HandleBranchPage(BranchesPage bPage)
        {
            List<BranchFolder> folders = new List<BranchFolder>();

            List<BranchRow> rows = new List<BranchRow>();//only 1 row for testing
            rows.Add(bPage.BranchTable.Rows[2]);//remove to itirate through the whole page

            foreach (BranchRow bRow in rows) //bPage.BranchTable.Rows
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
        private static void WriteToXMLBranch(List<BranchFolder> folders)
        {
            foreach (BranchFolder bFolder in folders)
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(BranchFolder));
                MemoryStream mStream = new MemoryStream();
                StreamWriter sWriter = new StreamWriter(path_xml, true);

                ser.WriteObject(mStream, bFolder);
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
                StreamWriter sWriter = new StreamWriter(path_txt, true);

                ser.WriteObject(mStream, bFolder);
                string xmlString = Encoding.Default.GetString(mStream.ToArray());
                sWriter.Write(xmlString);
                sWriter.Close();
                mStream.Close();
            }
        }
       

    }
}
