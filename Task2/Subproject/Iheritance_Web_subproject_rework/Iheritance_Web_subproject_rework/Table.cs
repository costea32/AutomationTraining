using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace Iheritance_Web_subproject_rework
{
    abstract class Table
    {
        //string name;
        IWebDriver driver;

        public Table(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
