using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public abstract interface Actions
    {
        public List<Record> AddChildren(string l);
    }

    public class AddAction : Actions
    {
        public override List<Record> AddChildren(string l)
        {
            List<Record> tmp = new List<Record>();
            return tmp;
        }
    }
}
