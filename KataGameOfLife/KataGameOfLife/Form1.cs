using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KataGameOfLife
{
    public partial class Form1 : Form
    {
        Board _currentBoard;
        GameOfLife _gameOL;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 500;
            _currentBoard = new Board(0, 0);
            _gameOL = new GameOfLife();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // .....
            // .....
            // .xxx.
            // .....
            // .....

            timer1.Stop();

            _currentBoard = new Board(5, 5);
            _currentBoard.SetAlive(1, 2);
            _currentBoard.SetAlive(2, 2);
            _currentBoard.SetAlive(3, 2);
            PrintBoard();

            timer1.Start();            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _currentBoard = _gameOL.GetNextGen(_currentBoard);
            PrintBoard();
        }

        private void PrintBoard()
        {
            string buffer = "";
            for (int y = _currentBoard.GetBoardDimY() - 1; y >= 0; y--)
            {
                for (int x = 0; x < _currentBoard.GetBoardDimX(); x++)
                {
                    buffer += _currentBoard.GetAlive(x, y) ? "X" : ".";
                }

                buffer += "\n";
            }

            label1.Text = buffer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ..............
            // ..x...........
            // ...x..........
            // .xxx..........
            // ..............
            // ..............
            // ..............

            timer1.Stop();

            _currentBoard = new Board(10, 10);
            _currentBoard.SetAlive(1, 6);
            _currentBoard.SetAlive(2, 6);
            _currentBoard.SetAlive(3, 6);
            _currentBoard.SetAlive(3, 7);
            _currentBoard.SetAlive(2, 8);
            PrintBoard();

            timer1.Start();
       }

        private void button3_Click(object sender, EventArgs e)
        {
            // ...........
            // ...........
            // ...........
            // .....x.....
            // ....xxx....
            // ...xxxxx...
            // ...........
            // ...........
            // ...........
            // ...........
            // ...........
            // ...........
            // ...xxxxx...
            // ....xxx....
            // .....x.....
            // ...........
            // ...........
            // ...........

            timer1.Stop();

            _currentBoard = new Board(11, 18);
            _currentBoard.SetAlive(5, 3);
            _currentBoard.SetAlive(4, 4);
            _currentBoard.SetAlive(5, 4);
            _currentBoard.SetAlive(6, 4);
            _currentBoard.SetAlive(3, 5);
            _currentBoard.SetAlive(4, 5);
            _currentBoard.SetAlive(5, 5);
            _currentBoard.SetAlive(6, 5);
            _currentBoard.SetAlive(7, 5);

            _currentBoard.SetAlive(5, 14);
            _currentBoard.SetAlive(4, 13);
            _currentBoard.SetAlive(5, 13);
            _currentBoard.SetAlive(6, 13);
            _currentBoard.SetAlive(3, 12);
            _currentBoard.SetAlive(4, 12);
            _currentBoard.SetAlive(5, 12);
            _currentBoard.SetAlive(6, 12);
            _currentBoard.SetAlive(7, 12);

            PrintBoard();

            timer1.Start();
        }
    }
}
