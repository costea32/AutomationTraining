using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Task2.Selenium
{
    public class Table<T>
    {
        IWebElement table;


        public Table()
        {
            string type1 = typeof(T).ToString();
            if (typeof(T).ToString() == "Task2.Selenium.BranchPageRow")
                table = Driver.Instance.FindElements(By.ClassName("branches"))[1];
            else
                table = Driver.Instance.FindElement(By.ClassName("files"));
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
