using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Task2.Selenium
{
    public class BranchPage
    {
        public Table<BranchPageRow> table { get { return new Table<BranchPageRow>(); } }

        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://github.com/costea32/AutomationTraining/branches");
        }
    } 
}



