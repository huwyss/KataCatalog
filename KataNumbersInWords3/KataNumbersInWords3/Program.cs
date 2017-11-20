using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataNumbersInWords3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zahl eingeben");
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine(Converter.ToWords(number));
            Console.ReadLine();
        }
    }
}
