using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;

namespace Task2v2
{
    class BranchesPage
    {
        private IWebDriver driver;

        private List<IWebElement> bnames;
        private List<IWebElement> bbehinds;
        private List<IWebElement> baheads;

        private Table<BranchRow> BranchTable;

        public BranchesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int CountBranches()
        {
            return driver.FindElements(By.ClassName("css-truncate")).Count;
        }

        public TreePage OpenBranch(string BranchName)
        {
            driver.Navigate().GoToUrl("https://github.com/costea32/AutomationTraining/tree/" + BranchName);
            return new TreePage(driver);
        }
/*
        public List<Branch> GetListOfBranches()
        {
            List<Branch> MyList = new List<Branch>();

            getItems();

            int count = CountBranches();

            for (int i = 0; i < count; i++)
            {
                TreePage ChildPage = new TreePage(driver);
                List<Record> ListOfItems = new List<Record>();
                string tempName = bnames[i].Text;
                ListOfItems = ChildPage.GetListOfItems("https://github.com/costea32/AutomationTraining/tree/" + tempName);
                
                ChildPage.BackToBranches();
                getItems();

                string branchName = bnames[i].Text;
                int ahead = Int32.Parse(baheads[i].Text.Substring(0, 2));
                int behind = Int32.Parse(bbehinds[i].Text.Substring(0, 2));
                int y = 1;
                MyList.Add(new Branch(bnames[i].Text, 
                    Int32.Parse(bbehinds[i].Text.Substring(0, 2)), 
                    Int32.Parse(baheads[i].Text.Substring(0, 2)), 
                    ListOfItems));

            }

            return MyList;
        }
*/
        private void getItems()
        {
            bnames = driver.FindElements(By.ClassName("css-truncate")).ToList();
            bbehinds = driver.FindElement(By.Id("js-repo-pjax-container")).FindElements(By.XPath("table[2]/tbody/tr/td[@class = 'state-widget']/div/span[@class = 'behind']/em")).ToList();
            baheads = driver.FindElement(By.Id("js-repo-pjax-container")).FindElements(By.XPath("table[2]/tbody/tr/td[@class = 'state-widget']/div/span[@class = 'ahead']/em")).ToList();
        }

        public Table<BranchRow> GetBranchTable()
        {
            BranchTable = new Table<BranchRow>();

            int count = CountBranches();

            getItems();

            for (int i = 0; i < count; i++)
            {
                string branchName = bnames[i].Text;
                int ahead = Int32.Parse(baheads[i].Text.Substring(0, 2));
                int behind = Int32.Parse(bbehinds[i].Text.Substring(0, 2));

                BranchTable.AddRow(new BranchRow(branchName, behind, ahead));
            }

            return BranchTable;
        }
    }
}
