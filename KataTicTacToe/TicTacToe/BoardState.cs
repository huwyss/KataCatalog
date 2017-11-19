using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class BoardState
    {
        private Piece[,] _board;
        private OutputWriter _outputWriter;

        public BoardState(OutputWriter outputWriter)
        {
            _outputWriter = outputWriter;
            Reset();
        }

        public Piece[,] Board
        {
            get
            {
                return _board;
            }
            set
            {
                _board = value;
            }
        }

        public void SetPiece(int x, int y, Piece piece)
        {
            _board[x, y] = piece;
        }

        public Piece GetPiece(int x, int y)
        {
            return _board[x, y];
        }

        public void Reset()
        {
            _board = new Piece[3, 3] { { Piece.Empty, Piece.Empty, Piece.Empty}, 
                                       { Piece.Empty, Piece.Empty, Piece.Empty}, 
                                       { Piece.Empty, Piece.Empty, Piece.Empty} };
        }

        public void PrintBoard()
        {
            _outputWriter.WriteLine("  1   2   3");
            _outputWriter.WriteLine("a " + PrintPiece(0, 0) + " | " + PrintPiece(1, 0) + " | " + PrintPiece(2, 0));
            _outputWriter.WriteLine("  ----------");
            _outputWriter.WriteLine("b " + PrintPiece(0, 1) + " | " + PrintPiece(1, 1) + " | " + PrintPiece(2, 1));
            _outputWriter.WriteLine("  ----------");
            _outputWriter.WriteLine("c " + PrintPiece(0, 2) + " | " + PrintPiece(1, 2) + " | " + PrintPiece(2, 2));
            _outputWriter.WriteLine("");
        }

        private string PrintPiece(int x, int y)
        {
            if (GetPiece(x, y) == Piece.X)
            {
                return "X";
            }
            else if (GetPiece(x, y) == Piece.O)
            {
                return "O";
            }

            return " ";
        }

        public bool IsWinner(Piece piece)
        {
            if ((GetPiece(0, 0) == piece && GetPiece(0, 1) == piece && GetPiece(0, 2) == piece) ||
            (GetPiece(1, 0) == piece && GetPiece(1, 1) == piece && GetPiece(1, 2) == piece) ||
            (GetPiece(2, 0) == piece && GetPiece(2, 1) == piece && GetPiece(2, 2) == piece) ||
            
            (GetPiece(0, 0) == piece && GetPiece(1, 0) == piece && GetPiece(2, 0) == piece) ||
            (GetPiece(0, 1) == piece && GetPiece(1, 1) == piece && GetPiece(2, 1) == piece) ||
            (GetPiece(0, 2) == piece && GetPiece(1, 2) == piece && GetPiece(2, 2) == piece) ||
            
            (GetPiece(0, 0) == piece && GetPiece(1, 1) == piece && GetPiece(2, 2) == piece) ||
            (GetPiece(2, 0) == piece && GetPiece(1, 1) == piece && GetPiece(0, 2) == piece))
            {
                return true;
            }

            return false;
        }

        public bool IsDraw()
        {
            bool isDraw = true;
            isDraw &= !IsWinner(Piece.X);
            isDraw &= !IsWinner(Piece.O);
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    isDraw &= GetPiece(x, y) != Piece.Empty;
                }
            }

            return isDraw;
        }

        public BoardState Clone()
        {
            var newBoardState = new BoardState(_outputWriter);
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    newBoardState.Board[x, y] = this.Board[x, y];
                }
            }

            return newBoardState;
        }

        public bool IsFinished()
        {
            return IsWinner(Piece.X) || IsWinner(Piece.O) || IsDraw();
        }

        public void PrintWinner()
        {
            if (IsWinner(Piece.X))
            {
                _outputWriter.WriteLine("X wins");
            }
            else if (IsWinner(Piece.O))
            {
                _outputWriter.WriteLine("O wins");
            } 
            else
            {
                _outputWriter.WriteLine("Draw");
            }
        }
    }
}

