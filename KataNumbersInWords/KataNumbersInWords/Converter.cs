using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataNumbersInWords
{
    public class Converter
    {
        public string ToWords(double number)
        {
            int numberInt = (int)number;
            int one = GetOne(numberInt);
            int thousand = GetThousand(numberInt);
            int million = GetMillion(numberInt);

            string resultWord = "";

            if (numberInt == 0)
            {
                resultWord = "zero";
            }
            
            else if (numberInt <= 999999999)
            {
                if (million != 0)
                {
                    resultWord = GetWords_1_999(million) + " million";
                    numberInt = numberInt % 1000000;
                    if (numberInt != 0)
                        resultWord += " ";
                }

                if (thousand != 0)
                {
                    resultWord += GetWords_1_999(thousand) + " thousand";
                    numberInt = numberInt % 1000;
                    if (numberInt != 0)
                        resultWord += " ";
                }
                
                if (one != 0)
                {
                    resultWord += GetWords_1_999(one);
                }
            }
            else
            {
                resultWord = "number is too large...";
            }

            return resultWord;
        }

        // 123 --> 3
        private int GetLastDigit(int number)
        {
            int lastDigit = number % 10;
            return lastDigit;
        }

        // 123 --> 20
        private int GetTen(int number)
        {
            int ten = number % 100 - GetLastDigit(number);
            return ten;
        }

        // 1123 --> 100
        private int GetHundred(int number)
        {
            int hundred = number % 1000 - GetTen(number) - GetLastDigit(number);
            return hundred;
        }

        // 123456 --> 456
        private int GetOne(int number)
        {
            int one = number % 1000;
            return one;
        }

        // 123'456 --> 123
        private int GetThousand(int number)
        {
            int thousand = number / 1000 % 1000;
            return thousand;
        }

        // 123'456'789 --> 123
        private int GetMillion(int number)
        {
            int million = number / 1000000 % 1000;
            return million;
        }

        private string GetWords_1_99(int number)
        {
            string resultWord = "";
            int lastDigit = GetLastDigit(number);
            int ten = GetTen(number);
            if (number <= 20)
            {
                resultWord = GetWordDirect(number);
            }
            else if (number <= 99)
            {
                resultWord = GetWordDirect(ten);
                if (lastDigit != 0)
                {
                    resultWord += " " + GetWordDirect(lastDigit);
                }
            }

            return resultWord;
        }

        private string GetWords_1_999(int number)
        {
            string resultWord = "";
            int hundred = GetHundred(number);
            if (number <= 99)
            {
                resultWord = GetWords_1_99(number);
            }
            else if (number <= 999)
            {
                resultWord = GetWordDirect(hundred);
                if (number - hundred != 0)
                {
                    resultWord += " and " + GetWords_1_99(number - hundred);
                }
            }

            return resultWord;
        }

        private string GetWordDirect(int number)
        {
            switch (number)
            {
                case 0: return "zero"; break;
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
                case 20: return "twenty"; break;
                case 30: return "thirty"; break;
                case 40: return "fourty"; break;
                case 50: return "fifty"; break;
                case 60: return "sixty"; break;
                case 70: return "seventy"; break;
                case 80: return "eighty"; break;
                case 90: return "ninety"; break;
                case 100: return "one hundred"; break;
                case 200: return "two hundred"; break;
                case 300: return "three hundred"; break;
                case 400: return "four hundred"; break;
                case 500: return "fife hundred"; break;
                case 600: return "six hundred"; break;
                case 700: return "seven hundred"; break;
                case 800: return "eight hundred"; break;
                case 900: return "nine hundred"; break;
            }

            return "";
        }
    }
}
