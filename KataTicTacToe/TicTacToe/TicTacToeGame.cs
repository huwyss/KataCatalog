using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        InputReader _inputReader;
        BoardState _boardState;
        HumanPlayer _humanPlayer;
        ComputerPlayer _computerPlayer;
        OutputWriter _outputWriter;
        PieceManager _pieceManager;

        public TicTacToeGame(TicTacToeObjects ticTacToeObjects)
        {
            _inputReader = ticTacToeObjects.InputReader;
            _boardState = ticTacToeObjects.BoardState;
            _humanPlayer = ticTacToeObjects.HumanPlayer;
            _computerPlayer = ticTacToeObjects.ComputerPlayer;
            _pieceManager = ticTacToeObjects.PieceManager;
        }

        public void RunGame()
        {
            bool exited = false;
            _boardState.Reset();
            _pieceManager.FirstMover = _pieceManager.GetRandomPlayerType();

            if (_pieceManager.FirstMover == PlayerType.Computer)
            {
                _computerPlayer.DoMove(_pieceManager.GetPiece(PlayerType.Computer), _boardState);
            }

            _boardState.PrintBoard();

            while (!_boardState.IsFinished())
            {
                exited = _humanPlayer.DoMove(_pieceManager.GetPiece(PlayerType.Human), _boardState) == -100;
                if (exited)
                {
                    break;
                }

                _computerPlayer.DoMove(_pieceManager.GetPiece(PlayerType.Computer), _boardState);
                _boardState.PrintBoard();
            }

            if (!exited)
            {
                _boardState.PrintWinner();
            }
        }
    }
}
