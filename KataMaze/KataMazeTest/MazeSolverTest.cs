using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataMaze;

namespace KataMazeTest
{
    [TestClass]
    public class MazeSolverTest
    {
        [TestMethod]
        public void MazeSolverTest_WhenMaze2_2_ThenFindsPath()
        {
            Maze maze = new Maze(3, 3);
            maze.Grid[0, 0].SetWall(Direction.right, false);

            maze.Grid[1, 0].SetWall(Direction.right, false);
            maze.Grid[1, 0].SetWall(Direction.left, false);
            maze.Grid[1, 0].SetWall(Direction.down, false);

            maze.Grid[2, 0].SetWall(Direction.left, false);
            maze.Grid[2, 0].SetWall(Direction.down, false);

            maze.Grid[0, 1].SetWall(Direction.down, false);

            maze.Grid[1, 1].SetWall(Direction.down, false);
            maze.Grid[1, 1].SetWall(Direction.up, false);

            maze.Grid[2, 1].SetWall(Direction.up, false);

            maze.Grid[0, 2].SetWall(Direction.up, false);
            maze.Grid[0, 2].SetWall(Direction.right, false);

            maze.Grid[1, 2].SetWall(Direction.up, false);
            maze.Grid[1, 2].SetWall(Direction.left, false);
            maze.Grid[1, 2].SetWall(Direction.right, false);

            maze.Grid[2, 2].SetWall(Direction.left, false);


            MazeSolver solver = new MazeSolver(maze);
            solver.MarkPath(0, 2, 2, 0);
            string expectedMaze = " _ _ _\n" +
                                  "|_ * *|\n" +
                                  "| |*|_|\n" +
                                  "|_ _ _|\n";
            Assert.AreEqual(expectedMaze, maze.ToString());
        }
    }
}

