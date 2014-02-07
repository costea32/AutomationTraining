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
            return table = Driver.Instance.FindElement(By.ClassName("files"));
        }

        public IWebElement getRow(int i)
        {
            return table.FindElements(By.Id("tr"))[i];
        }

        public string getName(int i)
        {
            return getRow(i).FindElement(By.ClassName("js-directory-link")).Text;
        }

        public int getAhead(int i)
        {
            return int.Parse(getRow(i).FindElement(By.ClassName("behind")).FindElement(By.TagName("em")).Text.Substring(0, 2));
        }

        public int getBehind(int i)
        {
            return int.Parse(getRow(i).FindElement(By.ClassName("ahead")).FindElement(By.TagName("em")).Text.Substring(0, 2));
        }

        public string getUrl(int i)
        {
            return "https://github.com/costea32/AutomationTraining/tree/" + getName(i);
        }

        public int getNrOfBranches()
        {
            return table.FindElements(By.Id("tr")).Count;
        }
    }
}
