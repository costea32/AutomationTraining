using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace UITest
{
    public class Page
    {
        public string name;
    }

    public class Table
    {
        string name;
        TableRow[] rows;
    }

    public class BranchesTable
    {
        string name;
        BranchesTableRow[] branches;

    }

    public class TableRow
    {
        string name;
        string type;
        string comment;
        string last_updated;
    }

    public class BranchesTableRow
    {
        string name;
        int ahead;
        int behind;
        string last_updated;
    }

    class Program
    {
        


        static void Main(string[] args)
        {

            IWebDriver driver = new FirefoxDriver();
            string html_path = "https://github.com/costea32/AutomationTraining/branches";
 
            Console.ReadLine();
        }
    }
}
