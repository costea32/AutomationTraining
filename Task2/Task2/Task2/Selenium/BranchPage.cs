using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Task2.Selenium
{
    public class BranchPage
    {
        IWebElement table;

        public BranchPage()
        {
            table = GetTable();
        }
        
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://github.com/costea32/AutomationTraining/branches");
        }

        public IWebElement GetTable()
        {
            return Driver.Instance.FindElements(By.ClassName("branches"))[1];
        }

        public IWebElement GetRow(int i)
        {
            return table.FindElements(By.TagName("tr"))[i];
        }

        public string GetName(int i)
        {
            return GetRow(i).FindElement(By.ClassName("css-truncate-target")).Text;
        }

        public int GetAhead(int i)
        {
            return int.Parse(GetRow(i).FindElement(By.ClassName("behind")).FindElement(By.TagName("em")).Text.Substring(0,2));
        }

        public int GetBehind(int i)
        {
            return int.Parse(GetRow(i).FindElement(By.ClassName("ahead")).FindElement(By.TagName("em")).Text.Substring(0, 2));
        }

        public string GetUrl(int i)
        {
            return "https://github.com/costea32/AutomationTraining/tree/" + GetName(i);
        }

        public int GetNrOfBranches()
        {
            return table.FindElements(By.TagName("tr")).Count;
        }
    }
}
