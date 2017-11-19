using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataMaze;

namespace KataMazeTest
{
    [TestClass]
    public class MazeTest
    {
        [TestMethod]
        public void ToStringTest_WhenSize1_1()
        {
            Maze target = new Maze(1, 1);
            string expectedMaze = " _\n" +
                                  "|_|\n";
            Assert.AreEqual(expectedMaze, target.ToString());
        }

        [TestMethod]
        public void ToStringTest_WhenSize2_2()
        {
            Maze target = new Maze(2, 2);
            string expectedMaze = " _ _\n" +
                                  "|_|_|\n" +
                                  "|_|_|\n";
            Assert.AreEqual(expectedMaze, target.ToString());
        }

        [TestMethod]
        public void ToStringTest_WhenPath_ThenPathMarked()
        {
            Maze maze = new Maze(3, 3);
            maze.Grid[0, 0].SetWall(Direction.right, false);

            maze.Grid[1, 0].SetWall(Direction.right, false);
            maze.Grid[1, 0].SetWall(Direction.left, false);
            maze.Grid[1, 0].SetWall(Direction.down, false);
            maze.Grid[1, 0].IsPath = true;

            maze.Grid[2, 0].SetWall(Direction.left, false);
            maze.Grid[2, 0].SetWall(Direction.down, false);
            maze.Grid[2, 0].IsPath = true;

            maze.Grid[0, 1].SetWall(Direction.down, false);

            maze.Grid[1, 1].SetWall(Direction.down, false);
            maze.Grid[1, 1].SetWall(Direction.up, false);
            maze.Grid[1, 1].IsPath = true;

            maze.Grid[2, 1].SetWall(Direction.up, false);

            maze.Grid[0, 2].SetWall(Direction.up, false);
            maze.Grid[0, 2].SetWall(Direction.right, false);
            maze.Grid[0, 2].IsPath = true;

            maze.Grid[1, 2].SetWall(Direction.up, false);
            maze.Grid[1, 2].SetWall(Direction.left, false);
            maze.Grid[1, 2].SetWall(Direction.right, false);
            maze.Grid[1, 2].IsPath = true;

            maze.Grid[2, 2].SetWall(Direction.left, false);

            string expectedMaze = " _ _ _\n" +
                                  "|_ * *|\n" +
                                  "| |*|_|\n" +
                                  "|_ _ _|\n";
            Assert.AreEqual(expectedMaze, maze.ToString());
        }
    }
}
