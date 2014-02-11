using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Task2.Selenium
{
    public class ContentPage
    {
        public Table table { get { return new Table(); } }

        public string GetUrl()
        {
            return Driver.Instance.Url;
        }

        public void SetUrl(string url)
        {
            Driver.Instance.Url = url;
        }

        public class Table
        {
            IWebElement table;

            public Table()
            {
                table = Driver.Instance.FindElement(By.ClassName("files"));
            }

            public List<TableRow> tableRows
            {
                get
                {
                    var retList = new List<TableRow>();
                    var rowElements = table.FindElements(By.TagName("tr"));
                    foreach (var rowElement in rowElements)
                    {
                        if (!(rowElement.GetAttribute("class") == "up-tree"))
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

            public string name { get { return tableRow.FindElement(By.ClassName("content")).FindElement(By.TagName("a")).Text; } }

            public string type
            {
                get
                {
                    if (tableRow.FindElement(By.ClassName("icon")).FindElement(By.TagName("span")).GetAttribute("class").Contains("directory"))
                        return "Folder";
                    else
                        return "File";
                }
            }

            public string url { get { return Driver.Instance.Url + "/" + name; } }

            public string comment { get { return tableRow.FindElement(By.ClassName("message")).FindElement(By.TagName("a")).Text; } }

            public string lastUpdated { get { return tableRow.FindElement(By.ClassName("age")).FindElement(By.TagName("time")).Text; } }
        }
    }
}
