using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Runtime.Serialization;

namespace Task2v2
{
    [DataContract()]
    [KnownType(typeof(Folder))]
    [KnownType(typeof(File))]
    public abstract class Record
    {
        [DataMember()]
        public string Name;

        [DataMember()]
        public string Comment;

        [DataMember()]
        public string Age;

        public virtual void AddChildren(List<Record> records) { }
    }
}
