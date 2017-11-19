using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataNumbersInWords
{
    class Program
    {
        static void Main(string[] args)
        {
            double number;
            Converter converter = new Converter();
            for (int i = 0; i<5; i++)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out number))
                {
                    string words = converter.ToWords(number);
                    Console.WriteLine(words);
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
