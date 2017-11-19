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
    public class RemoveLeadingZerosTest
    {
        [TestMethod]
        public void RemoveLeadingZerosTestMethod()
        {
            Assert.AreEqual("0", VeryLong.RemoveLeadingZeros("0000"));
            Assert.AreEqual("123", VeryLong.RemoveLeadingZeros("0000123"));
            Assert.AreEqual("0.000", VeryLong.RemoveLeadingZeros("0000.000"));
            Assert.AreEqual("1.0", VeryLong.RemoveLeadingZeros("0001.0"));
        }
    }
}
