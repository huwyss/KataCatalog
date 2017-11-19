using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataGameOfLife
{
    public class GameOfLife
    {
        IBoard _board;
        IBoard _nextBoard;

        public GameOfLife(IBoard board)
        {
            _board = board;
        }

        public void NextGen()
        {
            _nextBoard = new Board();
            _nextBoard.SetBoardDim(_board.DimX, _board.DimY);

            for (int y = 0; y < _nextBoard.DimY; y++)
            {
                for (int x = 0; x < _nextBoard.DimX; x++)
                {
                     _nextBoard.SetAlive(x, y, IsNextAlive(IsAlive(x, y), _board.NumberAliveNeighbors(x, y)));
                }
            }

            _board = _nextBoard;
        }

        private bool IsNextAlive(bool currentAlive, int numberAliveNeigh)
        {
            if ((currentAlive && (numberAliveNeigh == 3 || numberAliveNeigh == 2)) ||
                (!currentAlive && numberAliveNeigh == 3))
            {
                return true;
            }

            return false;
        }

        public bool IsAlive(int x, int y)
        {
            return _board.IsAlive(x, y);
        }

        public override string ToString()
        {
            return _board.ToString();
        }

        public void LoadBoard(string fields)
        {
            _board.LoadBoard(fields);
        }
    }
}
