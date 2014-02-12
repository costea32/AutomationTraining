using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Task2.Selenium
{
    public class BranchPageRow : TableRow
    {
        public string name { get { return tableRow.FindElement(By.ClassName("css-truncate-target")).Text; } }

        public int ahead { get { return int.Parse(tableRow.FindElement(By.ClassName("ahead")).FindElement(By.TagName("em")).Text.Substring(0, 2)); } }

        public int behind { get { return int.Parse(tableRow.FindElement(By.ClassName("behind")).FindElement(By.TagName("em")).Text.Substring(0, 2)); } }

        public string url { get { return "https://github.com/costea32/AutomationTraining/tree/" + name; } }
    }
}
