using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataGameOfLife2;
using Moq;

namespace GameOfLifeTest
{
    [TestClass]
    public class GameOfLifeTest
    {
        [TestMethod]
        public void CtorTest()
        {
            string fields = "..#..\n" +
                            ".....\n" +
                            "###..\n";
            Board board = new Board();
            board.LoadBoard(fields);
            GameOfLife gol = new GameOfLife(board);
            Assert.AreEqual(fields, gol.Print());
        }

        [TestMethod]
        public void NumberAliveNeighborTest1()
        {
            string fields = "..##.\n" +
                            ".....\n" +
                            "###..\n";
            Board board = new Board();
            board.LoadBoard(fields);
            GameOfLife gol = new GameOfLife(board);

            Assert.AreEqual(0, gol.NumberAliveNeighbors(0, 0)); // line 1
            Assert.AreEqual(1, gol.NumberAliveNeighbors(1, 0));
            Assert.AreEqual(1, gol.NumberAliveNeighbors(2, 0));
            Assert.AreEqual(1, gol.NumberAliveNeighbors(3, 0));
            Assert.AreEqual(1, gol.NumberAliveNeighbors(4, 0));

            Assert.AreEqual(2, gol.NumberAliveNeighbors(0, 1)); // line 2
            Assert.AreEqual(4, gol.NumberAliveNeighbors(1, 1));
            Assert.AreEqual(4, gol.NumberAliveNeighbors(2, 1));
            Assert.AreEqual(3, gol.NumberAliveNeighbors(3, 1));
            Assert.AreEqual(1, gol.NumberAliveNeighbors(4, 1));

            Assert.AreEqual(1, gol.NumberAliveNeighbors(0, 2)); // line 3
            Assert.AreEqual(2, gol.NumberAliveNeighbors(1, 2));
            Assert.AreEqual(1, gol.NumberAliveNeighbors(2, 2));
            Assert.AreEqual(1, gol.NumberAliveNeighbors(3, 2));
            Assert.AreEqual(0, gol.NumberAliveNeighbors(4, 2));
        }

        [TestMethod]
        public void NextGenTest_WhenAliveAndTwoNeigh_ThenAlive()
        {
            string fields = "...\n" +
                            ".#.\n" + // it is about the middle cell
                            "##.\n";
            Board board = new Board();
            board.LoadBoard(fields);
            GameOfLife gol = new GameOfLife(board);
            gol.NextGen();
            Assert.IsTrue(gol.IsAlive(1, 1));
        }

        [TestMethod]
        public void NextGenTest_WhenAliveAndThreeNeigh_ThenAlive()
        {
            string fields = "...\n" +
                            ".#.\n" + // it is about the middle cell
                            "###\n";
            Board board = new Board();
            board.LoadBoard(fields);
            GameOfLife gol = new GameOfLife(board);
            gol.NextGen();
            Assert.IsTrue(gol.IsAlive(1, 1));
        }

        [TestMethod]
        public void NextGenTest_WhenAliveAndOneNeigh_ThenDead()
        {
            string fields = "...\n" +
                            ".#.\n" + // it is about the middle cell
                            "#..\n";
            Board board = new Board();
            board.LoadBoard(fields);
            GameOfLife gol = new GameOfLife(board);
            gol.NextGen();
            Assert.IsFalse(gol.IsAlive(1, 1));
        }

        [TestMethod]
        public void NextGenTest_WhenAliveAndFourNeigh_ThenDead()
        {
            string fields = "...\n" +
                            ".##\n" + // it is about the middle cell
                            "###\n";
            Board board = new Board();
            board.LoadBoard(fields);
            GameOfLife gol = new GameOfLife(board);
            gol.NextGen();
            Assert.IsFalse(gol.IsAlive(1, 1));
        }

        [TestMethod]
        public void NextGenTest_WhenDeadAndThreeNeigh_ThenAlive()
        {
            string fields = "...\n" +
                            "...\n" + // it is about the middle cell
                            "###\n";
            Board board = new Board();
            board.LoadBoard(fields);
            GameOfLife gol = new GameOfLife(board);
            gol.NextGen();
            Assert.IsTrue(gol.IsAlive(1, 1));
        }

        [TestMethod]
        public void NextGenTest_WhenDeadAndTwoNeigh_ThenDead()
        {
            string fields = "...\n" +
                            "...\n" + // it is about the middle cell
                            "##.\n";
            Board board = new Board();
            board.LoadBoard(fields);
            GameOfLife gol = new GameOfLife(board);
            gol.NextGen();
            Assert.IsFalse(gol.IsAlive(1, 1));
        }

        [TestMethod]
        public void NextGenTest_WhenDeadAndFourNeigh_ThenDead()
        {
            string fields = "...\n" +
                            "..#\n" + // it is about the middle cell
                            "###\n";
            Board board = new Board();
            board.LoadBoard(fields);
            GameOfLife gol = new GameOfLife(board);
            gol.NextGen();
            Assert.IsFalse(gol.IsAlive(1, 1));
        }

        // -------------------------------------------------------------
        // Moq Tests
        // -------------------------------------------------------------

