using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataYahtzee
{
    class Program
    {
        static void Main(string[] args)
        {
            var yahtzee = new Yahtzee();
            Console.WriteLine("Enter the 5 Yahtzee dices in the form of 12345.");
            string input = Console.ReadLine();
            bool valid = true;
            List<int> dices = new List<int>();
            if (input.Length < 5)
            {
                valid = false;
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    int number = 0;
                    if (int.TryParse(input[i].ToString(), out number))
                    {
                        dices.Add(number);
                    }
                    else
                    {
                        valid = false;
                    }
                }
            }

            if (valid)
            {
                Console.WriteLine("Ones: " + yahtzee.Evaluate(dices, YahtzeeType.Ones));
                Console.WriteLine("Twos: " + yahtzee.Evaluate(dices, YahtzeeType.Twos));
                Console.WriteLine("Threes: " + yahtzee.Evaluate(dices, YahtzeeType.Threes));
                Console.WriteLine("Fours: " + yahtzee.Evaluate(dices, YahtzeeType.Fours));
                Console.WriteLine("Fives: " + yahtzee.Evaluate(dices, YahtzeeType.Fives));
                Console.WriteLine("Sixes: " + yahtzee.Evaluate(dices, YahtzeeType.Sixes));
                Console.WriteLine("Pair: " + yahtzee.Evaluate(dices, YahtzeeType.Pair));
                Console.WriteLine("2 Pairs: " + yahtzee.Evaluate(dices, YahtzeeType.TwoPairs));
                Console.WriteLine("Three of a kind: " + yahtzee.Evaluate(dices, YahtzeeType.ThreeOfAKind));
                Console.WriteLine("Four of a kind: " + yahtzee.Evaluate(dices, YahtzeeType.FourOfAKind));
                Console.WriteLine("Small Straight: " + yahtzee.Evaluate(dices, YahtzeeType.SmallStraight));
                Console.WriteLine("Large Straight: " + yahtzee.Evaluate(dices, YahtzeeType.LargeStraight));
                Console.WriteLine("Full House: " + yahtzee.Evaluate(dices, YahtzeeType.FullHouse));
                Console.WriteLine("Yahtzee: " + yahtzee.Evaluate(dices, YahtzeeType.Yahtzee));
                Console.WriteLine("Chance: " + yahtzee.Evaluate(dices, YahtzeeType.Chance));
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            Console.WriteLine("Press Enter.");
            Console.ReadLine();
        }
    }
}
