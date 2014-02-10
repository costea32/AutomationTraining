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
            UpdateTable();
        }

        public static void GoTo(string url)
        {
            Driver.Instance.Navigate().GoToUrl(url);
        }

        public IWebElement GetTable()
        {
            return Driver.Instance.FindElement(By.ClassName("files"));
        }

        public IWebElement GetRow(int i)
        {
            if (IsNotMainFolder()) i++;
            return table.FindElements(By.TagName("tr"))[i];
        }

        public string GetName(int i)
        {
            return GetRow(i).FindElement(By.ClassName("content")).FindElement(By.TagName("a")).Text;
        }

        public string GetType(int i)
        {
            if (GetRow(i).FindElement(By.ClassName("icon")).FindElement(By.TagName("span")).GetAttribute("class").Contains("directory"))
                return "Folder";
            else
                return "File";
        }

        public string GetComment(int i)
        {
            return GetRow(i).FindElement(By.ClassName("message")).FindElement(By.TagName("a")).Text;
        }

        public string GetLastUpdated(int i)
        {
            return GetRow(i).FindElement(By.ClassName("age")).FindElement(By.TagName("time")).Text;
        }
        
        public int GetNrOfItems()
        {
            if (IsNotMainFolder())  
                return table.FindElements(By.TagName("tr")).Count-1;
            else
                return table.FindElements(By.TagName("tr")).Count;
        }

        public bool IsNotMainFolder()
        {
            IWebElement element1 = table.FindElements(By.TagName("tr"))[0];
            return (table.FindElements(By.TagName("tr"))[0].GetAttribute("class") == "up-tree");
        }

        public void UpdateTable()
        {
            table = GetTable();
        }

        public string GetUrl()
        {
            return Driver.Instance.Url;
        }

        public void SetUrl(string url)
        {
            Driver.Instance.Url = url;
        }
    }
}
