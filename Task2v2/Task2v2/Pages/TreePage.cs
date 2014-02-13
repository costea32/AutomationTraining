using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task2v2
{
    class TreePage
    {
        private IWebDriver driver;

        private List<IWebElement> icons;
        private List<IWebElement> rnames;
        private List<IWebElement> rcomments;
        private List<IWebElement> rage;

        private ItemTable TreeTable;

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
            driver.Navigate().GoToUrl(driver.Url + "/" + NextPageName);
            return new TreePage(driver);
        }

        public void OpenPreviousPage()
        {
            driver.Navigate().GoToUrl(driver.Url.TrimEnd(driver.Url.ToCharArray()));
        }

        public void BackToBranches()
        {
            driver.Navigate().GoToUrl("https://github.com/costea32/AutomationTraining/branches");
        }
/*
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
*/
        private void getItems()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(d => d.FindElement(By.ClassName("files")));
            
            icons = driver.FindElement(By.ClassName("files")).FindElements(By.XPath("//tbody/tr/td[@class = 'icon']/span")).ToList();
            rnames = driver.FindElements(By.ClassName("js-directory-link")).ToList();
            rcomments = driver.FindElement(By.ClassName("files")).FindElements(By.XPath("//tbody/tr/td[@class = 'message']/span/a")).ToList();
            rage = driver.FindElement(By.ClassName("files")).FindElements(By.ClassName("js-relative-date")).ToList();
        }

        private bool isFolder(int i)
        {
            return icons[i].GetAttribute("class").Contains("directory");
        }

        private bool SkipElement(IWebElement row)
        {
            if (row.GetAttribute("class") == "up-tree") return true;
            else return false;
        }

        public ItemTable GetTreeTable()
        {
            TreeTable = new ItemTable(driver.FindElement(By.ClassName("files")));

            //IList<IWebElement> rowList = TreeTable.GetAllRows();

            //foreach (IWebElement tmpRow in rowList)
            //{
            //    if (!SkipElement(tmpRow))
            //        TreeTable.AddRow(new ItemRow(tmpRow));
            //    else continue;
            //}
/*
            int count = CountItems();

            getItems();

            for (int i = 0; i < count; i++)
            {
                string itemName = rnames[i].Text;
                string itemComment = rcomments[i].Text;
                string itemAge = rage[i].Text;

                string itemType;
                if (isFolder(i)) itemType = "Folder";
                else itemType = "File";

                TreeTable.AddRow(new ItemRow(itemName, itemType, itemComment, itemAge));
            }
*/
            return TreeTable;
        }

        public void RefreshPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public string GetURL()
        {
            return driver.Url.ToString();
        }
    }
}
