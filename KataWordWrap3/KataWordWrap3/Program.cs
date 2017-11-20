using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataWordWrap3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text:");
            string line = Console.ReadLine();
            Console.WriteLine("Enter max line:");
            string length = Console.ReadLine();

            Console.Write(WordWrapper.Wrap(line, int.Parse(length)));
            Console.ReadLine();
        }
    }
}
