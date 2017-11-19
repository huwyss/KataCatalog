using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using gameoflife2;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SizeTest()
        {
            var grid = new Grid(3, 4);

            Assert.AreEqual(3, grid.SizeX());
            Assert.AreEqual(4, grid.SizeY());
        }

        [TestMethod]
        public void SetAliveTest_WhenAlive_ThenGetAlive()
        {
            var grid = new Grid(3, 4);

            grid.SetAlive(0, 0);

            Assert.AreEqual(typeof(CellAlive), grid.GetCell(0,0).GetType());
        }
        [TestMethod]
        public void SetAliveTest_WhenDead_ThenNotGetAlive()
        {
            var grid = new Grid(3, 4);

            Assert.AreEqual(typeof(CellDead), grid.GetCell(1, 1).GetType());
        }

        [TestMethod]
        public void GetNeighborhoud_LonelyCells_ThenLonelyNeighborhoud()
        {
            var grid = new Grid(3, 4);

            grid.SetAlive(0, 0);

            Assert.AreEqual(typeof(NeighborhoudLonely, grid.GetNeighborhoud(1, 1).GetType());
        }

    }
}
