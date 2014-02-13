using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Iheritance_Web_subproject_rework
{
    class SourceTable : Table
    {
        string name;
        IWebDriver driver;
        List<SourceRow> rows = new List<SourceRow>();

        public string Name { get { return name; } }

        public List<SourceRow> Rows { get { return rows; } }

        public SourceTable(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
            this.name = GetName();
            this.PopulateRows();
        }

        private string GetName()
        {
            List<IWebElement> name_string = new List<IWebElement>(driver.FindElements(By.ClassName("up-tree")));
            if (name_string.Count == 0) return driver.FindElement(By.ClassName("author-name")).FindElement(By.TagName("a")).Text;
            else return driver.FindElement(By.ClassName("final-path")).Text;
        }
        private void PopulateRows()
        {
            foreach (IWebElement element in driver.FindElements(By.TagName("tr")))
            {
                if (element.GetAttribute("class") == "")
                    this.rows.Add(new SourceRow(element));
            }
        }
    }
}
