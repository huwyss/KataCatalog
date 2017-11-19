using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class InputReader : IInputReader
    {
        public string GetUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
