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

    public class TRow
    {
        public string name;
        public string last_updated;
        public string href;
        List<TableRow> children;

        public TRow(string name,string last_updated,string href)
        {
            this.name = name;
            this.last_updated = last_updated;
            this.href = href;
        }

        public TRow(IWebElement element,IWebDriver driver,string mode)
        {
            //string[] attributes;
            if (mode == "table_row") 
            { 
                string[] attributes = GetElementAttributes(element, driver);
                this.name = attributes[0];
                this.last_updated = attributes[1];
                this.href = attributes[2];
            }
            else 
                if (mode == "branch_row") 
                 { 
                    string[] attributes = GetElementAttributesAlternative(element, driver);
                    this.name = attributes[0];
                    this.last_updated = attributes[1];
                    this.href = attributes[2];
                 }

        }

        public virtual string[] GetElementAttributes(IWebElement element, IWebDriver driver)
        {

            string name = driver.FindElement(By.XPath(".//td[@class='content']/span/a")).Text;
            string last_updated = driver.FindElement(By.XPath(".//td[@class='age']/span/time")).Text;
            string href_string = driver.FindElement(By.XPath(".//td[@class='content']/span/a")).GetAttribute("href");

            return (new string[] { name, last_updated, href_string });
        }

        public static string[] GetElementAttributesAlternative(IWebElement element, IWebDriver driver)
        {
            string name = driver.FindElement(By.XPath(".//td[@class='name']/h3/a")).Text;
            string last_updated = driver.FindElement(By.XPath(".//td[@class='name']/p/time")).Text;
            string href_string = driver.FindElement(By.XPath(".//td[@class='name']/h3/a")).GetAttribute("href");

            return (new string[] { name, last_updated, href_string });
        }


    }

    public class TableRow:TRow
    {
        string type;
        string comment;
        public TableRow(string name,string last_updated,string href,string type,string comment)
            :base(name,last_updated,href)
        {
            this.type = type;
            this.comment = comment;
        }

        public TableRow(IWebElement element,IWebDriver driver):base(element,driver,"table_row")
        {
            string[] attributes = this.GetElementAttributes(element,driver);
            this.type = attributes[0];
            this.comment = attributes[1];
        }

        public override string[] GetElementAttributes(IWebElement element, IWebDriver driver)
        {
            string type_string = driver.FindElement(By.XPath(".//td[@class='icon']/span")).GetAttribute("class");
            string type;

            if (type_string.Split('-').Contains("directory")) type = "directory";
            else
                if (type_string.Split('-').Contains("text")) type = "file";
                else type = "empty row";

            string comment = driver.FindElement(By.XPath(".//td[@class='message']/span/a")).Text;
            return (new string[] { type, comment });
        }
    }

    public class BranchesTableRow:TRow
    {
        string ahead;
        string behind;

        public BranchesTableRow(string name, string last_updated, string href, string ahead, string behind)
            : base(name, last_updated, href)
        {
            this.ahead = ahead;
            this.behind = behind;
        }

        public BranchesTableRow(IWebElement element, IWebDriver driver)
            : base(element, driver, "branch_row")
        {
            string[] attributes = this.GetElementAttributes(element,driver);

            this.ahead = attributes[0];
            this.behind = attributes[1];
        }

        public override string[] GetElementAttributes(IWebElement element, IWebDriver driver)
        {
            string ahead = driver.FindElement(By.XPath(".//span[@class='ahead']/em")).Text;
            string behind = driver.FindElement(By.XPath(".//span[@class='behind']/em")).Text;
            
            return (new string[] { ahead, behind });
        }

    }

    //

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