        [TestMethod]
        public void NumberAliveNeighborTest_WhenOneAliveUpLeft_ThenOne()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(board => board.IsAlive(0, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(1, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(0, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(0, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 2)).Returns(false);

            var gol = new GameOfLife(boardMock.Object);
            Assert.AreEqual(1, gol.NumberAliveNeighbors(1, 1), "should have 1 neighbor");
        }

        [TestMethod]
        public void NumberAliveNeighborTest_WhenOneAliveUp_ThenOne()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(board => board.IsAlive(0, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(2, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(0, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(0, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 2)).Returns(false);

            var gol = new GameOfLife(boardMock.Object);
            Assert.AreEqual(1, gol.NumberAliveNeighbors(1, 1), "should have 1 neighbor");
        }

        [TestMethod]
        public void NumberAliveNeighborTest_WhenOneAliveUpRight_ThenOne()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(board => board.IsAlive(0, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(0, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(0, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 2)).Returns(false);

            var gol = new GameOfLife(boardMock.Object);
            Assert.AreEqual(1, gol.NumberAliveNeighbors(1, 1), "should have 1 neighbor");
        }

        [TestMethod]
        public void NumberAliveNeighborTest_WhenFourRandom_ThenFour()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(board => board.IsAlive(0, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(1, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(0, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 1)).Returns(true);
            boardMock.Setup(board => board.IsAlive(0, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 2)).Returns(true);
            boardMock.Setup(board => board.IsAlive(2, 2)).Returns(false);

            var gol = new GameOfLife(boardMock.Object);
            Assert.AreEqual(4, gol.NumberAliveNeighbors(1, 1), "should have 4 neighbor");
        }

        [TestMethod]
        public void NextGenTest_WhenAliveAnd4Neigh_ThenDead()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(board => board.IsAlive(0, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(1, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(0, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 1)).Returns(true); // it's about this cell
            boardMock.Setup(board => board.IsAlive(2, 1)).Returns(true);
            boardMock.Setup(board => board.IsAlive(0, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 2)).Returns(true);
            boardMock.Setup(board => board.IsAlive(2, 2)).Returns(false);
            boardMock.Setup(board => board.DimX).Returns(3);
            boardMock.Setup(board => board.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.AreEqual(false, gol.IsAlive(1, 1), "should be dead");
        }

        [TestMethod]
        public void NextGenTest_WhenAliveAnd3Neigh_ThenAlive()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(board => board.IsAlive(0, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(0, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 1)).Returns(true); // it's about this cell
            boardMock.Setup(board => board.IsAlive(2, 1)).Returns(true);
            boardMock.Setup(board => board.IsAlive(0, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 2)).Returns(true);
            boardMock.Setup(board => board.IsAlive(2, 2)).Returns(false);
            boardMock.Setup(board => board.DimX).Returns(3);
            boardMock.Setup(board => board.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.AreEqual(true, gol.IsAlive(1, 1), "should be alive");
        }

        [TestMethod]
        public void NextGenTest_WhenAliveAnd2Neigh_ThenAlive()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(board => board.IsAlive(0, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(0, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 1)).Returns(true); // it's about this cell
            boardMock.Setup(board => board.IsAlive(2, 1)).Returns(true);
            boardMock.Setup(board => board.IsAlive(0, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 2)).Returns(true);
            boardMock.Setup(board => board.IsAlive(2, 2)).Returns(false);
            boardMock.Setup(board => board.DimX).Returns(3);
            boardMock.Setup(board => board.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.AreEqual(true, gol.IsAlive(1, 1), "should be alive");
        }

        [TestMethod]
        public void NextGenTest_WhenAliveAnd1Neigh_ThenDead()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(board => board.IsAlive(0, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(0, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 1)).Returns(true); // it's about this cell
            boardMock.Setup(board => board.IsAlive(2, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(0, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 2)).Returns(true);
            boardMock.Setup(board => board.IsAlive(2, 2)).Returns(false);
            boardMock.Setup(board => board.DimX).Returns(3);
            boardMock.Setup(board => board.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.AreEqual(false, gol.IsAlive(1, 1), "should be dead");
        }

        [TestMethod]
        public void NextGenTest_WhenDeadAnd3Neigh_ThenAlive()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(board => board.IsAlive(0, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(1, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(2, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(0, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 1)).Returns(false); // it's about this cell
            boardMock.Setup(board => board.IsAlive(2, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(0, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 2)).Returns(false);
            boardMock.Setup(board => board.DimX).Returns(3);
            boardMock.Setup(board => board.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.AreEqual(true, gol.IsAlive(1, 1), "should be alive");
        }

        [TestMethod]
        public void NextGenTest_WhenDeadAnd2Neigh_ThenDead()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(board => board.IsAlive(0, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(1, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(2, 0)).Returns(false);
            boardMock.Setup(board => board.IsAlive(0, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 1)).Returns(false); // it's about this cell
            boardMock.Setup(board => board.IsAlive(2, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(0, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 2)).Returns(false);
            boardMock.Setup(board => board.DimX).Returns(3);
            boardMock.Setup(board => board.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.AreEqual(false, gol.IsAlive(1, 1), "should be dead");
        }

        [TestMethod]
        public void NextGenTest_WhenDeadAnd4Neigh_ThenDead()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(board => board.IsAlive(0, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(1, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(2, 0)).Returns(true);
            boardMock.Setup(board => board.IsAlive(0, 1)).Returns(true);
            boardMock.Setup(board => board.IsAlive(1, 1)).Returns(false); // it's about this cell
            boardMock.Setup(board => board.IsAlive(2, 1)).Returns(false);
            boardMock.Setup(board => board.IsAlive(0, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(1, 2)).Returns(false);
            boardMock.Setup(board => board.IsAlive(2, 2)).Returns(false);
            boardMock.Setup(board => board.DimX).Returns(3);
            boardMock.Setup(board => board.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.AreEqual(false, gol.IsAlive(1, 1), "should be dead");
        }
    }
}
