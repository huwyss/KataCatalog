using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataVeryLong;

namespace KataVeryLongTest
{
    [TestClass]
    public class MultiplyTest
    {
        [TestMethod]
        public void Multiply_When_1_x_1_Then_1()
        {
            VeryLong number1 = new VeryLong("1");
            VeryLong number2 = new VeryLong("1");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("1", sum.ToString());
        }

        [TestMethod]
        public void Multiply_When_1_x_2_Then_2()
        {
            VeryLong number1 = new VeryLong("1");
            VeryLong number2 = new VeryLong("2");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("2", sum.ToString());
        }

        [TestMethod]
        public void Multiply_When_7_x_8_Then_56()
        {
            VeryLong number1 = new VeryLong("7");
            VeryLong number2 = new VeryLong("8");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("56", sum.ToString());
        }

        [TestMethod]
        public void Multiply_When_7_x_12_Then_84()
        {
            VeryLong number1 = new VeryLong("7");
            VeryLong number2 = new VeryLong("12");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("84", sum.ToString());
        }

        [TestMethod]
        public void Multiply_When_7_x_81_Then_567()
        {
            VeryLong number1 = new VeryLong("7");
            VeryLong number2 = new VeryLong("81");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("567", sum.ToString());
        }

        [TestMethod]
        public void Multiply_When_9_x_99_Then_891()
        {
            VeryLong number1 = new VeryLong("9");
            VeryLong number2 = new VeryLong("99");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("891", sum.ToString());
        }

        [TestMethod]
        public void Multiply_When_10_x_2_Then_20()
        {
            VeryLong number1 = new VeryLong("10");
            VeryLong number2 = new VeryLong("2");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("20", sum.ToString());
        }

        [TestMethod]
        public void Multiply_When_1234_x_56789_Then_70077626()
        {
            VeryLong number1 = new VeryLong("1234");
            VeryLong number2 = new VeryLong("56789");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("70077626", sum.ToString());
        }

        [TestMethod]
        public void Multiply_When_0_x_56789_Then_0()
        {
            VeryLong number1 = new VeryLong("0");
            VeryLong number2 = new VeryLong("56789");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("0", sum.ToString());
        }

        [TestMethod]
        public void Multiply_When_123_x_0_Then_0()
        {
            VeryLong number1 = new VeryLong("123");
            VeryLong number2 = new VeryLong("0");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("0", sum.ToString());
        }

        [TestMethod]
        public void Multiply_When_123_4_x_567_89_Then_70077_626()
        {
            VeryLong number1 = new VeryLong("123.4");
            VeryLong number2 = new VeryLong("567.89");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("70077.626", sum.ToString());
        }

        [TestMethod]
        public void Multiply_When_0_8_x_0_9_Then_0_72()
        {
            VeryLong number1 = new VeryLong("0.8");
            VeryLong number2 = new VeryLong("0.9");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("0.72", sum.ToString());
        }

        [TestMethod]
        public void Multiply_When_0_1_x_0_9_Then_0_09()
        {
            VeryLong number1 = new VeryLong("0.1");
            VeryLong number2 = new VeryLong("0.9");
            VeryLong sum = number1.Multiply(number2);

            Assert.AreEqual("0.09", sum.ToString());
        }

        [TestMethod]
        public void RemoveLeadingZeros_When00023_Then23()
        {
            VeryLong number = new VeryLong("00023");
            number.RemoveLeadingZeros();
            Assert.AreEqual("23", number.ToString());
        }

        [TestMethod]
        public void RemoveLeadingZeros_When0000_Then0()
        {
            VeryLong number = new VeryLong("0000");
            number.RemoveLeadingZeros();
            Assert.AreEqual("0", number.ToString());
        }

        [TestMethod]
        public void RemoveLeadingZeros_When23_Then23()
        {
            VeryLong number = new VeryLong("23");
            number.RemoveLeadingZeros();
            Assert.AreEqual("23", number.ToString());
        }

    }
}
