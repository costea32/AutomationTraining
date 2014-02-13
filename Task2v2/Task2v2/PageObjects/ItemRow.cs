using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task2v2
{
    class ItemRow
    {
        public string Name {get {return row.FindElement(By.ClassName("js-directory-link")).Text;}}
        public string Type
        {
            get
            {
                string type;
                string icon = row.FindElement(By.ClassName("icon")).FindElement(By.TagName("span")).GetAttribute("class").ToString();

                if (icon.Contains("directory"))
                    type = "Folder";
                else type = "File";

                return type;
            }
        }
        public string Comment { get { return row.FindElement(By.ClassName("message")).Text; } }//FindElement(By.TagName("a")).Text; } }
        public string Age { get { return row.FindElement(By.ClassName("age")).Text; } }


        private IWebElement row;
///*
//        public ItemRow(string name, string type, string comment, string age)
//        {
//            Name = name;
//            Type = type;
//            Comment = comment;
//            Age = age;
//        }
//*/
        public ItemRow(IWebElement row)
        {
/*            Name = row.FindElement(By.ClassName("js-directory-link")).Text;

            string icon = row.FindElement(By.ClassName("icon")).FindElement(By.TagName("span")).GetAttribute("class").ToString();

            if (icon.Contains("directory"))
                Type = "Folder";
            else Type = "File";

            Comment = row.FindElement(By.ClassName("message")).FindElement(By.TagName("a")).Text;
            Age = row.FindElement(By.ClassName("js-relative-date")).Text;      
 */
            this.row = row;
        }
    }
}
