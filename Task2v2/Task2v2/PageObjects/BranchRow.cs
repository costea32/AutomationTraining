using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task2v2
{
    class BranchRow
    {
        public string BranchName;
        public int Behind;
        public int Ahead;

        public BranchRow(string name, int behind, int ahead)
        {
            BranchName = name;
            Behind = behind;
            Ahead = ahead;
        }

        public BranchRow(BranchRow r)
        {
            BranchName = r.BranchName;
            Behind = r.Behind;
            Ahead = r.Ahead;
        }

        public BranchRow(IWebElement row)
        {
            BranchName = row.FindElement(By.ClassName("css-truncate")).Text;
            Behind = Int32.Parse(row.FindElement(By.ClassName("behind")).FindElement(By.TagName("em")).Text.Substring(0, 2));
            Ahead = Int32.Parse(row.FindElement(By.ClassName("ahead")).FindElement(By.TagName("em")).Text.Substring(0, 2));
        }
    }
}
