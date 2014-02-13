using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task2v2
{
    class ItemTable
    {
        public IList<ItemRow> Rows{
            get
            {
                IList<ItemRow> retList = new List<ItemRow>();
                var rowList = GetAllRows();

            foreach (IWebElement tmpRow in rowList)
            {
                if (!SkipElement(tmpRow))
                    retList.Add(new ItemRow(tmpRow));
                else continue;
            }
            return retList;
            }}
        private IWebElement table;

        public ItemTable(IWebElement table)
        {
            this.table = table;

//            Rows = table.FindElements(By.TagName("tr"));
        }

        private IList<IWebElement> GetAllRows()
        {
           return table.FindElements(By.TagName("tr"));
        }

        private bool SkipElement(IWebElement row)
        {
            if (row.GetAttribute("class") == "up-tree") return true;
            else return false;
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;

//namespace Task2v2
//{
//    class Table<T>
//    {
//        private IList<T> Rows{
//            get
//            {
//                IList<T> rowList = new List<T>();
                

//            foreach (IWebElement tmpRow in rowList)
//            {
//                if (!SkipElement(tmpRow))
//                    TreeTable.AddRow(new ItemRow(tmpRow));
//                else continue;
//            }
//            return rowList;
//            }}
//        private IWebElement table;

//        public Table(IWebElement table)
//        {
//            Rows = new List<T>();
//            this.table = table;

////            Rows = table.FindElements(By.TagName("tr"));
//        }

//        public void AddRow(T row)
//        {
//            Rows.Add(row);
//        }

//        public int CountRows()
//        {
//            return Rows.Count;
//        }
        
//        public T GetRow(int i)
//        {
//            int count = CountRows();
            
//            if ((i < 0) || (i >= count))
//                throw new IndexOutOfRangeException();
            
//            else return Rows[i];
//        }

//        public IList<IWebElement> GetAllRows()
//        {
//           return table.FindElements(By.TagName("tr"));
//        }
//    }
//}
