using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataNumbersInWords;

namespace NumbersInWordsTest
{
    [TestClass]
    public class ConverterTest
    {
        Converter _converter;

        [TestInitialize]
        public void Setup()
        {
            _converter = new Converter();
        }

        [TestMethod]
        public void ToWords_WhenInput1Digit_ThenOutputZeroZOneTwoThreeAndSoOn()
        {
            Assert.AreEqual("zero", _converter.ToWords(0.0));
            Assert.AreEqual("one", _converter.ToWords(1.0));
            Assert.AreEqual("two", _converter.ToWords(2.0));
            Assert.AreEqual("three", _converter.ToWords(3.0));
            Assert.AreEqual("four", _converter.ToWords(4.0));
            Assert.AreEqual("five", _converter.ToWords(5.0));
            Assert.AreEqual("six", _converter.ToWords(6.0));
            Assert.AreEqual("seven", _converter.ToWords(7.0));
            Assert.AreEqual("eight", _converter.ToWords(8.0));
            Assert.AreEqual("nine", _converter.ToWords(9.0));
        }

        [TestMethod]
        public void ToWords_WhenInput10To20_ThenOutputTenToTwenty()
        {
            Assert.AreEqual("ten", _converter.ToWords(10.0));
            Assert.AreEqual("eleven", _converter.ToWords(11.0));
            Assert.AreEqual("twelve", _converter.ToWords(12.0));
            Assert.AreEqual("thirteen", _converter.ToWords(13.0));
            Assert.AreEqual("fourteen", _converter.ToWords(14.0));
            Assert.AreEqual("fifteen", _converter.ToWords(15.0));
            Assert.AreEqual("sixteen", _converter.ToWords(16.0));
            Assert.AreEqual("seventeen", _converter.ToWords(17.0));
            Assert.AreEqual("eighteen", _converter.ToWords(18.0));
            Assert.AreEqual("nineteen", _converter.ToWords(19.0));
            Assert.AreEqual("twenty", _converter.ToWords(20.0));
        }

        [TestMethod]
        public void ToWords_WhenInput21_ThenOutputTwenty_one()
        {
            Assert.AreEqual("twenty one", _converter.ToWords(21.0));
        }

        [TestMethod]
        public void ToWords_WhenInput33_99_ThenOutputThirtyTwo_ninetyNine()
        {
            Assert.AreEqual("thirty three", _converter.ToWords(33.0));
            Assert.AreEqual("fourty four", _converter.ToWords(44.0));
            Assert.AreEqual("fifty five", _converter.ToWords(55.0));
            Assert.AreEqual("sixty six", _converter.ToWords(66.0));
            Assert.AreEqual("seventy seven", _converter.ToWords(77.0));
            Assert.AreEqual("eighty eight", _converter.ToWords(88.0));
            Assert.AreEqual("ninety nine", _converter.ToWords(99.0));
        }

        [TestMethod]
        public void ToWords_WhenInput40_ThenOutputFourty_NotZero()
        {
            Assert.AreEqual("fourty", _converter.ToWords(40.0));
        }

        [TestMethod]
        public void ToWords_WhenInput100_ThenOutputOneHundred()
        {
            Assert.AreEqual("one hundred", _converter.ToWords(100.0));
        }

        [TestMethod]
        public void ToWords_WhenInput111_ThenOutputOneHundredAndEleven()
        {
            Assert.AreEqual("one hundred and eleven", _converter.ToWords(111.0));
        }

        [TestMethod]
        public void ToWords_WhenInput121_ThenOutputOneHundredAndTwentyOne()
        {
            Assert.AreEqual("one hundred and twenty one", _converter.ToWords(121));
        }

        [TestMethod]
        public void ToWords_WhenInput222_ThenOutputTwoHundredAndTwentyTwo()
        {
            Assert.AreEqual("two hundred and twenty two", _converter.ToWords(222));
            Assert.AreEqual("three hundred and twenty two", _converter.ToWords(322));
            Assert.AreEqual("four hundred and twenty two", _converter.ToWords(422));
            Assert.AreEqual("fife hundred and twenty two", _converter.ToWords(522));
            Assert.AreEqual("six hundred and twenty two", _converter.ToWords(622));
            Assert.AreEqual("seven hundred and twenty two", _converter.ToWords(722));
            Assert.AreEqual("eight hundred and twenty two", _converter.ToWords(822));
            Assert.AreEqual("nine hundred and twenty two", _converter.ToWords(922));
        }

        [TestMethod]
        public void ToWords_WhenInput1000_ThenOutputOneThousand()
        {
            Assert.AreEqual("one thousand", _converter.ToWords(1000));
        }

        [TestMethod]
        public void ToWords_WhenInput1234_ThenOutputOneThousandTwoHundredAndThirtyFour()
        {
            Assert.AreEqual("one thousand two hundred and thirty four", _converter.ToWords(1234));
            Assert.AreEqual("nine hundred and eighty seven thousand six hundred and fifty four", _converter.ToWords(987654));
        }

        [TestMethod]
        public void ToWords_WhenInput1million_ThenOutputOnemillion()
        {
            Assert.AreEqual("one million", _converter.ToWords(1000000));
            Assert.AreEqual("one hundred and twenty three million one hundred thousand", _converter.ToWords(123100000));
        }
    }
}
