using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Task2.Selenium
{
    public class Table<T> where T : TableRow
    {
        IWebElement table;

        public Table(IWebElement table)
        {
            this.table = table;
        }

        public List<T> tableRows
        {
            get
            {
                var retList = new List<T>();
                var rowElements = table.FindElements(By.TagName("tr"));
                foreach (var rowElement in rowElements)
                {
                    retList.Add((T)Activator.CreateInstance(typeof(T), new object[] {rowElement}));
                }
                return retList;
            }
        }
    }
}
