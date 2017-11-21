using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public class RulesSet 
    {
        ChainElement _firstRuleElement = null;

        public string ApplyRules(int number)
        {
            string result = _firstRuleElement.Handle(number);
            return result;
        }

        public void AddRule(IRule rule)
        {
            _firstRuleElement = new ChainElement(rule, _firstRuleElement);
        }
    }
}
