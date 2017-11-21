using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataRomanNumerals2
{
    public class RomanConverter
    {
        private static List<RomanTable> _romanTable;

        public static string ToRoman(int number)
        {
            InitRomanTable();
            string roman = "";

            for (int i = 0; i < _romanTable.Count; i++)
            {
                while (number >= _romanTable[i].Number)
                {
                    roman += _romanTable[i].Roman;
                    number -= _romanTable[i].Number;
                }
            }
            
            return roman;
        }

        private static void InitRomanTable()
        {
            _romanTable = new List<RomanTable>();
            _romanTable.Add(new RomanTable(1000, "M"));
            _romanTable.Add(new RomanTable(900, "CM"));
            _romanTable.Add(new RomanTable(500, "D"));
            _romanTable.Add(new RomanTable(400, "CD"));
            _romanTable.Add(new RomanTable(100, "C"));
            _romanTable.Add(new RomanTable(90, "XC"));
            _romanTable.Add(new RomanTable(50, "L"));
            _romanTable.Add(new RomanTable(40, "XL"));
            _romanTable.Add(new RomanTable(10, "X"));
            _romanTable.Add(new RomanTable(9, "IX"));
            _romanTable.Add(new RomanTable(5, "V"));
            _romanTable.Add(new RomanTable(4, "IV"));
            _romanTable.Add(new RomanTable(1, "I"));
        }
    }
}
