using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataRomanNumerals
{
    public class RomanConverter
    {
        public string ToRoman(int number)
        {
            if (number >= 4000)
            {
                return "too big...";
            }

            string result = "";

            int thousands = GetThousands(number);
            result += GetThousandsToRoman(thousands);

            int hundreds = GetHundreds(number);
            result += GetHundredsToRoman(hundreds);

            int tens = GetTens(number);
            result += GetTensToRoman(tens);

            int ones = GetOnes(number);
            result += GetOnesToRoman(ones);

            return result;
        }

        private int GetOnes(int number)
        {
            return number % 10;
        }

        private int GetTens(int number)
        {
            number = number % 100;
            number /= 10;
            return number;
        }

        private int GetHundreds(int number)
        {
            number = number % 1000;
            number /= 100;
            return number;
        }

        private int GetThousands(int number)
        {
            number = number % 10000;
            number /= 1000;
            return number;
        }

        // convert 1, 2, ... 9
        private string GetOnesToRoman(int number)
        {
            switch (number)
            {
                case 0: return "";
                case 1: return "I";
                case 2: return "II";
                case 3: return "III";
                case 4: return "IV";
                case 5: return "V";
                case 6: return "VI";
                case 7: return "VII";
                case 8: return "VIII";
                case 9: return "IX";
                default: return "";
            }
        }

        // convert 10, 20, ... 90
        private string GetTensToRoman(int number)
        {
            switch (number)
            {
                case 0: return "";
                case 1: return "X";
                case 2: return "XX";
                case 3: return "XXX";
                case 4: return "XL";
                case 5: return "L";
                case 6: return "LX";
                case 7: return "LXX";
                case 8: return "LXXX";
                case 9: return "XC";
                default: return "";
            }
        }

        // convert 100, 200, ... 900
        private string GetHundredsToRoman(int number)
        {
            switch (number)
            {
                case 0: return "";
                case 1: return "C";
                case 2: return "CC";
                case 3: return "CCC";
                case 4: return "CD";
                case 5: return "D";
                case 6: return "DC";
                case 7: return "DCC";
                case 8: return "DCCC";
                case 9: return "CM";
                default: return "";
            }
        }

        // convert 1000, 2000, 3000
        private string GetThousandsToRoman(int number)
        {
            switch (number)
            {
                case 0: return "";
                case 1: return "M";
                case 2: return "MM";
                case 3: return "MMM";
                default: return "";
            }
        }
    }
}
