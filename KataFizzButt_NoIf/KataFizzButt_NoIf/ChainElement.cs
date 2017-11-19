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
        ChainElement NextChainElement;

        public ChainElement(IRule rule, ChainElement nextChainRuleElement)
        {
            _rule = rule;
            NextChainElement = nextChainRuleElement;
        }

        public string Handle(int number)
        {
            return _rule.DoesApply(number) ? _rule.Apply(number) : NextChainElement.Handle(number);
        }
    }
}
