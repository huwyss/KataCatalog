using System;
using System.Collections.Generic;
using KataNumbersInWords3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumbersInWordsTest
{
    [TestClass]
    public class NumbersInWordsTest
    {
        [TestMethod]
        public void ToWordsTest_WhenUpTo20_ThenConvert()
        {
            Assert.AreEqual("one", Converter.ToWords(1));
            Assert.AreEqual("two", Converter.ToWords(2));
            Assert.AreEqual("ten", Converter.ToWords(10));
            Assert.AreEqual("eleven", Converter.ToWords(11));
            Assert.AreEqual("twelve", Converter.ToWords(12));
        }

        [TestMethod]
        public void ToWordsTest_When21To99_ThenConvert()
        {
            Assert.AreEqual("twenty-one", Converter.ToWords(21));
            Assert.AreEqual("eighty-five", Converter.ToWords(85));
            Assert.AreEqual("eighty", Converter.ToWords(80));
        }

        [TestMethod]
        public void ToWordsTest_When100To999_ThenConvert()
        {
            Assert.AreEqual("two hundred and twelve", Converter.ToWords(212));
            Assert.AreEqual("two hundred and twenty-one", Converter.ToWords(221));
            Assert.AreEqual("two hundred and twenty", Converter.ToWords(220));
            Assert.AreEqual("two hundred and fifty", Converter.ToWords(250));
            Assert.AreEqual("two hundred", Converter.ToWords(200));
        }

        [TestMethod]
        public void ToWordsTest_When1000To999000_ThenConvert()
        {
            Assert.AreEqual("nine thousand two hundred", Converter.ToWords(9200));
            Assert.AreEqual("one hundred and twenty-three thousand four hundred and fifty-six", Converter.ToWords(123456));
        }

        [TestMethod]
        public void ToWordsTest_When9000_ThenNoSpaceAtend()
        {
            Assert.AreEqual("nine hundred and ninty-nine thousand", Converter.ToWords(999000));
            Assert.AreEqual("nine thousand", Converter.ToWords(9000));
        }

        [TestMethod]
        public void ToWordsTest_WhenMilionBilion_ThenConvert()
        {
            Assert.AreEqual("nine hundred and ninty-nine million", Converter.ToWords(999000000));
            Assert.AreEqual("nine hundred and ninty-nine billion nine hundred and ninty-nine million", Converter.ToWords(999999000000));
            Assert.AreEqual("one trillion", Converter.ToWords(1000000000000));
        }

        [TestMethod]
        public void GroupTest_When123456_Then_123_456()
        {
            var groups = Converter.SplitThousandGroups(123456);

            Assert.AreEqual(2, groups.Count);

            Assert.AreEqual(456, groups[1].Number);
            Assert.AreEqual(0, groups[1].Exponent);
            Assert.AreEqual(false, groups[1].IsStart);

            Assert.AreEqual(123, groups[0].Number);
            Assert.AreEqual(3, groups[0].Exponent);
            Assert.AreEqual(true, groups[0].IsStart);
        }

        [TestMethod]
        public void GroupTest_When1234567_Then_1_234_567()
        {
            var groups = Converter.SplitThousandGroups(1234567);

            Assert.AreEqual(3, groups.Count);

            Assert.AreEqual(567, groups[2].Number);
            Assert.AreEqual(0, groups[2].Exponent);
            Assert.AreEqual(false, groups[2].IsStart);

            Assert.AreEqual(234, groups[1].Number);
            Assert.AreEqual(3, groups[1].Exponent);
            Assert.AreEqual(false, groups[1].IsStart);

            Assert.AreEqual(1, groups[0].Number);
            Assert.AreEqual(6, groups[0].Exponent);
            Assert.AreEqual(true, groups[0].IsStart);
        }

        [TestMethod]
        public void GroupTest_When123_Then_123()
        {
            var groups = Converter.SplitThousandGroups(123);

            Assert.AreEqual(1, groups.Count);

            Assert.AreEqual(123, groups[0].Number);
            Assert.AreEqual(0, groups[0].Exponent);
            Assert.AreEqual(true, groups[0].IsStart);
        }
    }
}
