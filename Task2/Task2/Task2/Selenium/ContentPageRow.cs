using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Task2.Selenium
{
    public class ContentPageRow : TableRow
    {
        public ContentPageRow(IWebElement tableRow) : base(tableRow) { }
        
        public string name { get { return tableRow.FindElement(By.ClassName("content")).FindElement(By.TagName("a")).Text; } }

        public RowType type
        {
            get
            {
                if (tableRow.FindElement(By.ClassName("icon")).FindElement(By.TagName("span")).GetAttribute("class").Contains("directory"))
                    return RowType.Folder;
                else
                    return RowType.File;
            }
        }

        public string url { get { return Driver.Instance.Url + "/" + name; } }

        public string comment { get { return tableRow.FindElement(By.ClassName("message")).FindElement(By.TagName("a")).Text; } }

        public string lastUpdated { get { return tableRow.FindElement(By.ClassName("age")).FindElement(By.TagName("time")).Text; } }

        public bool isBack { get { return (tableRow.GetAttribute("class") == "up-tree"); } }
    }
}
