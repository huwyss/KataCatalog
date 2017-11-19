using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public class FizzRule : IRule
    {
        public bool DoesApply(int number)
        {
            return number % 3 == 0;
        }

        public string Apply(int number)
        {
            return "fizz";
        }
    }
}
