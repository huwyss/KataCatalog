using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataGameOfLife
{
    public class Board
    {
        bool[,] _board;
        public Board(int x, int y)
        {
            _board = new bool[x, y];
        }

        public void SetAlive(int x, int y)
        {
            _board[x, y] = true;
        }

        public bool GetAlive(int x, int y)
        {
            if (GetBoardDimY() - 1 < y ||  // Ort ist über dem Board 
                y < 0                  ||  // Ort ist unterhalb des Boardes
                x < 0                  ||  // Ort ist links des Boardes
                GetBoardDimX() - 1 < x)    // Ort ist rechts des Boardes
            {
                return false;
            }

            return _board[x, y];
        }

        public int GetAliveNeighbors(int x, int y)
        {
            int count = 0;
            if (GetAlive(x, y + 1))     { count++; } // upper neighbor
            if (GetAlive(x, y - 1))     { count++; } // lower neighbor
            if (GetAlive(x - 1, y))     { count++; } // left
            if (GetAlive(x + 1, y))     { count++; } // right
            if (GetAlive(x - 1, y + 1)) { count++; } // upper left
            if (GetAlive(x + 1, y + 1)) { count++; } // upper right
            if (GetAlive(x - 1, y - 1)) { count++; } // lower left
            if (GetAlive(x + 1, y - 1)) { count++; } // lower right

            return count;
        }

        public int GetBoardDimX()
        {
            return _board.GetLength(0);
        }

        public int GetBoardDimY()
        {
            return _board.GetLength(1);
        }
    }
}
