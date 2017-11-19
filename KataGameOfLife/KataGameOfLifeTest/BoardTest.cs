using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataGameOfLife;

namespace KataGameOfLifeTest
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void CountNeighbors_WhenNewBoard_ThenCellsAreDead()
        {
            Board board = new Board(3, 3);

            Assert.AreEqual(false, board.GetAlive(1, 1));       
        }

        [TestMethod]
        public void CountNeighbors_WhenCellInNewBoardIsSet_ThenThatCellIsAlive()
        {
            Board board = new Board(3, 3);

            Assert.AreEqual(false, board.GetAlive(1, 1));

            board.SetAlive(1, 1);

            Assert.AreEqual(true, board.GetAlive(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsCentralAndOnlyAlive_ThenCountIsZero()
        {
            Board board = new Board(3, 3);
            board.SetAlive(1, 1);
            Assert.AreEqual(0, board.GetAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsCentralAndOneUpperNeighbor_ThenCountIs_1()
        {
            Board board = new Board(3, 3);
            board.SetAlive(1, 2);
            Assert.AreEqual(1, board.GetAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsCentralAndOneLowerNeighbor_ThenCountIs_1()
        {
            Board board = new Board(3, 3);
            board.SetAlive(1, 0);
            Assert.AreEqual(1, board.GetAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsCentralAndOneLeftNeighbor_ThenCountIs_1()
        {
            Board board = new Board(3, 3);
            board.SetAlive(0, 1);
            Assert.AreEqual(1, board.GetAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsCentralAndOneRightNeighbor_ThenCountIs_1()
        {
            Board board = new Board(3, 3);
            board.SetAlive(2, 1);
            Assert.AreEqual(1, board.GetAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsCentralAndOneUpperLeftNeighbor_ThenCountIs_1()
        {
            Board board = new Board(3, 3);
            board.SetAlive(0, 2);
            Assert.AreEqual(1, board.GetAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsCentralAndOneUpperRightNeighbor_ThenCountIs_1()
        {
            Board board = new Board(3, 3);
            board.SetAlive(2, 2);
            Assert.AreEqual(1, board.GetAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsCentralAndOneLowerLeftNeighbor_ThenCountIs_1()
        {
            Board board = new Board(3, 3);
            board.SetAlive(0, 0);
            Assert.AreEqual(1, board.GetAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsCentralAndOneLowerRightNeighbor_ThenCountIs_1()
        {
            Board board = new Board(3, 3);
            board.SetAlive(2, 0);
            Assert.AreEqual(1, board.GetAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsCentralAndAllNeighbors_ThenCountIs_8()
        {
            Board board = new Board(3, 3);
            board.SetAlive(0, 0);
            board.SetAlive(0, 1);
            board.SetAlive(0, 2);
            board.SetAlive(1, 0);
            board.SetAlive(1, 1);
            board.SetAlive(1, 2);
            board.SetAlive(2, 0);
            board.SetAlive(2, 1);
            board.SetAlive(2, 2);
            Assert.AreEqual(8, board.GetAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsUpperBorderAndNoNeighbors_ThenCountIs_0()
        {
            Board board = new Board(3, 3);
            Assert.AreEqual(0, board.GetAliveNeighbors(1, 2));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsLowerBorderAndNoNeighbors_ThenCountIs_0()
        {
            Board board = new Board(3, 3);
            Assert.AreEqual(0, board.GetAliveNeighbors(1, 0));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsLeftBorderAndNoNeighbors_ThenCountIs_0()
        {
            Board board = new Board(3, 3);
            Assert.AreEqual(0, board.GetAliveNeighbors(0, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsRightBorderAndNoNeighbors_ThenCountIs_0()
        {
            Board board = new Board(3, 3);
            Assert.AreEqual(0, board.GetAliveNeighbors(1, 2));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsUpperBorderAndHas3Neighbors_ThenCountIs_3()
        {
            Board board = new Board(4, 2);

            // .OX.   O Cell to find neighbors from
            // XX..   . dead  X alive
            board.SetAlive(0, 0);
            board.SetAlive(1, 0);
            board.SetAlive(2, 1);

            Assert.AreEqual(3, board.GetAliveNeighbors(1, 1));
        }

        [TestMethod]
        public void CountNeighbors_WhenCellIsUpperLeftBorderAndHas2Neighbors_ThenCountIs_2()
        {
            Board board = new Board(4, 2);

            // O.X.   O Cell to find neighbors from
            // XX..   . dead  X alive
            board.SetAlive(0, 0);
            board.SetAlive(1, 0);
            board.SetAlive(2, 1);

            Assert.AreEqual(2, board.GetAliveNeighbors(0, 1));
        }
    }
}
