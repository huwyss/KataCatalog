using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataNumbersInWords3
{
    public class ThousandGroup
    {
        public int Number { get; set; }
        public int Exponent { get; set; }
        public bool IsStart { get; set; }

        public ThousandGroup(int number, int exponent, bool isStart)
        {
            Number = number;
            Exponent = exponent;
            IsStart = isStart;
        }
    }
}
