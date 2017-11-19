using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KataMaze
{
    public enum Direction
    {
        up = 0, 
        right = 1, 
        down = 2, 
        left = 3
    }

    public class Maze
    {
        public Cell[,] Grid { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public Maze(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;

            Grid = new Cell[SizeX, SizeY];
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    Grid[x, y] = new Cell();
                }
            }
        }

        public override string ToString()
        {
            string mazeString = "";

            for (int x = 0; x < SizeX; x++)
            {
                mazeString += " _";
            }

            mazeString += "\n";

            for (int y = 0; y < SizeY; y++)
            {
                for (int x = 0; x < SizeX; x++)
                {
                    mazeString += Grid[x, y].HasWall(Direction.left) ? "|" : " ";
                    if (Grid[x, y].IsPath)
                    {
                        mazeString += Grid[x, y].HasWall(Direction.down) ? "_" : "*";
                    }
                    else
                    {
                        mazeString += Grid[x, y].HasWall(Direction.down) ? "_" : " ";
                    }
                }
                mazeString += "|\n";
            }

            return mazeString;
        }

        public bool IsInMaze(int x, int y)
        {
            bool isInMaze = (x >= 0 && x < SizeX &&
                             y >= 0 && y < SizeY);
            return isInMaze;
        }

        public void GetRandomPosition(out int x, out int y)
        {
            Random random = new Random();
            x = random.Next(SizeX - 1);
            y = random.Next(SizeY - 1);
        }
    }
}
