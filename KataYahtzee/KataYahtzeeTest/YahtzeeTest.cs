using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataYahtzee;
using System.Collections.Generic;

namespace KataYahtzeeTest
{
    [TestClass]
    public class YahtzeeTest
    {
        Yahtzee _target;

        [TestInitialize]
        public void Setup()
        {
            _target = new Yahtzee();
        }

        [TestMethod]
        public void OnesTest_When12345_Then1()
        {
            Assert.AreEqual(1, _target.Evaluate(new List<int>() { 1, 2, 3, 4, 5 }, YahtzeeType.Ones));
            Assert.AreEqual(2, _target.Evaluate(new List<int>() { 1, 2, 1, 4, 5 }, YahtzeeType.Ones));
            Assert.AreEqual(3, _target.Evaluate(new List<int>() { 2, 2, 1, 1, 1 }, YahtzeeType.Ones));
            Assert.AreEqual(0, _target.Evaluate(new List<int>() { 2, 2, 3, 4, 4 }, YahtzeeType.Ones));
        }

        [TestMethod]
        public void TwosTest_When12345_Then1()
        {
            Assert.AreEqual(1*2, _target.Evaluate(new List<int>()  { 1, 2, 3, 4, 5 }, YahtzeeType.Twos));
            Assert.AreEqual(2*2, _target.Evaluate(new List<int>()  { 1, 2, 2, 4, 5 }, YahtzeeType.Twos));
            Assert.AreEqual(3*2, _target.Evaluate(new List<int>()  { 2, 2, 1, 1, 2 }, YahtzeeType.Twos));
            Assert.AreEqual(0*2, _target.Evaluate(new List<int>() { 1, 3, 3, 4, 4 }, YahtzeeType.Twos));
        }

        [TestMethod]
        public void ThreesFoursFivesTest_When12345_Then1()
        {
            Assert.AreEqual(1 * 3, _target.Evaluate(new List<int>()  { 1, 2, 3, 4, 5 }, YahtzeeType.Threes));
            Assert.AreEqual(2 * 4, _target.Evaluate(new List<int>()  { 4, 2, 2, 4, 5 }, YahtzeeType.Fours));
            Assert.AreEqual(3 * 5, _target.Evaluate(new List<int>() { 2, 5, 5, 5, 2 }, YahtzeeType.Fives));
        }

        [TestMethod]
        public void PairTest_When22345_Then4()
        {
            Assert.AreEqual(4, _target.Evaluate(new List<int>() { 2, 2, 3, 4, 5 }, YahtzeeType.Pair));
            Assert.AreEqual(10, _target.Evaluate(new List<int>() { 4, 4, 4, 5, 5 }, YahtzeeType.Pair));
            Assert.AreEqual(0, _target.Evaluate(new List<int>() { 1, 2, 3, 4, 5 }, YahtzeeType.Pair));
        }

        [TestMethod]
        public void TwoPairsTest_When22345_Then4()
        {
            Assert.AreEqual(4+6, _target.Evaluate(new List<int>() { 2, 2, 3, 3, 5 }, YahtzeeType.TwoPairs));
            Assert.AreEqual(4+6, _target.Evaluate(new List<int>() { 2, 2, 3, 3, 3 }, YahtzeeType.TwoPairs));
            Assert.AreEqual(8+10, _target.Evaluate(new List<int>() { 4, 4, 4, 5, 5 }, YahtzeeType.TwoPairs));
            Assert.AreEqual(0, _target.Evaluate(new List<int>() { 1, 2, 3, 4, 5 }, YahtzeeType.TwoPairs));
            Assert.AreEqual(4, _target.Evaluate(new List<int>() { 1, 1, 1, 1, 5 }, YahtzeeType.TwoPairs));  // 4 gleiche sind auch 2 pair ?!
        }

        [TestMethod]
        public void ThreeOfAKindTest_When22245_Then6()
        {
            Assert.AreEqual(6, _target.Evaluate(new List<int>() { 2, 2, 2, 3, 5 }, YahtzeeType.ThreeOfAKind));
            Assert.AreEqual(9, _target.Evaluate(new List<int>() { 2, 2, 3, 3, 3 }, YahtzeeType.ThreeOfAKind));
            Assert.AreEqual(0, _target.Evaluate(new List<int>() { 4, 4, 1, 5, 5 }, YahtzeeType.ThreeOfAKind));
            Assert.AreEqual(3, _target.Evaluate(new List<int>() { 1, 1, 1, 1, 5 }, YahtzeeType.ThreeOfAKind));  // 4 gleiche sind auch 3 gleiche. Instructions dont mention this. What are the rules?
        }

        [TestMethod]
        public void FourOfAKindTest_When22225_Then8()
        {
            Assert.AreEqual(8, _target.Evaluate(new List<int>() { 2, 2, 2, 3, 2 }, YahtzeeType.FourOfAKind));
            Assert.AreEqual(0, _target.Evaluate(new List<int>() { 2, 2, 3, 3, 3 }, YahtzeeType.FourOfAKind));
            Assert.AreEqual(4, _target.Evaluate(new List<int>() { 1, 1, 1, 1, 1 }, YahtzeeType.FourOfAKind));  // 5 gleiche sind auch 4 gleiche. Instructions dont mention this. What are the rules?
        }

        [TestMethod]
        public void SmallStraightTest_When12345_Then15()
        {
            Assert.AreEqual(15, _target.Evaluate(new List<int>() { 2, 1, 3, 4, 5 }, YahtzeeType.SmallStraight));
            Assert.AreEqual(0, _target.Evaluate(new List<int>() { 2, 2, 3, 3, 3 }, YahtzeeType.SmallStraight));
        }

        [TestMethod]
        public void LargeStraightTest_When23456_Then20()
        {
            Assert.AreEqual(20, _target.Evaluate(new List<int>() { 2, 6, 3, 4, 5 }, YahtzeeType.LargeStraight));
            Assert.AreEqual(0, _target.Evaluate(new List<int>() { 2, 2, 3, 3, 3 }, YahtzeeType.LargeStraight));
        }

        [TestMethod]
        public void FullHouseTest_When22333_Then13()
        {
            Assert.AreEqual(12, _target.Evaluate(new List<int>() { 2, 2, 2, 3, 3 }, YahtzeeType.FullHouse));
            Assert.AreEqual(0, _target.Evaluate(new List<int>() { 3, 3, 3, 3, 3 }, YahtzeeType.FullHouse)); // 5 gleiche ist nicht full house (instructions)
            Assert.AreEqual(0, _target.Evaluate(new List<int>() { 2, 2, 4, 3, 3 }, YahtzeeType.FullHouse));
        }

        [TestMethod]
        public void YahtzeeTest_When22222_Then50()
        {
            Assert.AreEqual(50, _target.Evaluate(new List<int>() { 2, 2, 2, 2, 2 }, YahtzeeType.Yahtzee));
            Assert.AreEqual(50, _target.Evaluate(new List<int>() { 3, 3, 3, 3, 3 }, YahtzeeType.Yahtzee)); 
            Assert.AreEqual(0, _target.Evaluate(new List<int>() { 2, 2, 4, 3, 3 }, YahtzeeType.Yahtzee));
        }

        [TestMethod]
        public void ChanceTest_When11234_ThenSum()
        {
            Assert.AreEqual(11, _target.Evaluate(new List<int>() { 1, 1, 2, 3, 4 }, YahtzeeType.Chance));
            Assert.AreEqual(14, _target.Evaluate(new List<int>() { 1, 3, 1, 3, 6 }, YahtzeeType.Chance));
        }
    }
}
