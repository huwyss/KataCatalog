using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public class FizzBuzzer
    {
        private readonly RulesSet _rulesSet;

        public FizzBuzzer()
        {
            _rulesSet = new RulesSet();
            _rulesSet.AddRule(new CatchAllRule());
            _rulesSet.AddRule(new FizzRule());
            _rulesSet.AddRule(new BuzzRule());
            _rulesSet.AddRule(new FizzBuzzRule());
        }

        public string Evaluate(int number)
        {
            string result = _rulesSet.ApplyRules(number);
            return result;
        }
    }
}
