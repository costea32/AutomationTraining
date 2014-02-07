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

        public BranchesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int CountBranches()
        {
            int count = driver.FindElements(By.ClassName("css-truncate")).Count;
            return count;
        }

        public TreePage OpenBranch(string BranchName)
        {
            driver.Navigate().GoToUrl(driver.Url + BranchName);
            return new TreePage(driver);
        }

        public List<Branch> GetListOfBranches()
        {
            List<Branch> MyList= new List<Branch>();

            List<IWebElement> bnames = driver.FindElements(By.ClassName("css-truncate")).ToList();
            List<IWebElement> bbehinds = driver.FindElements(By.XPath("/html/body/div/div[3]/div[2]/div/div[2]/table[2]/tbody/tr/td[@class = 'state-widget']/div/span[@class = 'behind']/em")).ToList();
            List<IWebElement> baheads = driver.FindElements(By.XPath("/html/body/div/div[3]/div[2]/div/div[2]/table[2]/tbody/tr/td[@class = 'state-widget']/div/span[@class = 'ahead']/em")).ToList();

            int count = CountBranches();

            for (int i = 0; i < count; i++)
            {
                TreePage ChildPage = new TreePage(driver);
                ChildPage = OpenBranch(bnames[i].Text);

                List<Record> ListOfItems = new List<Record>();
                ListOfItems = ChildPage.GetListOfItems();

                MyList.Add(new Branch(bnames[i].Text, 
                    Int32.Parse(bbehinds[i].Text.Substring(0, 2)), 
                    Int32.Parse(baheads[i].Text.Substring(0, 2)), 
                    driver.Url + bnames[i].Text,
                    ListOfItems));
            }

            return MyList;
        }
    }
}
