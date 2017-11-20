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
        ChainElement _catchAllChainElement;
        ChainElement _fizzRuleChainElement;
        ChainElement _buzzRuleChainElement;
        ChainElement _fizzBuzzRuleChainElement;

        public RulesSet()
        {
            AddRule(new CatchAllRule());
            AddRule(new FizzRule());
            AddRule(new BuzzRule());
            AddRule(new FizzBuzzRule());


            //_catchAllChainElement = new ChainElement(new CatchAllRule(), null);
            //_fizzRuleChainElement = new ChainElement(new FizzRule(), _catchAllChainElement);
            //_buzzRuleChainElement = new ChainElement(new BuzzRule(), _fizzRuleChainElement);
            //_fizzBuzzRuleChainElement = new ChainElement(new FizzBuzzRule(), _buzzRuleChainElement);
        }

        public string ApplyRules(int number)
        {
            string result = _firstRule.Handle(number);
            return result;
        }

        private void AddRule(IRule rule)
        {
            _firstRule = new ChainElement(rule, _firstRule);
        }

    }
}
