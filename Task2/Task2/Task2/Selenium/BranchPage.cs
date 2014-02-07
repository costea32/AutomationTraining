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
            this.table = getTable();
        }
        
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://github.com/costea32/AutomationTraining/branches");
        }

        public IWebElement getTable()
        {
            return table = Driver.Instance.FindElements(By.ClassName("branches"))[1];
        }

        public IWebElement getRow(int i)
        {
            return table.FindElements(By.Id("tr"))[i];
        }

        public string getName(int i)
        {
            return getRow(i).FindElement(By.ClassName("css-truncate-target")).Text;
        }

        public int getAhead(int i)
        {
            return int.Parse(getRow(i).FindElement(By.ClassName("behind")).FindElement(By.TagName("em")).Text.Substring(0,2));
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

/*
        public class Table : IWebElement
        {
            public IWebElement table { get; set; }

            public void Table()
            {
                getTable();    
            }

            public void getTable()
            {
                this.table = Driver.Instance.FindElements(By.ClassName("branches"))[1];
            }


            public class Rows : IWebElement
            {
                IList<IWebElement> rows;

                public IList<IWebElement> Rows()
                {
                    getRows();
                    return rows;
                }

                public void getRows()
                {
                    this.rows = Driver.Instance.FindElements(By.ClassName("branches"));
                }
            }
        }

*/
    }
}
