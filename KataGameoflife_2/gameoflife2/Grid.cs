using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameoflife2
{
    public class Grid
    {
        int _x = 0;
        int _y = 0;
        Cell[,] _grid;
        public Grid(int x, int y)
        {
            _x = x;
            _y = y;
            _grid = new Cell[x, y];
        }
        public int SizeX()
        {
            return _x;
        }

        public int SizeY()
        {
            return _y;
        }

        public void SetAlive(int x, int y)
        {
            _grid[x, y] = new CellAlive();
        }

        public Cell GetCell(int x, int y)
        {
            if (_grid[x,y] == null)
            {
                return new CellDead();
            }

            return _grid[x, y];
        }
    }
}
