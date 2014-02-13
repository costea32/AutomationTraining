using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Iheritance_Web_subproject_rework
{
    [DataContract]
    class SourceFolder : SourceFile
    {
        List<SourceFile> children = new List<SourceFile>();

        [DataMember]
        public List<SourceFile> Children
        { get; set; }
    }
}
