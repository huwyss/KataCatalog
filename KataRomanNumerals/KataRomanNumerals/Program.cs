using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataRomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            RomanConverter converter = new RomanConverter();
            for (int i = 0; i < 5; i++)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    string roman = converter.ToRoman(number);
                    Console.WriteLine(roman);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Please enter a valid number...");
                }
            }

            Console.ReadLine();
        }
    }
}
