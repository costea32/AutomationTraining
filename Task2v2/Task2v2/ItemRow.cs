using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2v2
{
    class ItemRow
    {
        public string Name;
        public string Type;
        public string Comment;
        public string Age;

        public ItemRow(string name, string type, string comment, string age)
        {
            Name = name;
            Type = type;
            Comment = comment;
            Age = age;
        }
    }
}
