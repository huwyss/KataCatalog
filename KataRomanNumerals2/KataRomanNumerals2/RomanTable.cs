using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataRomanNumerals2
{
    public class RomanTable
    {
        public int Number { get; set; }
        public string Roman { get; set; }

        public RomanTable(int number, string roman)
        {
            Number = number;
            Roman = roman;
        }
    }
}
