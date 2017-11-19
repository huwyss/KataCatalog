using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeObjects
    {
        public InputReader InputReader { get; set; }
        public BoardState BoardState { get; set; }
        public HumanPlayer HumanPlayer { get; set; }
        public ComputerPlayer ComputerPlayer { get; set; }
        public PieceManager PieceManager { get; set; }
    }
}
