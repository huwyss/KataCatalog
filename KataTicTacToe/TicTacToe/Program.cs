using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticTacToeObjects = new TicTacToeObjects();
            var inputReader = new InputReader();
            var outputWriter = new OutputWriter();
            ticTacToeObjects.BoardState = new BoardState(outputWriter);
            ticTacToeObjects.HumanPlayer = new HumanPlayer(inputReader);
            ticTacToeObjects.ComputerPlayer = new ComputerPlayer();
            ticTacToeObjects.PieceManager = new PieceManager();

            TicTacToeGame game = new TicTacToeGame(ticTacToeObjects);
            game.RunGame();
            Console.ReadLine();
        }
    }
}
