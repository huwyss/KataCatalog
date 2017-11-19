using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public class FizzBuzzer
    {
        RulesSet _rulesSet;

        public FizzBuzzer()
        {
            _rulesSet = new RulesSet();
        }

        public string Evaluate(int number)
        {
            string result = _rulesSet.ApplyRules(number);
            return result;
        }
    }
}
