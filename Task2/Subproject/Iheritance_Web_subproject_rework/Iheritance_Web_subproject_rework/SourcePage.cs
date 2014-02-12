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
    class SourcePage
    {
        IWebDriver driver;
        SourceTable table;

        public SourceTable Table
        {
            get { return table; }
        }

        public SourcePage(IWebDriver driver)
        {
            this.driver = driver;
            this.table = new SourceTable(driver);
        }
    }
}
