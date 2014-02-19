using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task2v2
{
    class Program
    {
        static void Main(string[] args)
        {
//            IWebDriver driver = new FirefoxDriver();
            IWebDriver driver = new ChromeDriver(@"C:\Users\goncharenkoa\Downloads\chromedriver_win32");
            driver.Navigate().GoToUrl("https://github.com/login");

            LoginPage Login = new LoginPage(driver);
            BranchesPage Branches = Login.Do("alina-goncearenco", "MyPassword1");

            List<Branch> ListOfBranches = new List<Branch>();
            ListOfBranches = GetBranchesWithChildren(Branches);

            driver.Close();
            Console.WriteLine("\nBranch list created.\n");

            ConverterContext ctx = new ConverterContext();
            ctx.SetConverter(new ConvertToJson());
            ctx.Convert(ListOfBranches);

            Console.WriteLine("\nJson output file created.\n");

            ctx.SetConverter(new ConvertToXml());
            ctx.Convert(ListOfBranches);

            Console.WriteLine("\nXML output file created.\n");

            Console.WriteLine("\nTest finished!");
            Console.ReadLine();
        }

        public static List<Branch> GetBranchesWithChildren(BranchesPage BranchPage)
        {
            List<Branch> BranchList = new List<Branch>();

            BranchTable branchTable = BranchPage.GetBranchTable();

            foreach (BranchRow r in branchTable.Rows)
            {
                if (r.BranchName.Contains("prodausv"))
                {
                    List<Record> ListOfItems = new List<Record>();

                    TreePage ChildPage = BranchPage.OpenBranch(r.BranchName);
                    ListOfItems = GetFoldersAndChildren(ChildPage);
                    BranchList.Add(new Branch(r.BranchName, r.Behind, r.Ahead, ListOfItems));
                }
                else continue;
            }

            return BranchList;
        }
/*
        public static List<Record> GetFoldersAndChildren(TreePage CurrentPage)
        {

            string currentUrl = CurrentPage.GetURL();

            List<Record> TreeList = new List<Record>();

            Table<ItemRow> itemTable = CurrentPage.GetTreeTable();

            int count = itemTable.CountRows();

            for (int i = 0; i < count; i++)
            {
                ItemRow r = itemTable.GetRow(i);

                if (r.Type == "Folder")
                {
                    List<Record> Children = new List<Record>();
                    TreePage ChildPage = CurrentPage.OpenNextPage(r.Name);
                    Children = GetFoldersAndChildren(ChildPage);
                    CurrentPage.RefreshPage(currentUrl);
                    TreeList.Add(new Folder(r.Name, r.Comment, r.Age, Children));
                }

                else
                {
                    TreeList.Add(new File(r.Name, r.Comment, r.Age));
                }
            }

            return TreeList;
        }
 */

        public static List<Record> GetFoldersAndChildren(TreePage CurrentPage)
        {
            string currentUrl = CurrentPage.GetURL();

            List<Record> TreeList = new List<Record>();

            ItemTable itemTable = CurrentPage.GetTreeTable();

            //int count = itemTable.CountRows();

            foreach (var r in itemTable.Rows)
//            for (int i = 0; i < count; i++)
            {
 //               ItemRow r = itemTable.GetRow(i);

                if (r.Type == "Folder")
                {
                    TreeList.Add(new Folder(r.Name, r.Comment, r.Age));
                }

                else
                {
                    TreeList.Add(new File(r.Name, r.Comment, r.Age));
                }
            }

            foreach(Record r in TreeList)

//            for (int i = 0; i < count; i++)
            {
                if (r.GetType() == typeof(Folder))
                {
                    List<Record> Children = new List<Record>();
                    TreePage ChildPage = CurrentPage.OpenNextPage(r.Name);
                    Children = GetFoldersAndChildren(ChildPage);
                    CurrentPage.RefreshPage(currentUrl);
                    r.AddChildren(Children);
                }
                else
                    continue;
            }

            return TreeList;
        }
    }
}
