using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataRomanNumerals3
{
    public class RomanNumeralsConverter
    {
        public static string ToRoman(int number)
        {
            string roman = "";

            var romanLookup = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1000, "M"),
                new KeyValuePair<int, string>(900, "CM"),
                new KeyValuePair<int, string>(500, "D"),
                new KeyValuePair<int, string>(400, "CD"),
                new KeyValuePair<int, string>(100, "C"),
                new KeyValuePair<int, string>(90, "XC"),
                new KeyValuePair<int, string>(50, "L"),
                new KeyValuePair<int, string>(40, "XL"),
                new KeyValuePair<int, string>(10, "X"),
                new KeyValuePair<int, string>(9, "IX"),
                new KeyValuePair<int, string>(5, "V"),
                new KeyValuePair<int, string>(4, "IV"),
                new KeyValuePair<int, string>(1, "I")
            };

            foreach(KeyValuePair<int, string> pair in romanLookup)
            while (number >= pair.Key)
            {
                roman += pair.Value; // Roman number
                number -= pair.Key; // decimal number
            }

            return roman;
        }
    }
}
