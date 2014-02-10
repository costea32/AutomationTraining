using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Iheritance_Web_Test
{
    public class Table
    {
        public string name;
        public List<TableRow> rows= new List<TableRow>();

        public Table(IWebDriver driver)
        {
            populate_rows(driver);
        }

        public virtual void populate_rows(IWebDriver driver)
        {
            int i = 0;
            List<IWebElement> elements = new List<IWebElement>(driver.FindElements(By.XPath(".//tbody[@class='']/tr")));
            foreach (IWebElement element in elements)
            {
                rows.Add(new TableRow(element));
            }
        }
        
        public static void get_children()
        {
            //
        }
    }

    public class TRow
    {
        public string name;
        public string last_updated;
        public string href;
        //List<TableRow> children;

        public TRow(string name, string last_updated, string href)
        {
            this.name = name;
            this.last_updated = last_updated;
            this.href = href;
        }


        public TRow(IWebElement element, string mode)
        {
            if (mode == "table_row")
            {
                string[] attributes = this.GetElementAttributes(element);
                this.name = attributes[0];
                this.last_updated = attributes[1];
                this.href = attributes[2];
            }
            else
                if (mode == "branch_row")
                {
                    string[] attributes = this.GetElementAttributesAlternative(element);
                    this.name = attributes[0];
                    this.last_updated = attributes[1];
                    this.href = attributes[2];
                }
        }


        public virtual string[] GetElementAttributes(IWebElement element)
        {

            string name = element.FindElement(By.XPath(".//td[@class='content']/span/a")).Text;
            string last_updated = element.FindElement(By.XPath(".//td[@class='age']/span/time")).Text;
            string href_string = element.FindElement(By.XPath(".//td[@class='content']/span/a")).GetAttribute("href");

            return (new string[] { name, last_updated, href_string });
        }

        public virtual string[] GetElementAttributesAlternative(IWebElement element)
        {
            string name = element.FindElement(By.XPath(".//td[@class='name']/h3/a")).Text;
            string last_updated = element.FindElement(By.XPath(".//td[@class='name']/p/time")).Text;
            string href_string = element.FindElement(By.XPath(".//td[@class='name']/h3/a")).GetAttribute("href");

            return (new string[] { name, last_updated, href_string });
        }

    }

    public class TableRow : TRow
    {
        public string type;
        public string comment;
        public TableRow(string name, string last_updated, string href, string type, string comment)
            : base(name, last_updated, href)
        {
            this.type = type;
            this.comment = comment;
        }

        public TableRow(IWebElement element)
            : base(element,"table_row")
        {
            string[] attributes = GetElementAttributes(element);
            this.type = attributes[0];
            this.comment = attributes[1];
        }


        new public static string[] GetElementAttributes(IWebElement element)
        {
            string type_string = element.FindElement(By.XPath(".//td[@class='icon']/span")).GetAttribute("class");
            string type;

            if (type_string.Split('-').Contains("directory")) type = "directory";
            else
                if (type_string.Split('-').Contains("text")) type = "file";
                else type = "empty row";

            string comment = element.FindElement(By.XPath(".//td[@class='message']/span/a")).Text;
            return (new string[] { type, comment });
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            int i = 0;
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://github.com/costea32/AutomationTraining/tree/ikulpin/Task1/Task1.Test";
            try
            {
                Table main_table = new Table(driver);
                //List<IWebElement> elements = new List<IWebElement>(driver.FindElements(By.XPath(".//tbody[@class='']/tr")));

                //foreach (IWebElement elem in elements)
                //{
                //    Console.WriteLine(i);
                //    Console.WriteLine(new TableRow(elem).type);
                //    i++;
                //}
            }
            finally
            {
                driver.Quit();
            }

            Console.ReadLine();
        }
    }
}
