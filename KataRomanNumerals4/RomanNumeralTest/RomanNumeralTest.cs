using System;
using KataRomanNumerals4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanNumeralTest
{
    [TestClass]
    public class RomanNumeralTest
    {
        [TestMethod]
        public void TestConvert1ToRoman()
        {
            Assert.AreEqual("I", RomanConverter.ToRoman(1));
        }

        [TestMethod]
        public void TestConvert2ToRoman()
        {
            Assert.AreEqual("II", RomanConverter.ToRoman(2));
        }

        [TestMethod]
        public void TestConvert3ToRoman()
        {
            Assert.AreEqual("III", RomanConverter.ToRoman(3));
        }
        
        [TestMethod]
        public void TestConvert5ToRoman()
        {
            Assert.AreEqual("V", RomanConverter.ToRoman(5));
        }

        [TestMethod]
        public void TestConvert6ToRoman()
        {
            Assert.AreEqual("VI", RomanConverter.ToRoman(6));
        }

        [TestMethod]
        public void TestConvert7ToRoman()
        {
            Assert.AreEqual("VII", RomanConverter.ToRoman(7));
        }

        [TestMethod]
        public void TestConvert8ToRoman()
        {
            Assert.AreEqual("VIII", RomanConverter.ToRoman(8));
        }

        [TestMethod]
        public void ToRomanTest_When10_ThenX()
        {
            Assert.AreEqual("X", RomanConverter.ToRoman(10));
            Assert.AreEqual("XIII", RomanConverter.ToRoman(13));
        }

        [TestMethod]
        public void ToRomanTest_When20_ThenXX()
        {
            Assert.AreEqual("XV", RomanConverter.ToRoman(15));
            Assert.AreEqual("XX", RomanConverter.ToRoman(20));
        }


        [TestMethod]
        public void ToRomanTest_When49_ThenXLIX()
        {
            Assert.AreEqual("XL", RomanConverter.ToRoman(40));
            Assert.AreEqual("XLIX", RomanConverter.ToRoman(49));
        }

        [TestMethod]
        public void ToRomanTest_When50_ThenL()
        {
            Assert.AreEqual("L", RomanConverter.ToRoman(50));
        }


        
        [TestMethod]
        public void ToRomanTest_When4_9_ThenIV_IX()
        {
            Assert.AreEqual("IV", RomanConverter.ToRoman(4));
            Assert.AreEqual("IX", RomanConverter.ToRoman(9));
        }

        [TestMethod]
        public void ToRomanTest_When369_ThenIV_CCCLXIX()
        {
            Assert.AreEqual("CCCLXIX", RomanConverter.ToRoman(369));

        }

        [TestMethod]
        public void ToRomanTest_When444_ThenIV_CDXLIV()
        {
            Assert.AreEqual("CDXLIV", RomanConverter.ToRoman(444));

        }

        [TestMethod]
        public void ToRomanTest_When1997_ThenIV_MCMXCVIIX()
        {
            Assert.AreEqual("MCMXCVII", RomanConverter.ToRoman(1997));
        }
    }
}
