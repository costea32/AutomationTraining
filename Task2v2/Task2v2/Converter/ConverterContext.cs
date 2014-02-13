using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2v2
{
    class ConverterContext
    {
        private Converter converter;

        public void SetConverter(Converter c)
        {
            converter = c;
        }

        public void Convert(List<Branch> branchList)
        {
            converter.ConvertToFile(branchList);
        }
    }
}
