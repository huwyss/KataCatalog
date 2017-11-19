using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataMaze
{
    public class MazeGenerator
    {
        private Maze _maze;

        public MazeGenerator(int sizeX, int sizeY)
        {
            _maze = new Maze(sizeX, sizeY);
        }

        public Maze Create()
        {
            int startX;
            int startY;
            _maze.GetRandomPosition(out startX, out startY);
            CarveFromPosition(startX, startY);
            return _maze;
        }

        public void CarveFromPosition(int x, int y)
        {
            _maze.Grid[x, y].HasBeenVisited = true;
            MazeHelper.ResetRandomDirection();
            Direction tryCarveDirection = Direction.up;
            int tryCellX = 0;
            int tryCellY = 0;
            bool foundNextCell = false;

            for (int i = 0; i < 4; i++)
            {
                tryCarveDirection = MazeHelper.GetRandomDirection();
                MazeHelper.GetNextPosition(x, y, tryCarveDirection, out tryCellX, out tryCellY);

                if (!_maze.IsInMaze(tryCellX, tryCellY))
                {
                    continue;
                }

                if (_maze.Grid[tryCellX, tryCellY].HasBeenVisited)
                {
                    continue;
                }

                foundNextCell = true;
                break;
            }

            if (foundNextCell)
            {
                // new cell found --> remove the walls in current and in next cell
                _maze.Grid[x, y].SetWall(tryCarveDirection, false);
                _maze.Grid[tryCellX, tryCellY].SetWall(MazeHelper.OppositeDirection(tryCarveDirection), false);

                CarveFromPosition(tryCellX, tryCellY); // create new path
                CarveFromPosition(x, y); // on the way back try to expand the path on this cell also
            }
        }
    }
}
