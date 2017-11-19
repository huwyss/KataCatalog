using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataYahtzee
{
    public enum YahtzeeType
    {
        Ones,
        Twos,
        Threes,
        Fours,
        Fives,
        Sixes,
        Pair,
        TwoPairs,
        ThreeOfAKind,
        FourOfAKind,
        SmallStraight,
        LargeStraight,
        FullHouse,
        Chance,
        Yahtzee
    }

    public class Yahtzee
    {
        List<int> _dices;

        public int Evaluate(List<int> dices, YahtzeeType yahtzeeType)
        {
            _dices = Clone(dices);
            switch (yahtzeeType)
            {
                case YahtzeeType.Ones:
                    return Count(1);
                case YahtzeeType.Twos:
                    return 2 * Count(2);
                case YahtzeeType.Threes:
                    return 3 * Count(3);
                case YahtzeeType.Fours:
                    return 4 * Count(4);
                case YahtzeeType.Fives:
                    return 5 * Count(5);
                case YahtzeeType.Sixes:
                    return 6 * Count(6);
                case YahtzeeType.Pair:
                    return CountEqual(2);
                case YahtzeeType.TwoPairs:
                    return EvalTwoPairs();
                case YahtzeeType.ThreeOfAKind:
                    return CountEqual(3);
                case YahtzeeType.FourOfAKind:
                    return CountEqual(4);
                case YahtzeeType.SmallStraight:
                    return EvalSmallStraight();
                case YahtzeeType.LargeStraight:
                    return EvalLargeStraight();
                case YahtzeeType.FullHouse:
                    return EvalFullHouse();
                case YahtzeeType.Yahtzee:
                    return CountEqual(5) != 0 ? 50 : 0;
                case YahtzeeType.Chance:
                    return _dices.Sum();
                default:
                    return 0;
            }
        }
        
        private int Count(int number)
        {
            int count = 0;
            foreach (int currentNumber in _dices)
            {
                if (currentNumber == number)
                {
                    count++;
                }
            }

            return count;
        }

        private int CountEqual(int numberOfEquals)
        {
            for (int i = 6; i > 0; i--)
            {
                int count = Count(i);
                if (count >= numberOfEquals)
                {
                    return i * numberOfEquals;
                }
            }
            return 0;
        }

        private void RemoveDices(int numberOfDices, int number)
        {
            int foundCounter = 0;
            for (int i = _dices.Count() - 1; i > 0; i--)
            {
                if (_dices[i] == number && foundCounter < numberOfDices)
                {
                    _dices.RemoveAt(i);
                    foundCounter++;
                }
            }
        }

        private int EvalTwoPairs()
        {
            int firstPairScore = CountEqual(2);
            RemoveDices(2, firstPairScore / 2);
            int secondPairScore = CountEqual(2);
            if (firstPairScore != 0 && secondPairScore != 0)
                return firstPairScore + secondPairScore;
            else
                return 0;
        }

        private int EvalSmallStraight()
        {
            _dices.Sort();
            if (_dices[0] == 1 &&
                _dices[1] == 2 &&
                _dices[2] == 3 &&
                _dices[3] == 4 &&
                _dices[4] == 5)
            {
                return 15;
            }
            else
            {
                return 0;
            }
        }

        private int EvalLargeStraight()
        {
            _dices.Sort();
            if (_dices[0] == 2 &&
                _dices[1] == 3 &&
                _dices[2] == 4 &&
                _dices[3] == 5 &&
                _dices[4] == 6)
            {
                return 20;
            }
            else
            {
                return 0;
            }
        }

        private int EvalFullHouse()
        {
            int threeOfAKindScore = CountEqual(3);
            RemoveDices(3, threeOfAKindScore / 3);
            int pairScore = CountEqual(2);
            if (pairScore != 0 && threeOfAKindScore != 0 && threeOfAKindScore / 3 != pairScore / 2)
                return pairScore + threeOfAKindScore;
            else
                return 0;
        }

        private List<int> Clone(List<int> dices)
        {
            List<int> clone = new List<int>();
            foreach (int number in dices)
            {
                clone.Add(number);
            }

            return clone;
        }
    }
}
