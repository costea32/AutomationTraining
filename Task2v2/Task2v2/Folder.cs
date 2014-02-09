using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2v2
{
    class Folder : Record
    {
        public List<Record> Children;

        public Folder(string name, string comment, string age, List<Record> Children)
        {
            Name = name;
            Comment = comment;
            Age = age;
            this.Children = Children;
        }

        public void AddChildren(List<Record> list)
        {
            Children = list;
        }
    }
}
