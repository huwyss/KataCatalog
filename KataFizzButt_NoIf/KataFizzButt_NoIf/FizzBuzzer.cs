using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public class FizzBuzzer
    {
        private Handler firstHandler = null;

        public FizzBuzzer()
        {
            AddHandler(new CatchAllHandler());
            AddHandler(new BuzzHandler());
            AddHandler(new FizzHandler());
            AddHandler(new FizzBuzzHandler());
        }

        private void AddHandler(Handler previousHandler)
        {
            previousHandler.SetNextHandler(firstHandler);
            firstHandler = previousHandler;
        }

        public string Evaluate(int number)
        {
            return firstHandler.HandleRequest(number);
        }
    }
}
