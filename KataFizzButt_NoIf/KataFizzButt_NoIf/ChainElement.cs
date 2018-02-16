using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataFizzButt_NoIf
{
    public class ChainElement
    {
        IRule _rule;
        ChainElement _nextChainElement;

        public ChainElement(IRule rule, ChainElement nextChainRuleElement)
        {
            _rule = rule;
            _nextChainElement = nextChainRuleElement;
        }

        public string Handle(int number)
        {
            return _rule.DoesApply(number) ? _rule.Apply(number) : _nextChainElement.Handle(number);
        }
    }
}
