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
    class BranchTable : Table
    {
        string name = "Master table";
        IWebDriver driver;
        List<BranchRow> rows = new List<BranchRow>();

        public string Name { get { return name; } }
        public List<BranchRow> Rows { get { return rows; } }

        public BranchTable(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
            PopulateRows();
        }

        private void PopulateRows()
        {
            foreach (IWebElement element in driver.FindElements(By.TagName("tr")))
            {
                if (element.GetAttribute("class") == "")
                    this.rows.Add(new BranchRow(element));
            }
        }
    }
}
