using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public class FizzBuzzRule : IRule
    {
        public bool DoesApply(int number)
        {
            return number % 15 == 0;
        }

        public string Apply(int number)
        {
            return "fizzbuzz";
        }
    }
}
