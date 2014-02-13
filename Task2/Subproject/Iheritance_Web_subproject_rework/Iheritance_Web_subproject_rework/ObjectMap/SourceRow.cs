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
    class SourceRow : Row
    {
        string type_string;
        string comment;

        public string Type
        {
            get
            {
                if (type_string.Split('-').Contains("directory")) return ("directory");
                else
                    if (type_string.Split('-').Contains("text")) return ("file");
                    else return ("empty row");
            }
        }

        public string Comment { get { return comment; } }

        public bool HasChildren
        {
            get
            {
                if (this.Type == "directory") return true;
                else return false;
            }
        }

        public SourceRow(IWebElement element)
            : base(element)
        {
            this.type_string = element.FindElement(By.ClassName("icon")).FindElement(By.TagName("span")).GetAttribute("class");
            this.comment = element.FindElement(By.ClassName("message")).FindElement(By.TagName("a")).Text;
        }
    }
}
