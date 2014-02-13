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
    class BranchRow : Row
    {
        string ahead;
        string behind;

        public string Ahead
        {
            get { return ahead; }
        }

        public string Behind
        {
            get { return behind; }
        }

        public BranchRow(IWebElement element)
            : base(element)
        {
            this.ahead = element.FindElement(By.ClassName("ahead")).FindElement(By.TagName("em")).Text;
            this.behind = element.FindElement(By.ClassName("behind")).FindElement(By.TagName("em")).Text;
        }

    }
}
