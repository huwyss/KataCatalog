using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataGameOfLife2
{
    public class GameOfLife
    {
        private IBoard _board;
        private IBoard _nextGenBoard;

        public GameOfLife(IBoard board)
        {
            _board = board;
        }

        public void LoadBoard(string fields)
        {
            _board.LoadBoard(fields);
        }

        public void SetBoardDim(int dimx, int dimy)
        {
            _board.SetBoardDim(dimx, dimy);
        }

        public string Print()
        {
            return _board.Print();
        }

        public int NumberAliveNeighbors(int x, int y)
        {
            int number = 0;
            number += _board.IsAlive(x - 1, y - 1) ? 1 : 0;
            number += _board.IsAlive(x    , y - 1) ? 1 : 0;
            number += _board.IsAlive(x + 1, y - 1) ? 1 : 0;
            number += _board.IsAlive(x - 1, y) ? 1 : 0;
            number += _board.IsAlive(x + 1, y) ? 1 : 0;
            number += _board.IsAlive(x - 1, y + 1) ? 1 : 0;
            number += _board.IsAlive(x    , y + 1) ? 1 : 0;
            number += _board.IsAlive(x + 1, y + 1) ? 1 : 0;
            return number;
        }

        public void NextGen()
        {
            _nextGenBoard = new Board();
            _nextGenBoard.SetBoardDim(_board.DimX, _board.DimY);
            for(int y = 0; y<_nextGenBoard.DimY; y++)
            {
                for (int x = 0; x < _nextGenBoard.DimX; x++)
                {
                    _nextGenBoard.SetAlive(x, y, IsAliveNextGen(x, y));
                }
            }

            _board = _nextGenBoard;
        }

        public bool IsAlive(int x, int y)
        {
            return _board.IsAlive(x, y);
        }

        private bool IsAliveNextGen(int x, int y)
        {
            if (_board.IsAlive(x, y)) // alive cell
            {
                if (NumberAliveNeighbors(x, y) == 2 ||
                   NumberAliveNeighbors(x, y) == 3)
                {
                    return true;
                }
            }
            else // dead cell
            {
                if (NumberAliveNeighbors(x, y) == 3)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
