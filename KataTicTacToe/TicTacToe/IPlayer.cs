using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IPlayer
    {
        int DoMove(Piece piece, BoardState boardState);
    }
}
