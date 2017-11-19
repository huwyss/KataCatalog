using System;

namespace KataGameOfLife
{
    public class Board : IBoard
    {
        public const char CELL_ALIVE = '#';
        public const char CELL_DEAD = '.';

        bool[,] _board;

        public Board()
        {
            _board = new bool[1, 1]; // default size
        }

        public void SetAlive(int x, int y, bool alive)
        {
            if (IsInField(x, y))
            {
                _board[x, y] = alive;
            }
        }

        public bool IsAlive(int x, int y)
        {
            if (IsInField(x, y))
            {
                return _board[x, y];
            }

            return false;
        }

        private bool IsInField(int x, int y)
        {
            return x >= 0 && x < DimX &&
                   y >= 0 && y < DimY;
        }

        public int DimX { get { return _board.GetLength(0); } }
        public int DimY { get { return _board.GetLength(1); } }

        public void SetBoardDim(int x, int y)
        {
            if (x > 0 && y > 0)
            {
                _board = new bool[x, y];
            }
        }

        public int NumberAliveNeighbors(int x, int y)
        {
            int count = 0;
            count += IsAlive(x - 1, y - 1) ? 1 : 0;
            count += IsAlive(x    , y - 1) ? 1 : 0;
            count += IsAlive(x + 1, y - 1) ? 1 : 0;

            count += IsAlive(x - 1, y    ) ? 1 : 0;
            count += IsAlive(x + 1, y    ) ? 1 : 0;

            count += IsAlive(x - 1, y + 1) ? 1 : 0;
            count += IsAlive(x    , y + 1) ? 1 : 0;
            count += IsAlive(x + 1, y + 1) ? 1 : 0;
            return count;
        }

        public void LoadBoard(string fields)
        {
            int dimx = fields.IndexOf('\n');
            int dimy = (fields.Length + 1) / (dimx + 1);
            SetBoardDim(dimx, dimy);

            int x = 0;
            int y = 0;
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == CELL_ALIVE)
                {
                    SetAlive(x, y, true);
                }

                x++;

                if (fields[i] == '\n')
                {
                    y++;
                    x = 0;
                }
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int y=0; y<DimY; y++)
            {
                for (int x=0; x<DimX; x++)
                {
                    result += IsAlive(x, y) ? CELL_ALIVE : CELL_DEAD;
                }

                result += '\n';
            }

            return result;
        }
    }
}