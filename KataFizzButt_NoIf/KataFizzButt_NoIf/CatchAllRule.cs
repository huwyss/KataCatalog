using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public class CatchAllRule : IRule
    {
        public bool DoesApply(int number)
        {
            return true;
        }

        public string Apply(int number)
        {
            return number.ToString();
        }
    }
}
