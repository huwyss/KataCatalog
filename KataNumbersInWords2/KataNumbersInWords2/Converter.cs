using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataNumbersInWords2
{
    public class Converter
    {
        public static string ToWords(long number)
        {
            string words = "";

            List<Group> groups = SplitInGroups(number);
            int length = groups.Count;
            int i = 0;
            foreach (Group group in groups)
            {
                words += group.ToWords();
                i++;
                if (i != length)
                {
                    words += " ";
                }
            }
           
            return words;
        }

        public static List<Group> SplitInGroups(long number)
        {
            var groups = new List<Group>();
            int potenz = 18;
            long groupValue = (long) Math.Pow(10, potenz);

            while (groupValue > 0)
            {
                if (number >= groupValue)
                {
                    groups.Add(new Group((int)(number/groupValue), potenz));
                    number %= groupValue;
                }

                groupValue /= 1000;
                potenz -= 3;
            }

            return groups;
        }

        public static string Convert1To999(int number)
        {
            string words = "";

            if (number >= 100)
            {
                int hundreds = number / 100;
                if (hundreds >= 1)
                {
                    words = Convert1To19(hundreds) + " hundred";
                }

                number -= hundreds * 100;
                if (number > 0)
                {
                    words += " and ";
                }
            }

            if (number > 0)
            {
                words += Convert1To99(number);
            }

            return words;
        }

        private static string Convert1To99(int number)
        {
            if (number <= 19)
            {
                return Convert1To19(number);
            }

            int tens = number / 10;
            string words = ConvertTens(tens);

            int ones = number % 10;
            if (ones > 0)
            {
                words += "-" + Convert1To19(ones);
            }

            return words;
        }

        private static string Convert1To19(int number)
        {
            switch (number)
            {
                case 1:
                    return "one";
                    break;
                case 2:
                    return "two";
                    break;
                case 3:
                    return "three";
                    break;
                case 4:
                    return "four";
                    break;
                case 5:
                    return "five";
                    break;
                case 6:
                    return "six";
                    break;
                case 7:
                    return "seven";
                    break;
                case 8:
                    return "eight";
                    break;
                case 9:
                    return "nine";
                    break;
                case 10:
                    return "ten";
                    break;
                case 11:
                    return "eleven";
                    break;
                case 12:
                    return "twelve";
                    break;
                case 13:
                    return "thirteen";
                    break;
                case 14:
                    return "fourteen";
                    break;
                case 15:
                    return "fifteen";
                    break;
                case 16:
                    return "sixteen";
                    break;
                case 17:
                    return "seventeen";
                    break;
                case 18:
                    return "eighteen";
                    break;
                case 19:
                    return "nineteen";
                    break;
                default:
                    return "";
                    break;
            }
        }

        private static string ConvertTens(int tens)
        {
            switch (tens)
            {
                case 2:
                    return "twenty";
                    break;
                case 3:
                    return "thirty";
                    break;
                case 4:
                    return "forty";
                    break;
                case 5:
                    return "fifty";
                    break;
                case 6:
                    return "sixty";
                    break;
                case 7:
                    return "seventy";
                    break;
                case 8:
                    return "eighty";
                    break;
                case 9:
                    return "ninety";
                    break;
                default:
                    return "";
                    break;
            }
        }
    }
}
