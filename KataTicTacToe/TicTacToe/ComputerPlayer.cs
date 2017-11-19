using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class ComputerPlayer : IPlayer
    {
        /// <summary>
        /// Does a computer move using minimax algorithm.
        /// http://neverstopbuilding.com/minimax
        /// </summary>
        public int DoMove(Piece piece, BoardState board)
        {
            if (board.IsWinner(Piece.X))
            {
                return 10;
            }
            else if (board.IsWinner(Piece.O))
            {
                return -10;
            }
            else if (board.IsDraw())
            {
                return 0;
            }
            else
            {
                var boardStatesForNextMove = new List<BoardState>();
                var emptyPositions = GetEmptyFields(board);
                var scores = new List<int>();
                foreach (var move in emptyPositions)
                {
                    BoardState boardForThisMove = board.Clone();
                    boardForThisMove.SetPiece(move.X, move.Y, piece);
                    boardStatesForNextMove.Add(boardForThisMove);
                    Piece nextPiece = piece == Piece.X ? Piece.O : Piece.X;
                    scores.Add(DoMove(nextPiece, boardForThisMove));
                }

                int max = scores.Max();
                int maxIndex = scores.IndexOf(max);
                int min = scores.Min();
                int minIndex = scores.IndexOf(min);
                if (piece == Piece.X)
                {
                    var selectedMove = emptyPositions[maxIndex];
                    board.SetPiece(selectedMove.X, selectedMove.Y, piece);
                    return max;
                }
                else
                {
                    var selectedMove = emptyPositions[minIndex];
                    board.SetPiece(selectedMove.X, selectedMove.Y, piece);
                    return min;
                }
            }
        }

        public List<Position> GetEmptyFields(BoardState board)
        {
            var emptyPositions = new List<Position>();
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board.GetPiece(x, y) == Piece.Empty)
                    {
                        emptyPositions.Add(new Position { X = x, Y = y });
                    }
                }
            }

            return emptyPositions;
        }
    }
}
