using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataVeryLong;

namespace KataVeryLongTest
{
    [TestClass]
    public class AddTest
    {
        [TestMethod]
        public void Add_WhenSumCalculatedOf_1_1_ThenSumIs_2()
        {
            VeryLong number1 = new VeryLong("1");
            VeryLong number2 = new VeryLong("1");
            VeryLong sum = number1.Add(number2);

            Assert.AreEqual("2", sum.ToString());
        }

        [TestMethod]
        public void Add_WhenSumCalculatedOf_1_9_ThenSumIs_10()
        {
            VeryLong number1 = new VeryLong("1");
            VeryLong number2 = new VeryLong("9");
            VeryLong sum = number1.Add(number2);

            Assert.AreEqual("10", sum.ToString());
        }

        [TestMethod]
        public void Add_WhenSumCalculatedOf_19_1_ThenSumIs_20()
        {
            VeryLong number1 = new VeryLong("19");
            VeryLong number2 = new VeryLong("1");
            VeryLong sum = number1.Add(number2);

            Assert.AreEqual("20", sum.ToString());
        }

        [TestMethod]
        public void Add_WhenSumCalculatedOf_1_19_ThenSumIs_20()
        {
            VeryLong number1 = new VeryLong("1");
            VeryLong number2 = new VeryLong("19");
            VeryLong sum = number1.Add(number2);

            Assert.AreEqual("20", sum.ToString());
        }

        [TestMethod]
        public void Add_WhenSumCalculatedOf_1_17_ThenSumIs_18()
        {
            VeryLong number1 = new VeryLong("1");
            VeryLong number2 = new VeryLong("17");
            VeryLong sum = number1.Add(number2);

            Assert.AreEqual("18", sum.ToString());
        }

        [TestMethod]
        public void Add_WhenSumCalculatedOf_100_17_ThenSumIs_117()
        {
            VeryLong number1 = new VeryLong("100");
            VeryLong number2 = new VeryLong("17");
            VeryLong sum = number1.Add(number2);

            Assert.AreEqual("117", sum.ToString());
        }

        [TestMethod]
        public void Add_WhenSumCalculatedOf_100_977_ThenSumIs_1077()
        {
            VeryLong number1 = new VeryLong("100");
            VeryLong number2 = new VeryLong("977");
            VeryLong sum = number1.Add(number2);

            Assert.AreEqual("1077", sum.ToString());
        }

        [TestMethod]
        public void Add_WhenSumCalculatedOf_111111111111111111111111111111_1988888888888888888888888888888_ThenSumIs_1077()
        {
            VeryLong number1 = new VeryLong("111111111111111111111111111111");
            VeryLong number2 = new VeryLong("1988888888888888888888888888888");
            VeryLong sum = number1.Add(number2);

            Assert.AreEqual("2099999999999999999999999999999", sum.ToString());
        }

        [TestMethod]
        public void Add_WhenSumCalculatedOf_511111_77777555555_ThenSumIs_77778066666()
        {
            VeryLong number1 = new VeryLong(     "511111");
            VeryLong number2 = new VeryLong("77777555555");
            VeryLong sum = number1.Add(number2);

            Assert.AreEqual("77778066666", sum.ToString());
        }

        [TestMethod]
        public void Add_WhenOneSumandContainsDot_ThenSumHasMaxDecimalPlaces()
        {
            VeryLong number1 = new VeryLong("1.3");
            VeryLong number2 = new VeryLong("2");
            VeryLong sum = number1.Add(number2);

            Assert.AreEqual("3.3", sum.ToString());
        }

        [TestMethod]
        public void Add_WhenTwoSumandContainsDot_ThenSumHasMaxDecimalPlaces()
        {
            VeryLong number1 = new VeryLong("1.3");
            VeryLong number2 = new VeryLong("2.1111");
            VeryLong sum = number1.Add(number2);

            Assert.AreEqual("3.4111", sum.ToString());
        }

        [TestMethod]
        public void Add_WhenDecimalIs1And9_ThenSumIsCorrect()
        {
            VeryLong number1 = new VeryLong("2.1111");
            VeryLong number2 = new VeryLong("1.9");
            VeryLong sum = number1.Add(number2);

            Assert.AreEqual("4.0111", sum.ToString());
        }
    }
}
