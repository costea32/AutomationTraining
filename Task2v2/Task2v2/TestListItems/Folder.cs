using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2v2
{
    class Folder : Record
    {
        public List<Record> Children;

        public Folder(string name, string comment, string age, List<Record> children)
        {
            Name = name;
            Comment = comment;
            Age = age;
            Children = children;
        }

        public Folder(string name, string comment, string age)
        {
            Name = name;
            Comment = comment;
            Age = age;
        }

        public override void AddChildren(List<Record> children)
        {
            Children = children;
        }
    }
}
