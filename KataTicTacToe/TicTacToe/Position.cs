using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsEqual(Position other)
        {
            bool equal = true;
            equal &= X == other.X;
            equal &= Y == other.Y;
            return equal;
        }
    }
}
