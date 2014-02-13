using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Iheritance_Web_subproject_rework
{
    [DataContract]
    [KnownType(typeof(SourceFolder))]
    class BranchFolder
    {
        [DataMember]
        public string Name
        { get; set; }

        [DataMember]
        public string LastUpdated
        { get; set; }

        [DataMember]
        public string Href
        { get; set; }

        [DataMember]
        public string Ahead
        { get; set; }

        [DataMember]
        public string Behind
        { get; set; }

        List<SourceFile> children = new List<SourceFile>();

        [DataMember]
        public List<SourceFile> Children
        { get; set; }
    
    
    
    }

}
