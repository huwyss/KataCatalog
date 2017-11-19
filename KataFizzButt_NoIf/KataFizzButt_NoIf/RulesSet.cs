using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public class RulesSet 
    {
        ChainElement _catchAllChainElement;
        ChainElement _fizzRuleChainElement;
        ChainElement _buzzRuleChainElement;
        ChainElement _fizzBuzzRuleChainElement;

        public RulesSet()
        {
            _catchAllChainElement = new ChainElement(new CatchAllRule(), null);
            _fizzRuleChainElement = new ChainElement(new FizzRule(), _catchAllChainElement);
            _buzzRuleChainElement = new ChainElement(new BuzzRule(), _fizzRuleChainElement);
            _fizzBuzzRuleChainElement = new ChainElement(new FizzBuzzRule(), _buzzRuleChainElement);
        }

        public string ApplyRules(int number)
        {
            string result = _fizzBuzzRuleChainElement.Handle(number);
            return result;
        }
    }
}
