using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Task2.Selenium
{
    [DataContract]
    public enum RowType { 
        
        [EnumMember(Value="File")]
        File=1,
        
        [EnumMember(Value = "Folder")]
        Folder=2 
    }
}
