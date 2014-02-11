using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2v2
{
    class Table<T>
    {
        private List<T> Rows;

        public Table()
        {
            Rows = new List<T>();
        }

        public void AddRow(T row)
        {
            Rows.Add(row);
        }

        public int CountRows()
        {
            return Rows.Count;
        }
        
        public T GetRow(int i)
        {
            int count = CountRows();
            
            if ((i < 0) || (i >= count))
                throw new IndexOutOfRangeException();
            
            else return Rows[i];
        }
    }
}
