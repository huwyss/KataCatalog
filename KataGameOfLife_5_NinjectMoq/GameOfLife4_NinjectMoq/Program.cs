using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KataGameOfLife
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IKernel kernel = new StandardKernel();
            kernel.Bind<IBoard>().To<Board>().InSingletonScope();
            var form1 = kernel.Get<Form1>();

            //Board board = new Board();
            //GameOfLife gol = new GameOfLife(board);
            //var form1 = new Form1(gol);

            Application.Run(form1);
        }
    }
}
