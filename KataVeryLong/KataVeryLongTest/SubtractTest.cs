using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataVeryLong;

namespace KataVeryLongTest
{
    [TestClass]
    public class SubtractTest
    {
        [TestMethod]
        public void Subtract_When_1_1_Then_0()
        {
            VeryLong number1 = new VeryLong("1");
            VeryLong number2 = new VeryLong("1");
            Assert.AreEqual("0", number1.Subtract(number2).ToString());
        }

        [TestMethod]
        public void Subtract_When_2_1_Then_1()
        {
            VeryLong number1 = new VeryLong("2");
            VeryLong number2 = new VeryLong("1");
            Assert.AreEqual("1", number1.Subtract(number2).ToString());
        }

        [TestMethod]
        public void Subtract_When_20_1_Then_19()
        {
            VeryLong number1 = new VeryLong("20");
            VeryLong number2 = new VeryLong("1");
            Assert.AreEqual("19", number1.Subtract(number2).ToString());
        }

        [TestMethod]
        public void Subtract_When_200_1_Then_199()
        {
            VeryLong number1 = new VeryLong("200");
            VeryLong number2 = new VeryLong("1");
            Assert.AreEqual("199", number1.Subtract(number2).ToString());
        }

        [TestMethod]
        public void Subtract_When_200_201_Then_minus1()
        {
            VeryLong number1 = new VeryLong("200");
            VeryLong number2 = new VeryLong("201");
            Assert.AreEqual("-1", number1.Subtract(number2).ToString());
        }

        [TestMethod]
        public void Subtract_WhenMinuendOrSubtrahendHaveDecimalPoint_ThenResultAlsoDecimalPoint1()
        {
            VeryLong number1 = new VeryLong("200.0");
            VeryLong number2 = new VeryLong("201");
            Assert.AreEqual("-1.0", number1.Subtract(number2).ToString());
        }

        [TestMethod]
        public void Subtract_WhenMinuendOrSubtrahendHaveDecimalPoint_ThenResultAlsoDecimalPoint2()
        {
            VeryLong number1 = new VeryLong("2.0");
            VeryLong number2 = new VeryLong("1.001");
            Assert.AreEqual("0.999", number1.Subtract(number2).ToString());
        }

        [TestMethod]
        public void Subtract_WhenMinuendOrSubtrahendHaveDecimalPoint_ThenResultAlsoDecimalPoint3()
        {
            VeryLong number1 = new VeryLong("2");
            VeryLong number2 = new VeryLong("1.001");
            Assert.AreEqual("0.999", number1.Subtract(number2).ToString());
        }

    }
}
