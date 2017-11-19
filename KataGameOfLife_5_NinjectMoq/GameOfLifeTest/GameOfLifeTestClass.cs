using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataGameOfLife;
using Moq;

namespace GameOfLifeTest
{
    [TestClass]
    public class GameOfLifeTest
    {
        // current cell is alive

        [TestMethod]
        public void NextGenTest_WhenAliveAnd4Neighbors_ThenDead()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(g => g.NumberAliveNeighbors(1, 1)).Returns(4);
            boardMock.Setup(g => g.IsAlive(1, 1)).Returns(true);
            boardMock.Setup(g => g.DimX).Returns(3);
            boardMock.Setup(g => g.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.IsFalse(gol.IsAlive(1, 1));
        }

        [TestMethod]
        public void NextGenTest_WhenAliveAnd3Neighbors_ThenAlive()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(g => g.NumberAliveNeighbors(1, 1)).Returns(3);
            boardMock.Setup(g => g.IsAlive(1, 1)).Returns(true);
            boardMock.Setup(g => g.DimX).Returns(3);
            boardMock.Setup(g => g.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.IsTrue(gol.IsAlive(1, 1));
        }

        [TestMethod]
        public void NextGenTest_WhenAliveAnd2Neighbors_ThenAlive()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(g => g.NumberAliveNeighbors(1, 1)).Returns(2);
            boardMock.Setup(g => g.IsAlive(1, 1)).Returns(true);
            boardMock.Setup(g => g.DimX).Returns(3);
            boardMock.Setup(g => g.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.IsTrue(gol.IsAlive(1, 1));
        }

        [TestMethod]
        public void NextGenTest_WhenAliveAnd1Neighbors_ThenDead()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(g => g.NumberAliveNeighbors(1, 1)).Returns(1);
            boardMock.Setup(g => g.IsAlive(1, 1)).Returns(true);
            boardMock.Setup(g => g.DimX).Returns(3);
            boardMock.Setup(g => g.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.IsFalse(gol.IsAlive(1, 1));
        }

        // current cell is dead

        [TestMethod]
        public void NextGenTest_WhenDeadAnd2Neighbors_ThenDead()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(g => g.NumberAliveNeighbors(1, 1)).Returns(2);
            boardMock.Setup(g => g.IsAlive(1, 1)).Returns(false);
            boardMock.Setup(g => g.DimX).Returns(3);
            boardMock.Setup(g => g.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.IsFalse(gol.IsAlive(1, 1));
        }

        [TestMethod]
        public void NextGenTest_WhenDeadAnd3Neighbors_ThenAlive()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(g => g.NumberAliveNeighbors(1, 1)).Returns(3);
            boardMock.Setup(g => g.IsAlive(1, 1)).Returns(false);
            boardMock.Setup(g => g.DimX).Returns(3);
            boardMock.Setup(g => g.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.IsTrue(gol.IsAlive(1, 1));
        }

        [TestMethod]
        public void NextGenTest_WhenDeadAnd4Neighbors_ThenDead()
        {
            var boardMock = new Mock<IBoard>();
            boardMock.Setup(g => g.NumberAliveNeighbors(1, 1)).Returns(4);
            boardMock.Setup(g => g.IsAlive(1, 1)).Returns(false);
            boardMock.Setup(g => g.DimX).Returns(3);
            boardMock.Setup(g => g.DimY).Returns(3);

            var gol = new GameOfLife(boardMock.Object);
            gol.NextGen();
            Assert.IsFalse(gol.IsAlive(1, 1));
        }
    }
}
