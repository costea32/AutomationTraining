using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public interface IBehavior
    {
        void addContainer(Container container);
    }

    public class FolderBehavior : IBehavior
    {
        public void addContainer(Container container)
        {

        }
    }

    public class FileBehavior : IBehavior
    {
        public void addContainer(Container container1)
        {
            
        }
    }

}
