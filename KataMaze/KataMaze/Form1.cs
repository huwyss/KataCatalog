using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KataMaze
{
    public partial class Form1 : Form
    {
        Maze _maze;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sizeX = (int)numX.Value;
            int sizeY = (int)numY.Value;
            MazeGenerator mazeGenerator = new MazeGenerator(sizeX, sizeY);
            _maze = mazeGenerator.Create();
            label1.Text = _maze.ToString();
        }

        private void btnFindPath_Click(object sender, EventArgs e)
        {
            MazeSolver solver = new MazeSolver(_maze);
            solver.MarkPath(0, (int)numY.Value - 1, (int)numX.Value - 1, 0);
            label1.Text = _maze.ToString();

        }
    }
}
