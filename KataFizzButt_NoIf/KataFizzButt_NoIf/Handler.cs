using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public abstract class Handler : IRule
    {
        Handler _nextHandler;

        public void SetNextHandler(Handler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public string HandleRequest(int number)
        {
            return DoesApply(number) ? Apply(number) : _nextHandler.HandleRequest(number);
        }

        // IRules interface
        public abstract string Apply(int number);
        public abstract bool DoesApply(int number);
    }
}
