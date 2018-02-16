using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataFizzButt_NoIf;

namespace FizzBuzzTest
{
    [TestClass]
    public class FizzBuzzTests
    {
        //
        // fizz rule
        //

        [TestMethod]
        public void RulesTest_WhenNumber3_ThenFizzRuleDoesApply()
        {
            var fizzRule = new FizzHandler();
            Assert.IsTrue(fizzRule.DoesApply(3));
        }

        [TestMethod]
        public void RulesTest_WhenNumber6_ThenFizzRuleDoesApply()
        {
            var fizzRule = new FizzHandler();
            Assert.IsTrue(fizzRule.DoesApply(6));
        }

        [TestMethod]
        public void RulesTest_WhenNumber4_ThenFizzRuleDoesNotApply()
        {
            var fizzRule = new FizzHandler();
            Assert.IsFalse(fizzRule.DoesApply(4));
        }

        [TestMethod]
        public void RulesTest_WhenFizzAplied_ThenFizz()
        {
            var fizzRule = new FizzHandler();
            Assert.AreEqual("fizz", fizzRule.Apply(3));
        }

        //
        // buzz rule
        //

        [TestMethod]
        public void RulesTest_WhenNumber5_ThenBuzzRuleDoesApply()
        {
            var buzzRule = new BuzzHandler();
            Assert.IsTrue(buzzRule.DoesApply(5));
        }

        [TestMethod]
        public void RulesTest_WhenNumber10_ThenBuzzRuleDoesApply()
        {
            var buzzRule = new BuzzHandler();
            Assert.IsTrue(buzzRule.DoesApply(10));
        }

        [TestMethod]
        public void RulesTest_WhenNumber6_ThenBuzzRuleDoesNotApply()
        {
            var buzzRule = new BuzzHandler();
            Assert.IsFalse(buzzRule.DoesApply(6));
        }

        [TestMethod]
        public void RulesTest_WhenBuzzAplied_ThenBuzz()
        {
            var buzzRule = new BuzzHandler();
            Assert.AreEqual("buzz", buzzRule.Apply(5));
        }

        [TestMethod]
        public void RulesTest_WhenCatchallAlwaysApplies()
        {
            var catchallRule = new CatchAllHandler();
            Assert.IsTrue(catchallRule.DoesApply(4));
        }

        // 
        // main 
        //

        [TestMethod]
        public void FizzBuzzerTest_WhenInput1_Then1()
        {
            var fizzbuzzer = new FizzBuzzer();
            Assert.AreEqual("1", fizzbuzzer.Evaluate(1));
        }

        [TestMethod]
        public void FizzBuzzerTest_WhenInput3_ThenFizz()
        {
            var fizzbuzzer = new FizzBuzzer();
            Assert.AreEqual("fizz", fizzbuzzer.Evaluate(3));
        }

        [TestMethod]
        public void FizzBuzzerTest_WhenInput5_ThenBuzz()
        {
            var fizzbuzzer = new FizzBuzzer();
            Assert.AreEqual("buzz", fizzbuzzer.Evaluate(5));
        }

        [TestMethod]
        public void FizzBuzzerTest_WhenInput15_ThenBuzz()
        {
            var fizzbuzzer = new FizzBuzzer();
            Assert.AreEqual("fizzbuzz", fizzbuzzer.Evaluate(15));
        }

        [TestMethod]
        public void FizzBuzzerTest_WhenInput12_ThenBuzz()
        {
            var fizzbuzzer = new FizzBuzzer();
            Assert.AreEqual("fizz", fizzbuzzer.Evaluate(12));
        }

        [TestMethod]
        public void FizzBuzzerTest_WhenInput11_ThenBuzz()
        {
            var fizzbuzzer = new FizzBuzzer();
            Assert.AreEqual("11", fizzbuzzer.Evaluate(11));
        }
    }

    
}
