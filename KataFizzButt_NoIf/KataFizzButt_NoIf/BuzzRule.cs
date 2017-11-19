using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public class BuzzRule : IRule
    {
        public bool DoesApply(int number)
        {
            return number % 5 == 0;
        }

        public string Apply(int number)
        {
            return "buzz";
        }
    }
}
