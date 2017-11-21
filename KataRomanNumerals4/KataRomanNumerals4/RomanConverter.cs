using System.Collections.Generic;
using System.Text;

namespace KataRomanNumerals4
{
    public class RomanConverter
    {

        public static string ToRoman(int number)
        {
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

            var result = new StringBuilder();

            foreach (var t in romanLookup)
            {
                while (number >= t.Key)
                {
                    result.Append(t.Value);
                    number -= t.Key;
                }
            }

            return result.ToString();
        }
    }
}
