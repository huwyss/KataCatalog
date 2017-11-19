using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataTennis;

namespace KataTennisTest
{
    [TestClass]
    public class TennisTest { 

        Tennis _target;

        [TestInitialize]
        public void Setup()
        {
            _target = new Tennis();
        }

        [TestMethod]
        public void EvaluateScoreTest_When1_0_Then_fifteen_love()
        {
            Assert.AreEqual("Fifteen love", _target.EvaluateScore(1, 0));
        }
    }
}
