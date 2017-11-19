using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataMaze;

namespace KataMazeTest
{
    [TestClass]
    public class MazeHelperTest
    {
        [TestMethod]
        public void GetRandomDirection()
        {
            Maze target = new Maze(2, 2);
            MazeHelper.ResetRandomDirection();

            Direction dir1 = MazeHelper.GetRandomDirection();
            Direction dir2 = MazeHelper.GetRandomDirection();
            Direction dir3 = MazeHelper.GetRandomDirection();
            Direction dir4 = MazeHelper.GetRandomDirection();

            Assert.IsTrue(dir1 != dir2 && dir1 != dir3 && dir1 != dir4);
            Assert.IsTrue(dir2 != dir3 && dir2 != dir4);
            Assert.IsTrue(dir3 != dir4);
        }

        [TestMethod]
        public void GetRightestDirectionTest_WhenStartingUp_ThenRightUpLeftDown()
        {
            MazeHelper.ResetRightestDirection(Direction.up);
            Direction rightest = MazeHelper.GetNextRightestDirection();
            Assert.AreEqual(Direction.right, rightest);

            rightest = MazeHelper.GetNextRightestDirection();
            Assert.AreEqual(Direction.up, rightest);

            rightest = MazeHelper.GetNextRightestDirection();
            Assert.AreEqual(Direction.left, rightest);

            rightest = MazeHelper.GetNextRightestDirection();
            Assert.AreEqual(Direction.down, rightest);
        }

        [TestMethod]
        public void GetRightestDirectionTest_WhenStartingRight_ThenDownRightUpLeft()
        {
            MazeHelper.ResetRightestDirection(Direction.right);
            Direction rightest = MazeHelper.GetNextRightestDirection();
            Assert.AreEqual(Direction.down, rightest);

            rightest = MazeHelper.GetNextRightestDirection();
            Assert.AreEqual(Direction.right, rightest);

            rightest = MazeHelper.GetNextRightestDirection();
            Assert.AreEqual(Direction.up, rightest);

            rightest = MazeHelper.GetNextRightestDirection();
            Assert.AreEqual(Direction.left, rightest);
        }

        [TestMethod]
        public void GetRightestDirectionTest_WhenStartingDown_ThenLeftDownRightUp()
        {
            MazeHelper.ResetRightestDirection(Direction.down);
            Direction rightest = MazeHelper.GetNextRightestDirection();
            Assert.AreEqual(Direction.left, rightest);

            rightest = MazeHelper.GetNextRightestDirection();
            Assert.AreEqual(Direction.down, rightest);

            rightest = MazeHelper.GetNextRightestDirection();
            Assert.AreEqual(Direction.right, rightest);

            rightest = MazeHelper.GetNextRightestDirection();
            Assert.AreEqual(Direction.up, rightest);
        }
    }
}
