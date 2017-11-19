using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        IInputReader _inputReader;

        public HumanPlayer(IInputReader inputReader)
        {
            _inputReader = inputReader;
        }

        public int DoMove(Piece piece, BoardState boardState)
        {
            GetUserInput();
            do
            {
                if (IsFinished())
                {
                    return -100;
                }

                if (IsInputValid() && boardState.GetPiece(MoveCoordinatesX, MoveCoordinatesY) == Piece.Empty)
                {
                    boardState.SetPiece(MoveCoordinatesX, MoveCoordinatesY, piece);
                    return 0;
                }

                GetUserInput();
            }
            while (true);
        }

        private void GetUserInput()
        {
            Input = _inputReader.GetUserInput();
        }

        private string _input;
        public string Input
        {
            get { return _input; }
            set { _input = value.ToLower().Trim(); }
        }

        public int MoveCoordinatesY
        {
            get
            {
                // a --> 0, b-->1, c-->2
                string firstPart = Input.Substring(0, 1);
                if (firstPart == "a")
                {
                    return 0;
                }
                else if (firstPart == "b")
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        public int MoveCoordinatesX
        {
            get
            {
                // 1-->0, 2-->1, 3-->2
                string secondPart = Input.Substring(1, 1);
                return int.Parse(secondPart) - 1;
            }
        }
        
        public bool IsFinished()
        {
            return Input == "exit";
        }

        public bool IsInputValid()
        {
            return (Input == "a1" || Input == "a2" || Input == "a3" ||
                Input == "b1" || Input == "b2" || Input == "b3" ||
                Input == "c1" || Input == "c2" || Input == "c3");
        }
    }
}
