using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataNumbersInWords
{
    public class GroupThousand
    {
        public int Number { get; set; }
        public string ThousandName { get; set; }
        
        public GroupThousand(int number, string thousandName)
        {
            Number = number;
            ThousandName = thousandName;
        }
    }
}
