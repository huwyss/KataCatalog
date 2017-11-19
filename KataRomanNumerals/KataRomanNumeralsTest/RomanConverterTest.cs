using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataRomanNumerals;

namespace KataRomanNumeralsTest
{
    [TestClass]
    public class RomanConverterTest
    {
        RomanConverter _converter;

        [TestInitialize]
        public void Setup()
        {
            _converter = new RomanConverter();
        }

        [TestMethod]
        public void ToRoman_WhenEnter1To9_Then_IToIX()
        {
            Assert.AreEqual("", _converter.ToRoman(0));
            Assert.AreEqual("I", _converter.ToRoman(1));
            Assert.AreEqual("II", _converter.ToRoman(2));
            Assert.AreEqual("III", _converter.ToRoman(3));
            Assert.AreEqual("IV", _converter.ToRoman(4));
            Assert.AreEqual("V", _converter.ToRoman(5));
            Assert.AreEqual("VI", _converter.ToRoman(6));
            Assert.AreEqual("VII", _converter.ToRoman(7));
            Assert.AreEqual("VIII", _converter.ToRoman(8));
            Assert.AreEqual("IX", _converter.ToRoman(9));
        }

        [TestMethod]
        public void ToRoman_WhenEnter10_11_Then_X_XI()
        {
            Assert.AreEqual("X", _converter.ToRoman(10));
            Assert.AreEqual("XI", _converter.ToRoman(11));
        }

        [TestMethod]
        public void ToRoman_WhenEnter22_99_Then_XXII_()
        {
            Assert.AreEqual("XXII", _converter.ToRoman(22));
            Assert.AreEqual("XXXIII", _converter.ToRoman(33));
            Assert.AreEqual("XLIV", _converter.ToRoman(44));
            Assert.AreEqual("LV", _converter.ToRoman(55));
            Assert.AreEqual("LXVI", _converter.ToRoman(66));
            Assert.AreEqual("LXXVII", _converter.ToRoman(77));
            Assert.AreEqual("LXXXVIII", _converter.ToRoman(88));
            Assert.AreEqual("XCIX", _converter.ToRoman(99));
        }

        [TestMethod]
        public void ToRoman_WhenEnter100_200_Then_C_CC()
        {
            Assert.AreEqual("C", _converter.ToRoman(100));
            Assert.AreEqual("CC", _converter.ToRoman(200));
        }

        [TestMethod]
        public void ToRoman_WhenEnter111_999_Then_CXI_CMXCIX()
        {
            Assert.AreEqual("CXI", _converter.ToRoman(111));
            Assert.AreEqual("CCXXII", _converter.ToRoman(222));
            Assert.AreEqual("CCCXXXIII", _converter.ToRoman(333));
            Assert.AreEqual("CDXLIV", _converter.ToRoman(444));
            Assert.AreEqual("DLV", _converter.ToRoman(555));
            Assert.AreEqual("DCLXVI", _converter.ToRoman(666));
            Assert.AreEqual("DCCLXXVII", _converter.ToRoman(777));
            Assert.AreEqual("DCCCLXXXVIII", _converter.ToRoman(888));
            Assert.AreEqual("CMXCIX", _converter.ToRoman(999));
        }

        [TestMethod]
        public void ToRoman_WhenEnter1000_2000_3333_Then_M_MM_MMMCCCXXXIII()
        {
            Assert.AreEqual("M", _converter.ToRoman(1000));
            Assert.AreEqual("MM", _converter.ToRoman(2000));
            Assert.AreEqual("MMMCCCXXXIII", _converter.ToRoman(3333));
        }
    }
}
