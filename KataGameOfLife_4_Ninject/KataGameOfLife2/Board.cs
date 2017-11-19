using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataGameOfLife2
{
    public class Board : IBoard
    {
        public const char ALIVECELL = '#';
        public const char DEADCELL = '.';

        private bool[,] _cells;
        public Board()
        {
        }

        public void SetBoardDim(int dimx, int dimy)
        {
            _cells = new bool[dimx, dimy];
        }

        public void LoadBoard(string fields)
        {
            int lineLength = fields.IndexOf('\n');
            int lineCount = (fields.Length + 1) / (lineLength + 1);
            _cells = new bool[lineLength, lineCount];
            LoadCells(fields);
        }
        
        private void LoadCells(string fields)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == ALIVECELL)
                {
                    _cells[x, y] = true;
                }

                x++;

                if (fields[i] == '\n')
                {
                    y++;
                    x = 0;
                }
            }
        }

        public string Print()
        {
            string boardString = "";
            for (int y = 0; y < DimY; y++)
            {
                for (int x = 0; x < DimX; x++)
                {
                    boardString += IsAlive(x, y) ? ALIVECELL : DEADCELL;
                }

                boardString += "\n";
            }

            return boardString;
        }

        public int DimX { get { return _cells.GetLength(0); } }
        public int DimY { get { return _cells.GetLength(1); } }

        public bool IsAlive(int x, int y)
        {
            if (IsInBoard(x, y))
            {
                return _cells[x, y];
            }

            return false;
        }

        public void SetAlive(int x, int y, bool alive)
        {
            if (IsInBoard(x, y))
            {
                _cells[x, y] = alive;
            }
        }

        private bool IsInBoard(int x, int y)
        {
            bool inBoard = x >= 0 && x < DimX &&
                           y >= 0 && y < DimY;
            return inBoard;
        }
        
    }
}
