using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataMaze;

namespace KataMazeTest
{
    [TestClass]
    public class MazeGeneratorTest
    {
        [TestMethod]
        public void MazeTest_WhenSize1_1_ThenCorrectMaze()
        {
            MazeGenerator target = new MazeGenerator(1, 1);
            string mazeString = target.Create().ToString();
            string expectedMaze = " _\n" +
                                  "|_|\n";
            Assert.AreEqual(expectedMaze, mazeString);
        }

        [TestMethod]
        public void MazeTest_WhenSize2_1_ThenCorrectMaze()
        {
            MazeGenerator target = new MazeGenerator(2, 1);
            string mazeString = target.Create().ToString();
            string expectedMaze = " _ _\n" +
                                  "|_ _|\n";
            Assert.AreEqual(expectedMaze, mazeString);
        }

        [TestMethod]
        public void MazeTest_WhenSize1_2_ThenCorrectMaze()
        {
            MazeGenerator target = new MazeGenerator(1, 2);
            string mazeString = target.Create().ToString();
            string expectedMaze = " _\n" +
                                  "| |\n" +
                                  "|_|\n";
            Assert.AreEqual(expectedMaze, mazeString);
        }
    }
}
