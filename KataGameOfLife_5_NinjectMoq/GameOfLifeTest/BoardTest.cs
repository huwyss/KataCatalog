using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataGameOfLife;

namespace GameOfLifeTest
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void SetIsAliveTest_WhenInField_ThenReturnAlive()
        {
            var board = new Board();
            Assert.IsFalse(board.IsAlive(0, 0));
            board.SetAlive(0, 0, true);
            Assert.IsTrue(board.IsAlive(0, 0));
        }

        [TestMethod]
        public void IsAliveTest_WhenOutOfField_ThenReturnFalse()
        {
            var board = new Board();
            Assert.IsFalse(board.IsAlive(-1, -1));
        }

        [TestMethod]
        public void IsAliveTest_WhenOutOfField2_ThenReturnFalse()
        {
            var board = new Board();
            Assert.IsFalse(board.IsAlive(1, 1));
        }

        [TestMethod]
        public void SetIsAliveTest_WhenOffField_ThenReturnDead()
        {
            var board = new Board();
            Assert.IsFalse(board.IsAlive(-1, 0));
            board.SetAlive(-1, 0, true);
            Assert.IsFalse(board.IsAlive(-1, 0));
        }

        [TestMethod]
        public void SetBoardDimTest_WhenChangeDim_ThenDimNew()
        {
            var board = new Board();
            Assert.AreEqual(1, board.DimX);
            Assert.AreEqual(1, board.DimY);

            board.SetBoardDim(2, 3);
            Assert.AreEqual(2, board.DimX);
            Assert.AreEqual(3, board.DimY);
        }

        [TestMethod]
        public void NumberAliveNeighborsTest_When0Neighbors_ThenReturn0()
        {
            var board = new Board();
            board.SetBoardDim(3, 3);
            Assert.AreEqual(0, board.NumberAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void NumberAliveNeighborsTest_When1NeighborUpLeft_ThenReturn1()
        {
            var board = new Board();
            board.SetBoardDim(3, 3);
            board.SetAlive(0, 0, true);
            Assert.AreEqual(1, board.NumberAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void NumberAliveNeighborsTest_When1NeighborUp_ThenReturn1()
        {
            var board = new Board();
            board.SetBoardDim(3, 3);
            board.SetAlive(1, 0, true);
            Assert.AreEqual(1, board.NumberAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void NumberAliveNeighborsTest_When1NeighborUpRight_ThenReturn1()
        {
            var board = new Board();
            board.SetBoardDim(3, 3);
            board.SetAlive(2, 0, true);
            Assert.AreEqual(1, board.NumberAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void NumberAliveNeighborsTest_When5Neighbors_ThenReturns()
        {
            var board = new Board();
            board.SetBoardDim(3, 3);
            board.SetAlive(0, 1, true);
            board.SetAlive(2, 1, true);
            board.SetAlive(0, 2, true);
            board.SetAlive(1, 2, true);
            board.SetAlive(2, 2, true);
            Assert.AreEqual(5, board.NumberAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void LoadTest_WhenHasLineFeedAtEnd_ThenOk()
        {
            string fields = "....\n" +
                            "##.#\n" +
                            ".#..\n";
            var board = new Board();
            board.LoadBoard(fields);
            Assert.AreEqual(fields, board.ToString());
        }

        [TestMethod]
        public void LoadTest_WhenHasNoLineFeedAtEnd_ThenOk()
        {
            string fields = "....\n" +
                            "##.#\n" +
                            ".#..";
            var board = new Board();
            board.LoadBoard(fields);
            Assert.AreEqual(fields + "\n", board.ToString());
        }
    }
}
