using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataGameOfLife;

namespace KataGameOfLifeTest
{
    [TestClass]
    public class GameOfLifeTest
    {
        [TestMethod]
        public void GetNextGen_ReturnBoardHasSameDimension()
        {
            Board startBoard = new Board(2, 3);
            GameOfLife target = new GameOfLife();

            Board nextGen = target.GetNextGen(startBoard);

            Assert.AreEqual(2, nextGen.GetBoardDimX());
            Assert.AreEqual(3, nextGen.GetBoardDimY());
        }

        [TestMethod]
        public void GetNextGen_WhenAllDead_ThenNextGenAllDead()
        {
            Board startBoard = new Board(2, 3);
            GameOfLife target = new GameOfLife();

            Board nextGen = target.GetNextGen(startBoard);
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Assert.AreEqual(false, nextGen.GetAlive(x, y));
                }
            }
        }

        [TestMethod]
        public void GetNextGen_WhenDeadCellHas3Neighbors_ThenCellAlive()
        {
            Board startBoard = new Board(3, 2);
            GameOfLife target = new GameOfLife();

            // .x.  -->  .??  This test only cares about upper left cell
            // xx.       ??? 
            startBoard.SetAlive(0, 0);
            startBoard.SetAlive(1, 0);
            startBoard.SetAlive(1, 1);

            Board nextGen = target.GetNextGen(startBoard);

            Assert.AreEqual(true, nextGen.GetAlive(0, 1));
        }

        [TestMethod]
        public void GetNextGen_WhenDeadCellHas3NeighborsDifferentCell_ThenCellAlive()
        {
            Board startBoard = new Board(5, 4);
            GameOfLife target = new GameOfLife();
            // .....
            // .....
            // .....
            // ...x.  -->  .??  This test only cares about middle cell
            // ..xx.       ??? 
            startBoard.SetAlive(2, 0);
            startBoard.SetAlive(3, 0);
            startBoard.SetAlive(3, 1);

            Board nextGen = target.GetNextGen(startBoard);

            Assert.AreEqual(true, nextGen.GetAlive(2, 1));
        }

        [TestMethod]
        public void GetNextGen_WhenDeadCellHas2Neighbors_ThenCellDead()
        {
            Board startBoard = new Board(3, 2);
            GameOfLife target = new GameOfLife();

            // .x.  -->  .??  This test only cares about upper left cell
            // x..       ??? 
            startBoard.SetAlive(0, 0);
            startBoard.SetAlive(1, 1);

            Board nextGen = target.GetNextGen(startBoard);

            Assert.AreEqual(false, nextGen.GetAlive(0, 1));
        }

        [TestMethod]
        public void GetNextGen_WhenAliveCellHas2Neighbors_ThenCellAlive()
        {
            Board startBoard = new Board(3, 2);
            GameOfLife target = new GameOfLife();

            // xx.  -->  .??  This test only cares about upper left cell
            // x..       ??? 
            startBoard.SetAlive(0, 0);
            startBoard.SetAlive(1, 1);
            startBoard.SetAlive(0, 1);

            Board nextGen = target.GetNextGen(startBoard);

            Assert.AreEqual(true, nextGen.GetAlive(0, 1));
        }

        [TestMethod]
        public void GetNextGen_WhenAliveCellHas3Neighbors_ThenCellAlive()
        {
            Board startBoard = new Board(3, 2);
            GameOfLife target = new GameOfLife();

            // xx.  -->  .??  This test only cares about upper left cell
            // xx.       ??? 
            startBoard.SetAlive(0, 0);
            startBoard.SetAlive(1, 0);
            startBoard.SetAlive(1, 1);
            startBoard.SetAlive(0, 1);

            Board nextGen = target.GetNextGen(startBoard);

            Assert.AreEqual(true, nextGen.GetAlive(0, 1));
        }

        [TestMethod]
        public void GetNextGen_WhenAliveCellHas1Neighbors_ThenCellDead()
        {
            Board startBoard = new Board(3, 2);
            GameOfLife target = new GameOfLife();

            // xx.  -->  .??  This test only cares about upper left cell
            // ...       ??? 
            startBoard.SetAlive(1, 1);
            startBoard.SetAlive(0, 1);

            Board nextGen = target.GetNextGen(startBoard);

            Assert.AreEqual(false, nextGen.GetAlive(0, 1));
        }

        [TestMethod]
        public void GetNextGen_WhenDeadCellHas1Neighbors_ThenCellDead()
        {
            Board startBoard = new Board(3, 2);
            GameOfLife target = new GameOfLife();

            // .x.  -->  .??  This test only cares about upper left cell
            // ...       ??? 
            startBoard.SetAlive(1, 1);

            Board nextGen = target.GetNextGen(startBoard);

            Assert.AreEqual(false, nextGen.GetAlive(0, 1));
        }

        [TestMethod]
        public void GetNextGen_WhenDeadCellHas4Neighbors_ThenCellDead()
        {
            Board startBoard = new Board(3, 2);
            GameOfLife target = new GameOfLife();

            // x..  -->  ?.?  This test only cares about middle upper cell
            // xxx       ??? 
            startBoard.SetAlive(0, 0);
            startBoard.SetAlive(1, 0);
            startBoard.SetAlive(2, 0);
            startBoard.SetAlive(0, 1);

            Board nextGen = target.GetNextGen(startBoard);

            Assert.AreEqual(false, nextGen.GetAlive(1, 1));
        }

        [TestMethod]
        public void GetNextGen_WhenAliveCellHas4Neighbors_ThenCellDead()
        {
            Board startBoard = new Board(3, 2);
            GameOfLife target = new GameOfLife();

            // xx.  -->  ?.?  This test only cares about middle upper cell
            // xxx       ??? 
            startBoard.SetAlive(0, 0);
            startBoard.SetAlive(1, 0);
            startBoard.SetAlive(2, 0);
            startBoard.SetAlive(0, 1);
            startBoard.SetAlive(1, 1);

            Board nextGen = target.GetNextGen(startBoard);

            Assert.AreEqual(false, nextGen.GetAlive(1, 1));
        }



    }
}
