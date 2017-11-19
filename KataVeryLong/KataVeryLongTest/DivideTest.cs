using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataVeryLong;

namespace KataVeryLongTest
{
    [TestClass]
    public class DivideTest
    {
        [TestMethod]
        public void Divide_When_8_d_2_Then_4_R0()
        {
            VeryLong remainder;
            VeryLong number1 = new VeryLong("8");
            VeryLong number2 = new VeryLong("2");
            VeryLong quotient = number1.DivideBy(number2, out remainder);

            Assert.AreEqual("4", quotient.ToString());
            Assert.AreEqual("0", remainder.ToString());
        }

        [TestMethod]
        public void Divide_When_9_d_2_Then_4_R1()
        {
            VeryLong remainder;
            VeryLong number1 = new VeryLong("9");
            VeryLong number2 = new VeryLong("2");
            VeryLong quotient = number1.DivideBy(number2, out remainder);

            Assert.AreEqual("4", quotient.ToString());
            Assert.AreEqual("1", remainder.ToString());
        }

        [TestMethod]
        public void Divide_When_30000_d_3_Then_10000_R0()
        {
            VeryLong remainder;
            VeryLong number1 = new VeryLong("30000");
            VeryLong number2 = new VeryLong("3");
            VeryLong quotient = number1.DivideBy(number2, out remainder);

            Assert.AreEqual("10000", quotient.ToString());
            Assert.AreEqual("0", remainder.ToString());
        }

        [TestMethod]
        public void Divide_When_12345_d_53_Then_232_R49()
        {
            VeryLong remainder;
            VeryLong number1 = new VeryLong("12345");
            VeryLong number2 = new VeryLong("53");
            VeryLong quotient = number1.DivideBy(number2, out remainder);

            Assert.AreEqual("232", quotient.ToString());
            Assert.AreEqual("49", remainder.ToString());
        }

        [TestMethod]
        public void IsLargerOrEqual_When1_2_Then_false()
        {
            VeryLong number1 = new VeryLong("1");
            VeryLong number2 = new VeryLong("2");
            bool isLargerOrEqual = number1.IsLargerOrEqual(number2);

            Assert.IsFalse(isLargerOrEqual);
        }

        [TestMethod]
        public void IsLargerOrEqual_When2_1_Then_true()
        {
            VeryLong number1 = new VeryLong("2");
            VeryLong number2 = new VeryLong("1");
            bool isLargerOrEqual = number1.IsLargerOrEqual(number2);

            Assert.IsTrue(isLargerOrEqual);
        }

        [TestMethod]
        public void IsLargerOrEqual_When2_2_Then_true()
        {
            VeryLong number1 = new VeryLong("2");
            VeryLong number2 = new VeryLong("2");
            bool isLargerOrEqual = number1.IsLargerOrEqual(number2);

            Assert.IsTrue(isLargerOrEqual);
        }

        [TestMethod]
        public void IsLargerOrEqual_When222_22_Then_true()
        {
            VeryLong number1 = new VeryLong("222");
            VeryLong number2 = new VeryLong("22");
            bool isLargerOrEqual = number1.IsLargerOrEqual(number2);

            Assert.IsTrue(isLargerOrEqual);
        }

        [TestMethod]
        public void IsLargerOrEqual_When22_222_Then_false()
        {
            VeryLong number1 = new VeryLong("22");
            VeryLong number2 = new VeryLong("222");
            bool isLargerOrEqual = number1.IsLargerOrEqual(number2);

            Assert.IsFalse(isLargerOrEqual);
        }

        [TestMethod]
        public void IsLargerOrEqual_When222222_222222_Then_true()
        {
            VeryLong number1 = new VeryLong("222222");
            VeryLong number2 = new VeryLong("222222");
            bool isLargerOrEqual = number1.IsLargerOrEqual(number2);

            Assert.IsTrue(isLargerOrEqual);
        }

        [TestMethod]
        public void IsLargerOrEqual_When222222_222221_Then_true()
        {
            VeryLong number1 = new VeryLong("222222");
            VeryLong number2 = new VeryLong("222221");
            bool isLargerOrEqual = number1.IsLargerOrEqual(number2);

            Assert.IsTrue(isLargerOrEqual);
        }

        [TestMethod]
        public void IsLargerOrEqual_When222221_222222_Then_false()
        {
            VeryLong number1 = new VeryLong("222221");
            VeryLong number2 = new VeryLong("222222");
            bool isLargerOrEqual = number1.IsLargerOrEqual(number2);

            Assert.IsFalse(isLargerOrEqual);
        }

        [TestMethod]
        public void IsLargerOrEqual_When123_106_Then_true()
        {
            VeryLong number1 = new VeryLong("123");
            VeryLong number2 = new VeryLong("106");
            bool isLargerOrEqual = number1.IsLargerOrEqual(number2);

            Assert.IsTrue(isLargerOrEqual);
        }

        [TestMethod]
        public void IsLargerOrEqual_When0_11__1_11_Then_false()
        {
            VeryLong number1 = new VeryLong("0.11");
            VeryLong number2 = new VeryLong("1.11");
            bool isLargerOrEqual = number1.IsLargerOrEqual(number2);

            Assert.IsFalse(isLargerOrEqual);
        }

