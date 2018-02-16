using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public class CatchAllHandler : Handler, IRule
    {
        public override bool DoesApply(int number)
        {
            return true;
        }

        public override string Apply(int number)
        {
            return number.ToString();
        }
    }
}
