using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataGameOfLife2;

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
            Board board = new Board(fields);
            GameOfLife gol = new GameOfLife(board);
            Assert.AreEqual(fields, gol.Print());
        }

        [TestMethod]
        public void NumberAliveNeighborTest1()
        {
            string fields = "..##.\n" +
                            ".....\n" +
                            "###..\n";
            Board board = new Board(fields);
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
            Board board = new Board(fields);
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
            Board board = new Board(fields);
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
            Board board = new Board(fields);
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
            Board board = new Board(fields);
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
            Board board = new Board(fields);
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
            Board board = new Board(fields);
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
            Board board = new Board(fields);
            GameOfLife gol = new GameOfLife(board);
            gol.NextGen();
            Assert.IsFalse(gol.IsAlive(1, 1));
        }
    }
}
