using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataVeryLong
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter a calculation like '1+2' or enter 'pi'. Operations are + - * /. Numbers are integers of any size.");
                string input = Console.ReadLine();
                if (input == "pi")
                {
                    Console.WriteLine("Enter the number of digits you want.");
                    string digitsString = Console.ReadLine();
                    int numberDigits = 0;
                    if (int.TryParse(digitsString, out numberDigits))
                    {
                        string pi = VeryLongMath.Pi(numberDigits).ToString();
                        Console.WriteLine("Pi is: " + pi.ToString());
                    }
                    else
                    {
                        Console.WriteLine("invalid number.");
                    }

                    continue;
                }

                if (input == "sqrt")
                {
                    int numberDigits;
                    VeryLong number;
                    Console.WriteLine("Square root of?");
                    string numberString = Console.ReadLine();
                    Console.WriteLine("number of digits?");
                    string digitsString = Console.ReadLine();
                    if (int.TryParse(digitsString, out numberDigits))
                    {
                        number = new VeryLong(numberString);
                        string sqrt = VeryLongMath.Sqrt(number, numberDigits).ToString();
                        Console.WriteLine("Sqrt of " + numberString + " is: " + sqrt.ToString());
                    }
                    else
                    {
                        Console.WriteLine("invalid number.");
                    }
                }

                string[] parts = input.Split(new char[] {'+', '-', '*', '/'});
                if (parts.Length != 2)
                {
                    Console.WriteLine("invalid input.");
                    continue;
                }

                VeryLong number0 = new VeryLong(parts[0]);
                VeryLong number1 = new VeryLong(parts[1]);

                if (input.Contains('+'))
                {
                    Console.WriteLine(number0.Add(number1).ToString());
                }
                else if (input.Contains('*'))
                {
                    Console.WriteLine(number0.Multiply(number1).ToString());
                }
                else if (input.Contains('-'))
                {
                    Console.WriteLine(number0.Subtract(number1).ToString());
                }
                else if (input.Contains('/'))
                {
                    VeryLong remainder;
                    VeryLong quotient = number0.DivideBy(number1, out remainder);
                    Console.WriteLine(quotient.ToString() + " Remainder: " + remainder);

                    VeryLong quotientWithDecimal = number0.DivideBy(number1, 100);
                    Console.WriteLine(quotientWithDecimal.ToString());
                }
                else
                {
                    Console.WriteLine("Please enter a valid operation...");
                }
            }

            Console.ReadLine();
        }
    }
}
