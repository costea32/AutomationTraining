using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Task2.Selenium
{
    public abstract class TableRow
    {
        protected IWebElement tableRow;

        public TableRow(IWebElement tableRow)
        {
            this.tableRow = tableRow;
        }
    }
}
