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
    class BranchesPage
    {
        BranchTable table;

        public BranchTable BranchTable
        {
            get { return table; }
        }

        public BranchesPage(IWebDriver driver)
        {
            this.table = new BranchTable(driver);
        }
    }
}
