using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Task2.Selenium
{
    public class BranchPage
    {
        public Table table { get { return new Table(); } }

        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://github.com/costea32/AutomationTraining/branches");
        }

        public class Table
        {
            IWebElement table;

            public Table()
            {
                table = Driver.Instance.FindElements(By.ClassName("branches"))[1];
            }

            public List<TableRow> tableRows
            {
                get
                {
                    var retList = new List<TableRow>();
                    var rowElements = table.FindElements(By.TagName("tr"));
                    foreach (var rowElement in rowElements)
                    {
                        retList.Add(new TableRow(rowElement));
                    }
                    return retList;
                }
            }
        }

        public class TableRow
        {
            IWebElement tableRow;

            public TableRow(IWebElement tableRow)
            {
                this.tableRow = tableRow;
            }

            public string name { get { return tableRow.FindElement(By.ClassName("css-truncate-target")).Text; } }

            public int ahead { get { return int.Parse(tableRow.FindElement(By.ClassName("ahead")).FindElement(By.TagName("em")).Text.Substring(0, 2)); } }

            public int behind { get { return int.Parse(tableRow.FindElement(By.ClassName("behind")).FindElement(By.TagName("em")).Text.Substring(0, 2)); } }

            public string url { get { return "https://github.com/costea32/AutomationTraining/tree/" + name; } }
        }
    }
}



