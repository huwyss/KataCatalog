using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataNumbersInWords3
{
    public class Converter
    {
        public static List<ThousandGroup> SplitThousandGroups(long number)
        {
            var groups = new List<ThousandGroup>();

            int lowestGroup;
            int exponent = 0;

            while (number > 0)
            {
                lowestGroup = (int)(number%1000);
                groups.Insert(0, new ThousandGroup(lowestGroup, exponent, false));
                number /= 1000;
                exponent += 3;
            }

            if (groups.Count > 0)
            {
                groups[0].IsStart = true;
            }

            return groups;
        }

        public static string ToWords(long number)
        {
            string wordNumber = "";
            var groups = SplitThousandGroups(number);
            foreach (ThousandGroup group in groups)
            {
                if (group.Number != 0)
                {
                    if (!group.IsStart)
                    {
                        wordNumber += " ";
                    }
                    wordNumber += ToWords1_999(group.Number);
                    string groupName = GroupName(group.Exponent);
                    if (groupName != "")
                    {
                        wordNumber += " " + groupName;
                    }
                }
            }

            return wordNumber;
        }

        private static string ToWords1_999(long number)
        {
            if (number <= 99)
            {
                return ToWords1_99(number);
            }
            else if (number <= 999)
            {
                int hundreds = (int)(number / 100);
                number = number - hundreds * 100;
                if (number == 0)
                {
                    return ToWords1_19(hundreds) + " hundred";
                }
                else
                {
                    return ToWords1_19(hundreds) + " hundred and " + ToWords1_99(number);
                }
            }
            return "";
        }

        private static string ToWords1_99(long number)
        {
            if (number <= 19)
            {
                return ToWords1_19(number);
            }
            else
            {
                return ToWords20_99(number);
            }
        }

        private static string ToWords20_99(long number)
        {
            int ones = (int)(number % 10);
            int tens = (int)(number - ones);
            if (ones == 0)
            {
                return ToWordTens(tens);
            }
            else
            {
                return ToWordTens(tens) + "-" + ToWords1_19(ones);
            }
        }

        private static string ToWords1_19(long number)
        {
            switch (number)
            {
                case 1: return "one"; break;
                case 2: return "two"; break;
                case 3: return "three"; break;
                case 4: return "four"; break;
                case 5: return "five"; break;
                case 6: return "six"; break;
                case 7: return "seven"; break;
                case 8: return "eight"; break;
                case 9: return "nine"; break;
                case 10: return "ten"; break;
                case 11: return "eleven"; break;
                case 12: return "twelve"; break;
                case 13: return "thirteen"; break;
                case 14: return "fourteen"; break;
                case 15: return "fifteen"; break;
                case 16: return "sixteen"; break;
                case 17: return "seventeen"; break;
                case 18: return "eighteen"; break;
                case 19: return "nineteen"; break;
                default: return ""; break;
            }
        }

        private static string ToWordTens(long number)
        {
            switch (number)
            {
                case 20: return "twenty"; break;
                case 30: return "thirty"; break;
                case 40: return "fourty"; break;
                case 50: return "fifty"; break;
                case 60: return "sixty"; break;
                case 70: return "seventy"; break;
                case 80: return "eighty"; break;
                case 90: return "ninty"; break;
                default: return ""; break;
            }
        }

        private static string GroupName(int zehnerpotenz)
        {
            switch (zehnerpotenz)
            {
                case 0: return ""; break;
                case 3: return "thousand"; break;
                case 6: return "million"; break;
                case 9: return "billion"; break;
                case 12: return "trillion"; break;
                default: return ""; break;
            }
        }
    }
}
