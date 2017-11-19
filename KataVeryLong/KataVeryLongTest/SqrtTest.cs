using System;
using System.Text;
using System.Collections.Generic;
using KataVeryLong;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataVeryLongTest
{
    /// <summary>
    /// Summary description for RemoveLeadingZerosTest
    /// </summary>
    [TestClass]
    public class SqrtTest
    {
        [TestMethod]
        public void SqrtTest_When5DigitsAndSqrt2_Then1_41421()
        {
            Assert.IsTrue(VeryLongMath.Sqrt(new VeryLong(2.ToString()), 5).ToString().StartsWith("1.41421"));
        }

        [TestMethod]
        public void SqrtTest_When10DigitsAndSqrt2_Then1_4142135623()
        {
            Assert.IsTrue(VeryLongMath.Sqrt(new VeryLong(2.ToString()), 10).ToString().StartsWith("1.4142135623"));
        }
    }
}
