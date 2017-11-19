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
            Console.WriteLine("Enter a text: ");
            string input = Console.ReadLine();
            Console.WriteLine("Enter the linelength: ");
            string lengthString = Console.ReadLine();
            int lineLength = int.Parse(lengthString);
            Console.WriteLine(WordWrapper.Wrap(input, lineLength));
            Console.ReadLine();
        }
    }
}
