using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;

namespace TicTacToeTest
{
    [TestClass]
    public class PieceManagerTest
    {
        [TestMethod]
        public void PlayerTest_WhenHumanStarts_ThenHumanHasXAndComputerHasO()
        {
            var target = new PieceManager();
            target.FirstMover = PlayerType.Human;
            Piece actualPieceHuman = target.GetPiece(PlayerType.Human);
            Assert.AreEqual(Piece.X, actualPieceHuman);
            Piece actualPieceComputer = target.GetPiece(PlayerType.Computer);
            Assert.AreEqual(Piece.O, actualPieceComputer);
        }

        [TestMethod]
        public void PlayerTest_WhenComputerStarts_ThenComputerHasXAndHumanHasO()
        {
            var target = new PieceManager();
            target.FirstMover = PlayerType.Computer;
            Piece actualPieceHuman = target.GetPiece(PlayerType.Human);
            Assert.AreEqual(Piece.O, actualPieceHuman);
            Piece actualPieceComputer = target.GetPiece(PlayerType.Computer);
            Assert.AreEqual(Piece.X, actualPieceComputer);
        }
    }
}
