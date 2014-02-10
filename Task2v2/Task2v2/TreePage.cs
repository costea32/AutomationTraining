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

        List<IWebElement> icons;
        List<IWebElement> rnames;
        List<IWebElement> rcomments;
        List<IWebElement> rage;

        public TreePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int CountItems()
        {
            int count = driver.FindElements(By.ClassName("age")).Count;
            return count;
        }

        public void OpenNextPage(string NextPageName)
        {
            driver.Navigate().GoToUrl(driver.Url + NextPageName);
        }

        public void OpenPreviousPage()
        {
            driver.Navigate().GoToUrl(driver.Url.TrimEnd(driver.Url.ToCharArray()));
        }

        public void BackToBranches()
        {
            driver.Navigate().GoToUrl("https://github.com/costea32/AutomationTraining/branches");
        }

        public List<Record> GetListOfItems(string url)
        {
            driver.Url = url;
            List<Record> MyList = new List<Record>();
            int count = CountItems();

            getItems();
            
            for (int i = 0; i < count; i++)
            {
                bool isFolder1 = isFolder(i);

                if (isFolder1)
                {
                    //add folder
                    List<Record> children = new List<Record>();
                    string tempName = rnames[i].Text;
                    children = GetListOfItems(url + "/" + tempName);
                    driver.Url = url;
                    getItems();
                    MyList.Add(new Folder(rnames[i].Text, rcomments[i].Text, rage[i].Text, children));
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

        public void getItems()
        {
            icons = driver.FindElement(By.ClassName("files")).FindElements(By.XPath("//tbody/tr/td[@class = 'icon']/span")).ToList();
            rnames = driver.FindElements(By.ClassName("js-directory-link")).ToList();
            rcomments = driver.FindElement(By.ClassName("files")).FindElements(By.XPath("//tbody/tr/td[@class = 'message']/span/a")).ToList();
            rage = driver.FindElement(By.ClassName("files")).FindElements(By.ClassName("js-relative-date")).ToList();
        }

        public bool isFolder(int i)
        {
            return icons[i].GetAttribute("class").Contains("directory");
        }

    }
}
