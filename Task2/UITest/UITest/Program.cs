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
        string name;
        string last_updated;
        public TRow(string n, string lu)
        {
            name = n;
            last_updated = lu;
        }

        public virtual void get_children();
    }

    public class TableRow:TRow
    {
        string type;
        string comment;
        public TableRow(string n, string lu, string t, string c)
            :base(n,lu)
        {
            type = t;
            comment = c;
        }

        public override List<TableRow> get_children()
        {
            return null;
        }
    }

    public class BranchesTableRow:TRow
    {
        int ahead;
        int behind;
        public BranchesTableRow(string n, string lu, int a, int b)
            : base(n, lu)
        {
            ahead = a;
            behind = b;
        }

        public override void get_children()
        {
            base.get_children();
        }
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
