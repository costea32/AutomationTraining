using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public abstract interface Actions<T>
    {
        public void Add(T l);
    }

    public class AddAction<T> : Actions<T>
    {
        public override void Add(T l)
        {

        }
    }
}
