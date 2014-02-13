using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task2v2
{
    class BranchTable
    {
        public IList<BranchRow> Rows
        {
            get
            {
                IList<BranchRow> retList = new List<BranchRow>();
                var rowList = GetAllRows();

                foreach (IWebElement tmpRow in rowList)
                {
                    retList.Add(new BranchRow(tmpRow));
                }
                return retList;
            }
        }
        private IWebElement table;

        public BranchTable(IWebElement table)
        {
            this.table = table;

            //            Rows = table.FindElements(By.TagName("tr"));
        }

        private IList<IWebElement> GetAllRows()
        {
            return table.FindElements(By.TagName("tr"));
        }
    }
}