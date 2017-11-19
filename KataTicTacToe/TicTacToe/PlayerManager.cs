using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class PieceManager
    {
        public PlayerType FirstMover { get; set; }

        public Piece GetPiece(PlayerType player)
        {
            if (FirstMover == PlayerType.Human)
            {
                return player == PlayerType.Human ? Piece.X : Piece.O;
            }
            else
            {
                return player == PlayerType.Human ? Piece.O : Piece.X;
            }
        }

        public PlayerType GetRandomPlayerType()
        {
            Random rand = new Random();
            if (rand.Next(0, 2) == 0)
            {
                return PlayerType.Computer;
            }
            else
            {
                return PlayerType.Human;
            }
        }
    }
}
