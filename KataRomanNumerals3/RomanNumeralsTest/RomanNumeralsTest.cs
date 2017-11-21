using System;
using KataRomanNumerals3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanNumeralsTest
{
    [TestClass]
    public class RomanNumeralsTest
    {
        [TestMethod]
        public void ToRomanTest_When1_ThenI()
        {
            Assert.AreEqual("I", RomanNumeralsConverter.ToRoman(1));
            Assert.AreEqual("II", RomanNumeralsConverter.ToRoman(2));
            Assert.AreEqual("III", RomanNumeralsConverter.ToRoman(3));
        }

        [TestMethod]
        public void ToRomanTest_When5_ThenV()
        {
            Assert.AreEqual("V", RomanNumeralsConverter.ToRoman(5));
            Assert.AreEqual("VI", RomanNumeralsConverter.ToRoman(6));
            Assert.AreEqual("VII", RomanNumeralsConverter.ToRoman(7));
            Assert.AreEqual("VIII", RomanNumeralsConverter.ToRoman(8));
        }

        [TestMethod]
        public void ToRomanTest_When10_ThenX()
        {
            Assert.AreEqual("X", RomanNumeralsConverter.ToRoman(10));
            Assert.AreEqual("XX", RomanNumeralsConverter.ToRoman(20));
        }

        [TestMethod]
        public void ToRomanTest_When4_ThenIV()
        {
            Assert.AreEqual("IV", RomanNumeralsConverter.ToRoman(4));
        }

        [TestMethod]
        public void ToRomanTest_When9_ThenIX()
        {
            Assert.AreEqual("IX", RomanNumeralsConverter.ToRoman(9));
        }

        [TestMethod]
        public void ToRomanTest_When40_50_90_100_ThenXL_L_XC_C_()
        {
            Assert.AreEqual("XL", RomanNumeralsConverter.ToRoman(40));
            Assert.AreEqual("L", RomanNumeralsConverter.ToRoman(50));
            Assert.AreEqual("XC", RomanNumeralsConverter.ToRoman(90));
            Assert.AreEqual("C", RomanNumeralsConverter.ToRoman(100));
        }

        [TestMethod]
        public void ToRomanTest_When400_500_900_1000_ThenCD_D_CM_M()
        {
            Assert.AreEqual("CD", RomanNumeralsConverter.ToRoman(400));
            Assert.AreEqual("D", RomanNumeralsConverter.ToRoman(500));
            Assert.AreEqual("CM", RomanNumeralsConverter.ToRoman(900));
            Assert.AreEqual("M", RomanNumeralsConverter.ToRoman(1000));
        }

        [TestMethod]
        public void ToRomanTest_When1999_ThenMCMXCIX()
        {
            Assert.AreEqual("MCMXCIX", RomanNumeralsConverter.ToRoman(1999));
        }
    }
}
