using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KataGameOfLife2
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

            Application.Run(form1);
        }
    }
}
