using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2v2
{
    public abstract class Record
    {
        public string Name;
        public string Comment;
        public string Age;

        public virtual void AddChildren(List<Record> records) { }
    }
}
