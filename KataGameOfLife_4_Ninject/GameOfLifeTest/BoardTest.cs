using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataGameOfLife2;

namespace GameOfLifeTest
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void CtorTest_WhenNoLineFeedAtEnd_ThenCorrect()
        {
            string fields = "..#..\n" +
                            ".....\n" +
                            "###..";
            Board board = new Board();
            board.LoadBoard(fields);
            Assert.AreEqual(3, board.DimY);
            Assert.AreEqual(5, board.DimX);
        }

        [TestMethod]
        public void CtorTest_WhenStringHasLineFeedAtEnd_ThenCorrect()
        {
            string fields = "..#..\n" +
                            ".....\n" +
                            "###..\n";
            Board board = new Board();
            board.LoadBoard(fields);
            Assert.AreEqual(3, board.DimY);
            Assert.AreEqual(5, board.DimX);
        }

        [TestMethod]
        public void CtorTest_WhenStringGiVen_ThenFieldsCorrectlLoaded()
        {
            string fields = "..#..\n" +
                            ".....\n" +
                            "###..\n";
            Board board = new Board();
            board.LoadBoard(fields);
            Assert.AreEqual(false, board.IsAlive(0, 0));  // line 1
            Assert.AreEqual(false, board.IsAlive(1, 0));
            Assert.AreEqual(true, board.IsAlive(2, 0));
            Assert.AreEqual(false, board.IsAlive(3, 0));
            Assert.AreEqual(false, board.IsAlive(4, 0));
            Assert.AreEqual(false, board.IsAlive(0, 1));  // line 2
            Assert.AreEqual(false, board.IsAlive(1, 1));
            Assert.AreEqual(false, board.IsAlive(2, 1));
            Assert.AreEqual(false, board.IsAlive(3, 1));
            Assert.AreEqual(false, board.IsAlive(4, 1));
            Assert.AreEqual(true, board.IsAlive(0, 2));  // line 3
            Assert.AreEqual(true, board.IsAlive(1, 2));
            Assert.AreEqual(true, board.IsAlive(2, 2));
            Assert.AreEqual(false, board.IsAlive(3, 2));
            Assert.AreEqual(false, board.IsAlive(4, 2));
        }

        [TestMethod]
        public void PrintTest_WhenPrintBoard_ThenCorrect()
        {
            string fields = "..#..\n" +
                            ".....\n" +
                            "###..\n";
            Board board = new Board();
            board.LoadBoard(fields);
            Assert.AreEqual(fields, board.Print());
        }

        [TestMethod]
        public void CTorTest2()
        {
            Board board = new Board();
            board.SetBoardDim(2, 3);
            Assert.AreEqual(2, board.DimX);
            Assert.AreEqual(3, board.DimY);
        }

        [TestMethod]
        public void GetSetAliveTest()
        {
            Board board = new Board();
            board.SetBoardDim(2, 3);
            Assert.AreEqual(false, board.IsAlive(0, 0));

            board.SetAlive(0, 0, true);
            Assert.AreEqual(true, board.IsAlive(0, 0));
        }

        [TestMethod]
        public void SetAliveTest_WhenOutOfBoard_ThenNoCrash()
        {
            Board board = new Board();
            board.SetBoardDim(2, 3);
            board.SetAlive(-1, 0, true);
            board.SetAlive(2, 0, true);
            board.SetAlive(0, -1, true);
            board.SetAlive(0, 3, true);
        }

        [TestMethod]
        public void IAliveTest_WhenOutOfBoard_ThenFalse()
        {
            Board board = new Board();
            board.SetBoardDim(2, 3);
            Assert.IsFalse(board.IsAlive(-1, 0));
        }

    }
}
