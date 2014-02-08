using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Task2.Selenium
{
    public class ContentPage
    {
        IWebElement table;

        public ContentPage()
        {
            this.table = getTable();
        }

        public static void GoTo(string url)
        {
            Driver.Instance.Navigate().GoToUrl(url);
        }

        public IWebElement getTable()
        {
            return Driver.Instance.FindElement(By.ClassName("files"));
        }

        public IWebElement getRow(int i)
        {
            if (isNotMainFolder()) i++;
            return table.FindElements(By.TagName("tr"))[i];
        }

        public string getName(int i)
        {
            return getRow(i).FindElement(By.ClassName("content")).FindElement(By.TagName("a")).Text;
        }

        public string getType(int i)
        {
            if (getRow(i).FindElement(By.ClassName("icon")).FindElement(By.TagName("span")).GetAttribute("class").Contains("directory"))
                return "Folder";
            else
                return "File";
        }

        public string getComment(int i)
        {
            return getRow(i).FindElement(By.ClassName("message")).FindElement(By.TagName("a")).Text;
        }

        public string getLastUpdated(int i)
        {
            return getRow(i).FindElement(By.ClassName("age")).FindElement(By.TagName("time")).Text;
        }
        
        public int getNrOfItems()
        {
            if (isNotMainFolder())  
                return table.FindElements(By.TagName("tr")).Count-1;
            else
                return table.FindElements(By.TagName("tr")).Count;
        }

        public bool isNotMainFolder()
        {
            IWebElement element1 = table.FindElements(By.TagName("tr"))[0];
            return (table.FindElements(By.TagName("tr"))[0].GetAttribute("class") == "up-tree");
        }

        public void updateTable()
        {
            this.table = getTable();
        }

        public string getUrl()
        {
            return Driver.Instance.Url;
        }

        public void setUrl(string url)
        {
            Driver.Instance.Url = url;
        }
    }
}
