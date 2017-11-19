using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;


namespace TicTacToeTest
{
    [TestClass]
    public class BoardStateTest
    {
        [TestMethod]
        public void WhenSettingXIntoField_ThenThatFieldIsOccupiedByX()
        {
            BoardState target = new BoardState(null);
            target.SetPiece(0, 0, Piece.X);
            Assert.AreEqual(Piece.X, target.Board[0, 0]);
        }

        [TestMethod]
        public void WhenSettingYIntoField_ThenThatFieldIsOccupiedByY()
        {
            BoardState target = new BoardState(null);
            target.SetPiece(1, 2, Piece.O);
            Assert.AreEqual(Piece.O, target.Board[1, 2]);
        }

        [TestMethod]
        public void WhenResettingTheBoard_ThenTheFieldsAreEmpty()
        {
            BoardState target = new BoardState(null);
            target.Board[1, 2] = Piece.X;
            target.Reset();
            Assert.AreEqual(Piece.Empty, target.GetPiece(1, 2));
        }

        [TestMethod]
        public void GetPieceTest_WhenFieldIsX_ThenGetPieceReturnsX()
        {
            BoardState target = new BoardState(null);
            var board = new Piece[3, 3];
            board[0, 0] = Piece.Empty; board[1, 0] = Piece.X;     board[2, 0] = Piece.Empty;
            board[0, 1] = Piece.Empty; board[1, 1] = Piece.Empty; board[2, 1] = Piece.Empty;
            board[0, 2] = Piece.Empty; board[1, 2] = Piece.Empty; board[2, 2] = Piece.Empty;
            target.Board = board;

            Piece actualPiece = target.GetPiece(1, 0);
            Assert.AreEqual(Piece.X, actualPiece);
        }

        [TestMethod]
        public void WhenXHas3XInRow_ThenXWins()
        {
            BoardState target = new BoardState(null);
            target.SetPiece(0, 1, Piece.X);
            target.SetPiece(1, 1, Piece.X);
            target.SetPiece(2, 1, Piece.X);
            bool isXWinner = target.IsWinner(Piece.X);
            Assert.AreEqual(true, isXWinner);
        }

        [TestMethod]
        public void WhenXHasNot3XInRow_ThenXDoesNotWin()
        {
            BoardState target = new BoardState(null);
            target.SetPiece(0, 0, Piece.X);
            target.SetPiece(1, 1, Piece.X);
            target.SetPiece(2, 1, Piece.X);
            bool isXWinner = target.IsWinner(Piece.X);
            Assert.AreEqual(false, isXWinner);
        }

        [TestMethod]
        public void WhenHas3OInRow_ThenOWins()
        {
            BoardState target = new BoardState(null);
            var board = new Piece[3, 3];
            board[0, 0] = Piece.O; board[1, 0] = Piece.Empty; board[2, 0] = Piece.X;
            board[0, 1] = Piece.X; board[1, 1] = Piece.O;     board[2, 1] = Piece.Empty;
            board[0, 2] = Piece.X; board[1, 2] = Piece.Empty; board[2, 2] = Piece.O;
            target.Board = board;
            bool isXWinner = target.IsWinner(Piece.O);
            Assert.AreEqual(true, isXWinner);
        }

        [TestMethod]
        public void WhenAllPositionAreFullAndNoneWins_ThenGameIsDraw()
        {
            BoardState target = new BoardState(null);
            var board = new Piece[3, 3];
            board[0, 0] = Piece.O; board[1, 0] = Piece.X; board[2, 0] = Piece.O;
            board[0, 1] = Piece.O; board[1, 1] = Piece.X; board[2, 1] = Piece.X;
            board[0, 2] = Piece.X; board[1, 2] = Piece.O; board[2, 2] = Piece.O;
            target.Board = board;
            bool isDraw = target.IsDraw();
            Assert.AreEqual(true, isDraw);
        }

        [TestMethod]
        public void WhenNotAllPositionsFull_ThenGameIsNotDraw()
        {
            BoardState target = new BoardState(null);
            var board = new Piece[3, 3];
            board[0, 0] = Piece.O; board[1, 0] = Piece.X; board[2, 0] = Piece.O;
            board[0, 1] = Piece.X; board[1, 1] = Piece.X; board[2, 1] = Piece.X;
            board[0, 2] = Piece.X; board[1, 2] = Piece.Empty; board[2, 2] = Piece.X;
            target.Board = board;
            bool isDraw = target.IsDraw();
            Assert.AreEqual(false, isDraw);
        }

        [TestMethod]
        public void WhenAllPositionAreFullAndXWins_ThenGameIsNotDraw()
        {
            BoardState target = new BoardState(null);
            var board = new Piece[3, 3];
            board[0, 0] = Piece.O; board[1, 0] = Piece.X; board[2, 0] = Piece.O;
            board[0, 1] = Piece.O; board[1, 1] = Piece.X; board[2, 1] = Piece.X;
            board[0, 2] = Piece.X; board[1, 2] = Piece.X; board[2, 2] = Piece.O;
            target.Board = board;

            bool isDraw = target.IsDraw();
            Assert.AreEqual(false, isDraw);
        }

        

        [TestMethod]
        public void CloneTest_WhenCloning_ThenReturnsCopy()
        {
            BoardState target = new BoardState(null);
            target.SetPiece(0, 0, Piece.X);
            var copiedBoard = target.Clone();
            Assert.AreEqual(copiedBoard.GetPiece(0, 0), Piece.X);
        }

        [TestMethod]
        public void CloneTest_WhenCloning_ThenReturnsCopyButDifferentInstance()
        {
            BoardState target = new BoardState(null);
            target.SetPiece(0, 0, Piece.X);
            var copiedBoard = target.Clone();
            Assert.AreEqual(copiedBoard.GetPiece(0, 0), Piece.X);
            
            target.SetPiece(0, 1, Piece.X);
            Assert.AreEqual(target.GetPiece(0, 1), Piece.X);
            Assert.AreEqual(copiedBoard.GetPiece(0, 1), Piece.Empty);
        }
    }
}
