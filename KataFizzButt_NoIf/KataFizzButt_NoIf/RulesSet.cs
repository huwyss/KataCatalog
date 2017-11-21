using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public class RulesSet
    {
        private ChainElement _firstRule = null;

        public string ApplyRules(int number)
        {
            string result = _firstRule.Handle(number);
            return result;
        }

        public void AddRule(IRule rule)
        {
            _firstRule = new ChainElement(rule, _firstRule);
        }
    }
}
