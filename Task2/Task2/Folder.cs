using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Folder: Record
    {
        List<Record> tree;

        Folder(string n, string t, string c)
        {
            Name = n;
            Type = t;
            Comment = c;
            AddTree();
        }

        public void AddTree()
        {

        }
    }
}
