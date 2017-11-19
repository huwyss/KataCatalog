using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataMaze
{
    public static class MazeHelper
    {
        private static int _randomDirectionIndex;
        private static Direction[] _directions = new Direction[4] { Direction.up, Direction.right, Direction.down, Direction.left };

        private static int _rightDirectionIndex;
        private static Direction[] _rightDirections = new Direction[4] { Direction.right, Direction.up, Direction.left, Direction.down };

        private static Random _random = new Random();

        public static Direction GetRandomDirection()
        {
            Direction dir = _directions[_randomDirectionIndex];
            _randomDirectionIndex++;
            _randomDirectionIndex %= 4;
            return dir;
        }

        public static void ResetRandomDirection()
        {
            _directions = _directions.OrderBy(x => _random.Next()).ToArray();
            _randomDirectionIndex = 0;
        }

        public static Direction OppositeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.down:
                    return Direction.up;
                case Direction.up:
                    return Direction.down;
                case Direction.left:
                    return Direction.right;
                case Direction.right:
                    return Direction.left;
                default:
                    return Direction.left;
            }
        }

        public static void GetNextPosition(int currentX, int currentY, Direction direction, out int nextX, out int nextY)
        {
            switch (direction)
            {
                case Direction.up:
                    nextX = currentX;
                    nextY = currentY - 1;
                    break;
                case Direction.down:
                    nextX = currentX;
                    nextY = currentY + 1;
                    break;
                case Direction.left:
                    nextX = currentX - 1;
                    nextY = currentY;
                    break;
                case Direction.right:
                    nextX = currentX + 1;
                    nextY = currentY;
                    break;
                default:
                    nextX = currentX;
                    nextY = currentY;
                    break;
            }
        }

        public static void ResetRightestDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.up:
                    _rightDirectionIndex = 0;
                    break;
                case Direction.right:
                    _rightDirectionIndex = 3;
                    break;
                case Direction.down:
                    _rightDirectionIndex = 2;
                    break;
                case Direction.left:
                    _rightDirectionIndex = 1;
                    break;
                default:
                    _rightDirectionIndex = 0;
                    break;
            }
        }

        public static Direction GetNextRightestDirection()
        {
            Direction direction = _rightDirections[_rightDirectionIndex % 4];
            _rightDirectionIndex++;
            return direction;
        }

    }
}
