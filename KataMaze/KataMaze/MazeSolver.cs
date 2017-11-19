using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataMaze
{
    public class MazeSolver
    {
        private Maze _maze;

        Direction _currentDirection;
        private int _currentPosX;
        private int _currentPosY;

        public MazeSolver(Maze maze)
        {
            _maze = maze;
        }

        public void MarkPath(int startX, int startY, int targetX, int targetY)
        {
            _maze.Grid[targetX, targetY].IsPath = true;

            _currentDirection = Direction.up;
            _currentPosX = startX;
            _currentPosY = startY;
            while (!(_currentPosX == targetX && _currentPosY == targetY))
            {
                MazeHelper.ResetRightestDirection(_currentDirection);
                for (int countWays = 0; countWays < 4; countWays++)
                {
                    Direction tryDirection = MazeHelper.GetNextRightestDirection();
                    if (!_maze.Grid[_currentPosX, _currentPosY].HasWall(tryDirection))
                    {
                        bool escapeDeadEnd = countWays == 3;
                        _currentDirection = tryDirection;
                        Walk(_currentDirection, escapeDeadEnd);
                        break;
                    }
                }
            }
        }

        private void Walk(Direction direction, bool escapeDeadEnd)
        {
            if (escapeDeadEnd)
            {
                // if we are in a dead end then remove the path
                _maze.Grid[_currentPosX, _currentPosY].IsPath = false;
            }
            else
            {
                // if we have been in this cell then remove the path
                // if we have not been in this cell mark the path
                _maze.Grid[_currentPosX, _currentPosY].IsPath = !_maze.Grid[_currentPosX, _currentPosY].HasWalked;
            }

            _maze.Grid[_currentPosX, _currentPosY].HasWalked = true;

            int nextX;
            int nextY;
            MazeHelper.GetNextPosition(_currentPosX, _currentPosY, direction, out nextX, out nextY);

            if (!_maze.Grid[nextX, nextY].HasWalked)
            {
                // if we have been in the next cell before then we were on a detour and the next cell belongs to the path
                _maze.Grid[_currentPosX, _currentPosY].IsPath = true;
            }

            _currentPosX = nextX;
            _currentPosY = nextY;
        }
    }
}
