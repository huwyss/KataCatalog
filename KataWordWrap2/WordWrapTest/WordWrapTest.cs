using System;
using KataWordWrap2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrapTest
{
    [TestClass]
    public class WordWrapTest
    {
        [TestMethod]
        public void WrapTest_WhenShort_ThenNoWrap()
        {
            Assert.AreEqual("text", Wrapper.Wrap("text", 10));
        }

        [TestMethod]
        public void WrapTest_WhenBreakAtWordEnd_ThenReplaceSpaceWithBreak()
        {
            Assert.AreEqual("text text\ntext", Wrapper.Wrap("text text text", 9));
        }

        [TestMethod]
        public void WrapTest_WhenMoreLines_ThenReplaceSpaceWithBreak()
        {
            Assert.AreEqual("text text\ntext text\ntext", Wrapper.Wrap("text text text text text", 9));
        }

        [TestMethod]
        public void WrapTest_WhenBreakAtSpace_ThenReplaceSpaceWithBreak()
        {
            Assert.AreEqual("text text\ntext", Wrapper.Wrap("text text text", 10));
            Assert.AreEqual("text text\ntext", Wrapper.Wrap("text text text", 11));
            Assert.AreEqual("text text\ntext", Wrapper.Wrap("text text text", 12));
        }

        [TestMethod]
        public void WrapTest_WhenBreakInWord_ThenReplaceLastSpace()
        {
            Assert.AreEqual("text\ntext\ntext", Wrapper.Wrap("text text text", 8));
        }

        [TestMethod]
        public void WrapTest_WhenLongerWordThanLine_ThenBreakInWordMiddle()
        {
            Assert.AreEqual("textt\next\ntext", Wrapper.Wrap("texttext text", 5));
        }
    }
}
