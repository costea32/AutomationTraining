using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Task2v2
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://github.com/login");

            LoginPage Login = new LoginPage(driver);
            BranchesPage Branches = Login.Do("alina-goncearenco", "MyPassword1");

            List<Branch> ListOfBranches = new List<Branch>();
//            ListOfBranches = Branches.GetListOfBranches();
            ListOfBranches = GetBranchesWithChildren(Branches);

            driver.Close();
            Console.WriteLine("\nTest finished!");
            Console.ReadLine();
        }

        public static List<Branch> GetBranchesWithChildren(BranchesPage BranchPage)
        {
            List<Branch> BranchList = new List<Branch>();

            Table<BranchRow> branchTable = BranchPage.GetBranchTable();

            int count = branchTable.CountRows();

            for (int i = 0; i < count; i++)
            {
                List<Record> ListOfItems = new List<Record>();
                BranchRow r = new BranchRow(branchTable.GetRow(i));
                
                TreePage ChildPage = BranchPage.OpenBranch(r.BranchName);
                ListOfItems = GetFoldersAndChildren(ChildPage);
                BranchList.Add(new Branch(r.BranchName, r.Behind, r.Ahead, ListOfItems));
            }

            return BranchList;
        }

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
    }
}