        [TestMethod]
        public void IsLargerOrEqual_When0_111__1_11_Then_false()
        {
            VeryLong number1 = new VeryLong("0.111");
            VeryLong number2 = new VeryLong("1.11");
            bool isLargerOrEqual = number1.IsLargerOrEqual(number2);

            Assert.IsFalse(isLargerOrEqual);
        }

        [TestMethod]
        public void IsLargerOrEqual_When0_111__0_19_Then_false()
        {
            VeryLong number1 = new VeryLong("0.111");
            VeryLong number2 = new VeryLong("0.19");
            bool isLargerOrEqual = number1.IsLargerOrEqual(number2);

            Assert.IsFalse(isLargerOrEqual);
        }

        [TestMethod]
        public void GetIntegerTest_When100_4_Then100()
        {
            VeryLong number = new VeryLong("100.4");
            Assert.AreEqual("100", number.GetInteger());
        }

        [TestMethod]
        public void GetIntegerTest_When100_Then100()
        {
            VeryLong number = new VeryLong("100");
            Assert.AreEqual("100", number.GetInteger());
        }

        [TestMethod]
        public void GetDecimalDigitsTest_When100_12_Then12()
        {
            VeryLong number = new VeryLong("100.12");
            Assert.AreEqual("12", number.GetDecimalDigits());
        }

        [TestMethod]
        public void GetDecimalDigitsTest_When100_Then0()
        {
            VeryLong number = new VeryLong("100");
            Assert.AreEqual("0", number.GetDecimalDigits());
        }

        [TestMethod]
        public void DivideSimpleTest_When_22_d_23_Then_0()
        {
            string result = VeryLong.DivideSimple("22", "23");
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void DivideSimpleTest_When_23_d_23_Then_2()
        {
            string result = VeryLong.DivideSimple("23", "23");
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void DivideSimpleTest_When_19_d_2_Then_9()
        {
            string result = VeryLong.DivideSimple("19", "2");
            Assert.AreEqual("9", result);
        }

        [TestMethod]
        public void DivideBy_When_1_d_3_And10Digits_Then_0point3333333333()
        {
            int numberOfDigits = 10;
            VeryLong number1 = new VeryLong("1");
            VeryLong number2 = new VeryLong("3");
            VeryLong quotient = number1.DivideBy(number2, numberOfDigits);

            Assert.AreEqual("0.3333333333", quotient.ToString());
        }

        [TestMethod]
        public void DivideBy_When_1_d_4_And10Digits_Then_0point25()
        {
            int numberOfDigits = 10;
            VeryLong number1 = new VeryLong(1.ToString());
            VeryLong number2 = new VeryLong(4.ToString());
            VeryLong quotient = number1.DivideBy(number2, numberOfDigits);

            Assert.AreEqual("0.2500000000", quotient.ToString());
        }

        [TestMethod]
        public void DivideBy_When_1_24_d_2_And10Digits_Then_0point62()
        {
            int numberOfDigits = 10;
            VeryLong number1 = new VeryLong("1.24");
            VeryLong number2 = new VeryLong("2");
            VeryLong quotient = number1.DivideBy(number2, numberOfDigits);

            Assert.AreEqual("0.6200000000", quotient.ToString());
        }

        [TestMethod]
        public void DivideBy_When_1_24_d_0_2_And10Digits_Then_0point062()
        {
            int numberOfDigits = 10;
            VeryLong number1 = new VeryLong("1.24");
            VeryLong number2 = new VeryLong("0.2");
            VeryLong quotient = number1.DivideBy(number2, numberOfDigits);

            Assert.AreEqual("6.2000000000", quotient.ToString());
        }

        [TestMethod]
        public void DivideBy_When_1_00000_d_1_5_And10Digits_Then_0point02500()
        {
            int numberOfDigits = 10;
            VeryLong number1 = new VeryLong("1.00000");
            VeryLong number2 = new VeryLong("1.5");
            VeryLong quotient = number1.DivideBy(number2, numberOfDigits);

            Assert.AreEqual("0.6666666666", quotient.ToString());
        }

        [TestMethod]
        public void DivideBy_When_1_00000_d_1_5000_And10Digits_Then_0point02500()
        {
            int numberOfDigits = 10;
            VeryLong number1 = new VeryLong("1.00000");
            VeryLong number2 = new VeryLong("1.50000");
            VeryLong quotient = number1.DivideBy(number2, numberOfDigits);

            Assert.AreEqual("0.6666666666", quotient.ToString());
        }

        [TestMethod]
        public void AbsTest_When_1_123_Then_1_123()
        {
            VeryLong number = new VeryLong("1.123");
            Assert.AreEqual("1.123", number.Abs().ToString());
        }

        [TestMethod]
        public void AbsTest_When_minus1_123_Then_1_123()
        {
            VeryLong number = new VeryLong("-1.123");
            Assert.AreEqual("1.123", number.Abs().ToString());
        }
    }
}
