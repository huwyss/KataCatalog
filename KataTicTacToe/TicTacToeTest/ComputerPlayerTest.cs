using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;
using System.Collections.Generic;

namespace TicTacToeTest
{
    [TestClass]
    public class ComputerPlayerTest
    {
        [TestMethod]
        public void WhenAllButOnePositionsAreFull_ThenDoMoveUsesLastPosition()
        {
            ComputerPlayer target = new ComputerPlayer();
            var board = new Piece[3, 3];
            board[0, 0] = Piece.O; board[1, 0] = Piece.X; board[2, 0] = Piece.O;
            board[0, 1] = Piece.O; board[1, 1] = Piece.O; board[2, 1] = Piece.X;
            board[0, 2] = Piece.X; board[1, 2] = Piece.X; board[2, 2] = Piece.Empty;
            var boardState = new BoardState(null);
            boardState.Board = board;
            target.DoMove(Piece.O, boardState);
            Assert.AreEqual(Piece.O, boardState.Board[2, 2]);
        }

        [TestMethod]
        public void WhenFirstPlayerStartsInCorner_ThenDoMoveMustPutPieceInCenter()
        {
            ComputerPlayer target = new ComputerPlayer();
            var board = new Piece[3, 3];
            board[0, 0] = Piece.X; board[1, 0] = Piece.Empty; board[2, 0] = Piece.Empty;
            board[0, 1] = Piece.Empty; board[1, 1] = Piece.Empty; board[2, 1] = Piece.Empty;
            board[0, 2] = Piece.Empty; board[1, 2] = Piece.Empty; board[2, 2] = Piece.Empty;
            var boardState = new BoardState(null);
            boardState.Board = board;
            target.DoMove(Piece.O, boardState);
            Assert.AreEqual(Piece.O, boardState.Board[1, 1]);
        }

        [TestMethod]
        public void WhenComputerPlayerHasPossibilityToWinInNextMove_ThenDoMoveMustMustSelectWinningMove()
        {
            ComputerPlayer target = new ComputerPlayer();
            var board = new Piece[3, 3];
            board[0, 0] = Piece.X; board[1, 0] = Piece.O; board[2, 0] = Piece.X;
            board[0, 1] = Piece.X; board[1, 1] = Piece.O; board[2, 1] = Piece.Empty;
            board[0, 2] = Piece.Empty; board[1, 2] = Piece.Empty; board[2, 2] = Piece.Empty;
            var boardState = new BoardState(null);
            boardState.Board = board;
            target.DoMove(Piece.O, boardState);
            Assert.AreEqual(Piece.O, boardState.Board[1, 2]);
        }

        [TestMethod]
        public void GetEmptyFieldsTest_WhenTwoFieldsAreEmpty_ThenReturnThoseEmptyFields()
        {
            ComputerPlayer target = new ComputerPlayer();
            var board = new Piece[3, 3];
            board[0, 0] = Piece.O; board[1, 0] = Piece.X; board[2, 0] = Piece.O;
            board[0, 1] = Piece.O; board[1, 1] = Piece.O; board[2, 1] = Piece.Empty;
            board[0, 2] = Piece.X; board[1, 2] = Piece.X; board[2, 2] = Piece.Empty;
            var boardState = new BoardState(null);
            boardState.Board = board;
            List<Position> emptyFields = target.GetEmptyFields(boardState);
            List<Position> expectedEmptys = new List<Position>()
            { 
                new Position {X = 2, Y = 1}, 
                new Position {X = 2, Y = 2}
            };
            Assert.AreEqual(emptyFields.Count == expectedEmptys.Count, true);
            int i = 0;
            foreach (var position in expectedEmptys)
            {
                Assert.AreEqual(true, position.IsEqual(emptyFields[i]));
                i++;
            }
        }
    }
}
