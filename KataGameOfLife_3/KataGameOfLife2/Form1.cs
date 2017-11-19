using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KataGameOfLife2
{
    public partial class Form1 : Form
    {
        GameOfLife _gol;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _gol.NextGen();
            Print();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string fields =
                "...........\n" +
                 "...........\n" +
                 "...........\n" +
                 ".....#.....\n" +
                 "....###....\n" +
                 "...#####...\n" +
                 "...........\n" +
                 "...........\n" +
                 "...........\n" +
                 "...........\n" +
                 "...........\n" +
                 "...........\n" +
                 "...#####...\n" +
                 "....###....\n" +
                 ".....#.....\n" +
                 "...........\n" +
                 "...........\n" +
                 "...........\n";
            _gol = new GameOfLife(new Board(fields));
            Print();
            timer1.Start();
        }

        private void Print()
        {
            lblGameOfLife.Text = _gol.Print();
        }
    }
}
