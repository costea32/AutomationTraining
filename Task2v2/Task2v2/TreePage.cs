using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;

namespace Task2v2
{
    class TreePage
    {
        private IWebDriver driver;

        public TreePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int CountItems()
        {
            int count = driver.FindElements(By.ClassName("age")).Count;
            return count;
        }

        public TreePage OpenNextPage(string NextPageName)
        {
            driver.Navigate().GoToUrl(driver.Url + NextPageName);
            return new TreePage(driver);
        }

        public TreePage OpenPreviousPage(string PreviousPageName)
        {
            driver.Navigate().GoToUrl(driver.Url.TrimEnd(PreviousPageName.ToCharArray()));
            return new TreePage(driver);
        }

        public BranchesPage BackToBranches()
        {
            driver.Navigate().GoToUrl("https://github.com/costea32/AutomationTraining/branches");
            return new BranchesPage(driver);
        }

        public List<Record> GetListOfItems()
        {
            List<Record> MyList = new List<Record>();
            int count = CountItems();

            List<IWebElement> icons = driver.FindElement(By.ClassName("files")).FindElements(By.XPath("//tbody/tr/td[@class = 'icon']/span")).ToList();
            List<IWebElement> rnames = driver.FindElements(By.ClassName("js-directory-link")).ToList();
            List<IWebElement> rcomments = driver.FindElement(By.ClassName("files")).FindElements(By.XPath("//tbody/tr/td[@class = 'message']/span/a")).ToList();
            List<IWebElement> rage = driver.FindElement(By.ClassName("files")).FindElements(By.ClassName("js-relative-date")).ToList();

            for (int i = 0; i < count; i++)
            {
                if (icons[i].GetAttribute("class").Contains("directory"))
                {
                    //add folder
                    List<Record> children = new List<Record>();
                    Folder ffolder = new Folder(rnames[i].Text, rcomments[i].Text, rage[i].Text);
                    children = GetListOfItems();
                    MyList.Add(ffolder);
                }

                else
                {
                    //add file
                    File ffile = new File(rnames[i].Text, rcomments[i].Text, rage[i].Text);

                    MyList.Add(ffile);
                }
            }

            return MyList;
        }
    }
}
