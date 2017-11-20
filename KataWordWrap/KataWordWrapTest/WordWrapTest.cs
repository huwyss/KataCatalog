using System;
using KataWordWrap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataWordWrapTest
{
    [TestClass]
    public class WordWrapTest
    {
        [TestMethod]
        public void Wraptest_WhenInEmpty_ThenOutEmpty()
        {
            string wrapped = WordWrap.Wrap("", 2);
            Assert.AreEqual("", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLineShorterThanMax_ThenWrappedLineSame()
        {
            string wrapped = WordWrap.Wrap("word", 5);
            Assert.AreEqual("word", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLineLengthAtSpace_ThenBreakAtSpace()
        {
            string wrapped = WordWrap.Wrap("word word word", 10);
            Assert.AreEqual("word word\nword", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLineLengthAtLetter_ThenWrapSpaceLeftOfLineLength()
        {
            string wrapped = WordWrap.Wrap("word word word", 11);
            Assert.AreEqual("word word\nword", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLineLengthAtLetter_ThenWrapAtFirstSpaceLeftOfLineLength()
        {
            string wrapped = WordWrap.Wrap("word word word", 12);
            Assert.AreEqual("word word\nword", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLongLine_ThenBreakAtSpaceOrLineLength()
        {
            string wrapped = WordWrap.Wrap("word word word", 8);
            Assert.AreEqual("word\nword\nword", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLongLine2_ThenBreakAtSpaceOrLineLength()
        {
            string wrapped = WordWrap.Wrap("word word word", 9);
            Assert.AreEqual("word word\nword", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLongLineWithoutSpace_ThenBreakAtLineLength()
        {
            string wrapped = WordWrap.Wrap("wordword word", 5);
            Assert.AreEqual("wordw\nord\nword", wrapped);
        }
    }
}
