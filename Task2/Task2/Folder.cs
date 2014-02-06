using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Folder: Record, Actions
    {
        public List<Record> child;
        public string link;
        public Actions action;

        public Folder(string n, string c, string a, string l)
        {
            Name = n;
            Type = "Folder";
            Comment = c;
            Age = a;
            link = l;
            AddFolder();
        }

        public void AddFolder()
        {
            child = action.AddChildren(link);
        }
 
    }
}
