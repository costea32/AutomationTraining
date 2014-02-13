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
    abstract class Row
    {
        string name;
        string last_updated;
        string href;


        public string Name
        {
            get { return name; }
        }

        public string Last_updated
        {
            get { return last_updated; }
        }

        public string Href
        {
            get { return href; }
        }

        public Row(IWebElement element)
        {
            this.name = element.FindElement(By.TagName("a")).Text;
            this.last_updated = element.FindElement(By.TagName("time")).Text;
            this.href = element.FindElement(By.TagName("a")).GetAttribute("href");
        }

    }
}
