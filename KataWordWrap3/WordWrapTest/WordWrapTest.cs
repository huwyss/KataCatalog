using System;
using KataWordWrap3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrapTest
{
    [TestClass]
    public class WordWrapTest
    {
        [TestMethod]
        public void WrapTest_WhenShortLine_ThenNoBreak()
        {
            Assert.AreEqual("", WordWrapper.Wrap("", 5));
            Assert.AreEqual("word", WordWrapper.Wrap("word", 5));
        }

        [TestMethod]
        public void WrapTest_WhenLongLineNoSpace_ThenNoBreakAtLineLength()
        {
            Assert.AreEqual("longw\nord", WordWrapper.Wrap("longword", 5));
            Assert.AreEqual("word\nword\nword", WordWrapper.Wrap("wordwordword", 4));
        }

        [TestMethod]
        public void WrapTest_WhenLineWithSpace_ThenBreakAtLastSpace()
        {
            Assert.AreEqual("word word\nword", WordWrapper.Wrap("word word word", 10));
        }

        [TestMethod]
        public void WrapTest_WhenLineWithSpaceAfterLineMax_ThenBreakAtLastSpace()
        {
            Assert.AreEqual("word word\nword", WordWrapper.Wrap("word word word", 9));
            Assert.AreEqual("word word\nword", WordWrapper.Wrap("word word word", 11));
            Assert.AreEqual("word\nword\nword", WordWrapper.Wrap("word word word", 8));
        }

       
    }
}
