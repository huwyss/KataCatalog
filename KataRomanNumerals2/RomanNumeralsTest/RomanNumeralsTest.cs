using System;
using KataRomanNumerals2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanNumeralsTest
{
    [TestClass]
    public class RomanNumeralsTest
    {
        [TestMethod]
        public void ToRomanTest_When1000_ThenM()
        {
            Assert.AreEqual("M", RomanConverter.ToRoman(1000));
        }

        [TestMethod]
        public void ToRomanTest_When2000_ThenMM()
        {
            Assert.AreEqual("MM", RomanConverter.ToRoman(2000));
            Assert.AreEqual("MMM", RomanConverter.ToRoman(3000));
        }

        [TestMethod]
        public void ToRomanTest_When900_ThenCM()
        {
            Assert.AreEqual("CM", RomanConverter.ToRoman(900));
            Assert.AreEqual("MCM", RomanConverter.ToRoman(1900));
        }

        [TestMethod]
        public void ToRomanTest_When500_ThenD()
        {
            Assert.AreEqual("D", RomanConverter.ToRoman(500));
            Assert.AreEqual("MD", RomanConverter.ToRoman(1500));
        }

        [TestMethod]
        public void ToRomanTest_When400_ThenCD()
        {
            Assert.AreEqual("CD", RomanConverter.ToRoman(400));
            Assert.AreEqual("MCD", RomanConverter.ToRoman(1400));
        }

        [TestMethod]
        public void ToRomanTest_When100_ThenC()
        {
            Assert.AreEqual("C", RomanConverter.ToRoman(100));
            Assert.AreEqual("CC", RomanConverter.ToRoman(200));
            Assert.AreEqual("CCC", RomanConverter.ToRoman(300));
            Assert.AreEqual("MCC", RomanConverter.ToRoman(1200));
        }

        [TestMethod]
        public void ToRomanTest_When90_ThenXC()
        {
            Assert.AreEqual("XC", RomanConverter.ToRoman(90));
            Assert.AreEqual("CXC", RomanConverter.ToRoman(190));
        }

        [TestMethod]
        public void ToRomanTest_When50to10_ThenL_XL_XXX_XX_X()
        {
            Assert.AreEqual("X", RomanConverter.ToRoman(10));
            Assert.AreEqual("XX", RomanConverter.ToRoman(20));
            Assert.AreEqual("XXX", RomanConverter.ToRoman(30));
            Assert.AreEqual("XL", RomanConverter.ToRoman(40));
            Assert.AreEqual("L", RomanConverter.ToRoman(50));
            Assert.AreEqual("LX", RomanConverter.ToRoman(60));
            Assert.AreEqual("LXX", RomanConverter.ToRoman(70));
            Assert.AreEqual("LXXX", RomanConverter.ToRoman(80));
            Assert.AreEqual("CL", RomanConverter.ToRoman(150));
        }

        [TestMethod]
        public void ToRomanTest_When9to1_ThenIX_to_I()
        {
            Assert.AreEqual("IX", RomanConverter.ToRoman(9));
            Assert.AreEqual("VIII", RomanConverter.ToRoman(8));
            Assert.AreEqual("VII", RomanConverter.ToRoman(7));
            Assert.AreEqual("VI", RomanConverter.ToRoman(6));
            Assert.AreEqual("V", RomanConverter.ToRoman(5));
            Assert.AreEqual("IV", RomanConverter.ToRoman(4));
            Assert.AreEqual("III", RomanConverter.ToRoman(3));
            Assert.AreEqual("II", RomanConverter.ToRoman(2));
            Assert.AreEqual("I", RomanConverter.ToRoman(1));
        }

        [TestMethod]
        public void ToRomanTest_When1986_ThenMCMLXXXVI()
        {
            Assert.AreEqual("MCMLXXXVI", RomanConverter.ToRoman(1986));
        }
    }
}
