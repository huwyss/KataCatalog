using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;
using System.Collections.Generic;

namespace TicTacToeTest
{
    [TestClass]
    public class HumanPlayerTest
    {
        [TestMethod]
        public void WhenUserEntersexit_ThenGameIsFinished()
        {
            HumanPlayer userMove = new HumanPlayer(null);
            userMove.Input = "exit";
            Assert.AreEqual(true, userMove.IsFinished());
        }

        [TestMethod]
        public void WhenUserEntersExit_ThenGameIsFinished()
        {
            HumanPlayer userMove = new HumanPlayer(null);
            userMove.Input = "Exit";
            Assert.AreEqual(true, userMove.IsFinished());
        }

        [TestMethod]
        public void WhenUserEntersInvalidMove_ThenMoveIsSetToInvalid()
        {
            HumanPlayer userMove = new HumanPlayer(null);
            userMove.Input = "h3";
            Assert.AreEqual(false, userMove.IsInputValid());
        }

        [TestMethod]
        public void WhenUserEntersValidMove_ThenMoveIsSetValid()
        {
            HumanPlayer userMove = new HumanPlayer(null);
            userMove.Input = "a2";
            Assert.AreEqual(true, userMove.IsInputValid());
        }

        [TestMethod]
        public void WhenUserEntersValidMoveCapitalLetter_ThenMoveIsSetValid()
        {
            HumanPlayer userMove = new HumanPlayer(null);
            userMove.Input = "B2";
            Assert.AreEqual(true, userMove.IsInputValid());
        }

        [TestMethod]
        public void WhenUserEntersValidMove_ThenMoveIsSetCoordinates_a1_is_00()
        {
            HumanPlayer userMove = new HumanPlayer(null);
            userMove.Input = "a2";
            Assert.AreEqual(1, userMove.MoveCoordinatesX); // 2-->1
            Assert.AreEqual(0, userMove.MoveCoordinatesY); // a-->0
        }

        [TestMethod]
        public void DoMoveTest_WhenExitIsEntered_ThenConstEXITIsReturned()
        {
            var reader = new InputReaderFake();
            reader.SetUserInput("exit");
            var target = new HumanPlayer(reader);
            int retValue = target.DoMove(Piece.X, null);
            Assert.AreEqual(-100, retValue);
        }

        [TestMethod]
        public void DoMoveTest_WhenAnIllegalMoveIsEntered_ThenUserMustEnterALegalMove()
        {
            var reader = new InputReaderFake();
            reader.SetUserInput("a2");
            reader.SetUserInput("a2");
            reader.SetUserInput("a1");
            var target = new HumanPlayer(reader);
            var boardState = new BoardState(null);
            var board = new Piece[3, 3];
            board[0, 0] = Piece.Empty; board[1, 0] = Piece.X; board[2, 0] = Piece.Empty;
            board[0, 1] = Piece.Empty; board[1, 1] = Piece.Empty; board[2, 1] = Piece.Empty;
            board[0, 2] = Piece.Empty; board[1, 2] = Piece.Empty; board[2, 2] = Piece.Empty;
            boardState.Board = board;

            int retValue = target.DoMove(Piece.O, boardState);
            Assert.AreEqual(0, retValue);
            Assert.AreEqual(Piece.O, boardState.GetPiece(0, 0));
        }
    }

    public class InputReaderFake : IInputReader
    {
        private List<string> _userInput = new List<string>();

        public void SetUserInput(string value)
        {
            _userInput.Add(value);
        }
        public string GetUserInput()
        {
            string retValue = _userInput[0];
            _userInput.RemoveAt(0);
            return retValue;
        }
    }
}
