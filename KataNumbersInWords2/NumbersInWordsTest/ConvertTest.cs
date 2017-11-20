using System;
using System.Collections.Generic;
using KataNumbersInWords2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumbersInWordsTest
{
    [TestClass]
    public class ConvertTest
    {
        [TestMethod]
        public void ConvertTest_WhenOneDigit_ThenSimplyConvert()
        {
            Assert.AreEqual("one", Converter.ToWords(1));
            Assert.AreEqual("two", Converter.ToWords(2));
            Assert.AreEqual("three", Converter.ToWords(3));
            Assert.AreEqual("four", Converter.ToWords(4));
            Assert.AreEqual("five", Converter.ToWords(5));
            Assert.AreEqual("six", Converter.ToWords(6));
            Assert.AreEqual("seven", Converter.ToWords(7));
            Assert.AreEqual("eight", Converter.ToWords(8));
            Assert.AreEqual("nine", Converter.ToWords(9));
        }

        [TestMethod]
        public void ConvertTest_WhenTwoDigit_ThenSimplyConvert()
        {
            Assert.AreEqual("ten", Converter.ToWords(10));
            Assert.AreEqual("eleven", Converter.ToWords(11));
            Assert.AreEqual("twelve", Converter.ToWords(12));
            Assert.AreEqual("thirteen", Converter.ToWords(13));
            Assert.AreEqual("fourteen", Converter.ToWords(14));
            Assert.AreEqual("fifteen", Converter.ToWords(15));
            Assert.AreEqual("sixteen", Converter.ToWords(16));
            Assert.AreEqual("seventeen", Converter.ToWords(17));
            Assert.AreEqual("eighteen", Converter.ToWords(18));
            Assert.AreEqual("nineteen", Converter.ToWords(19));
        }

        [TestMethod]
        public void ConvertTest_When20to29_ThenConvert()
        {
            Assert.AreEqual("twenty", Converter.ToWords(20));
            Assert.AreEqual("twenty-one", Converter.ToWords(21));
        }

        [TestMethod]
        public void ConvertTest_When30to39_ThenConvert()
        {
            Assert.AreEqual("thirty", Converter.ToWords(30));
            Assert.AreEqual("thirty-one", Converter.ToWords(31));
        }

        [TestMethod]
        public void ConvertTest_When40to99_ThenConvert()
        {
            Assert.AreEqual("forty", Converter.ToWords(40));
            Assert.AreEqual("forty-two", Converter.ToWords(42));
            Assert.AreEqual("fifty-three", Converter.ToWords(53));
            Assert.AreEqual("sixty-four", Converter.ToWords(64));
            Assert.AreEqual("seventy-five", Converter.ToWords(75));
            Assert.AreEqual("eighty-six", Converter.ToWords(86));
            Assert.AreEqual("ninety-seven", Converter.ToWords(97));
            Assert.AreEqual("ninety-eight", Converter.ToWords(98));
            Assert.AreEqual("ninety-nine", Converter.ToWords(99));
        }

        [TestMethod]
        public void ConvertTest_When100To999_ThenConvert()
        {
            Assert.AreEqual("one hundred", Converter.ToWords(100));
            Assert.AreEqual("two hundred", Converter.ToWords(200));
            Assert.AreEqual("two hundred and ten", Converter.ToWords(210));
            Assert.AreEqual("four hundred and seventy-three", Converter.ToWords(473));
            Assert.AreEqual("nine hundred and ninety-nine", Converter.ToWords(999));
        }

        [TestMethod]
        public void ConvertTest_When1000to999999_ThenConvert()
        {
            Assert.AreEqual("one thousand", Converter.ToWords(1000));
            Assert.AreEqual("five hundred and fifty-five thousand", Converter.ToWords(555000));
            Assert.AreEqual("one thousand three hundred and thirty-three", Converter.ToWords(1333));
            Assert.AreEqual("six hundred and sixty-six thousand six hundred and sixty-six", Converter.ToWords(666666));
        }

        [TestMethod]
        public void ConvertTest_WhenMillions_ThenConvert()
        {
            Assert.AreEqual("one million", Converter.ToWords(1000000));
            Assert.AreEqual("nine hundred and ninety-nine million", Converter.ToWords(999000000));
            Assert.AreEqual("nine hundred and ninety-nine million five hundred and fifty-five thousand", Converter.ToWords(999555000));
        }

        [TestMethod]
        public void SplitInGroupsTest_When1000_Then1Pot3()
        {
            List<Group> groups = Converter.SplitInGroups(1000);
            Assert.AreEqual(1, groups.Count);
            Assert.AreEqual(1, groups[0].Number);
            Assert.AreEqual(3, groups[0].Potenz);
            Assert.AreEqual("thousand", groups[0].Name);
        }

        [TestMethod]
        public void SplitInGroupsTest_When1100_Then1Pot3_100Pot0()
        {
            List<Group> groups = Converter.SplitInGroups(1100);
            Assert.AreEqual(2, groups.Count);
            Assert.AreEqual(1, groups[0].Number);
            Assert.AreEqual(3, groups[0].Potenz);
            Assert.AreEqual("thousand", groups[0].Name);
            Assert.AreEqual(100, groups[1].Number);
            Assert.AreEqual(0, groups[1].Potenz);
            Assert.AreEqual("", groups[1].Name);
        }

        [TestMethod]
        public void SplitInGroupsTest_When100100100_Then100Pot6_100Pot3_100Pot0()
        {
            List<Group> groups = Converter.SplitInGroups(100100100);
            Assert.AreEqual(3, groups.Count);
            Assert.AreEqual(100, groups[0].Number);
            Assert.AreEqual(6, groups[0].Potenz);
            Assert.AreEqual("million", groups[0].Name);
            Assert.AreEqual(100, groups[1].Number);
            Assert.AreEqual(3, groups[1].Potenz);
            Assert.AreEqual("thousand", groups[1].Name);
            Assert.AreEqual(100, groups[2].Number);
            Assert.AreEqual(0, groups[2].Potenz);
            Assert.AreEqual("", groups[2].Name);
        }

        [TestMethod]
        public void GroupToWordsTest_WhenThousand_ThenSpace()
        {
            var group = new Group(111, 3);
            Assert.AreEqual("one hundred and eleven thousand", group.ToWords());
        }

        [TestMethod]
        public void GroupToWordsTest_WhenLessThanThousand_ThenNoSpace()
        {
            var group = new Group(111, 0);
            Assert.AreEqual("one hundred and eleven", group.ToWords());
        }

        [TestMethod]
        public void ToWordsTest_WhenBillions_ThenConvert()
        {
            Assert.AreEqual("one hundred and twenty-three billion nine hundred and ninety-nine million five hundred and fifty-five thousand", Converter.ToWords(123999555000));
        }

        [TestMethod]
        public void ToWordsTest_WhenTrillions_ThenConvert()
        {
            Assert.AreEqual("one trillion", Converter.ToWords(1000000000000));
            Assert.AreEqual("one quadrillion one trillion", Converter.ToWords(1001000000000000));
            Assert.AreEqual("one quintillion", Converter.ToWords(1000000000000000000));
        }
    }
}
