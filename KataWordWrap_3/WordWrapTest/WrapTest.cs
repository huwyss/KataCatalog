using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataWordWrap3;

namespace WordWrapTest
{
    [TestClass]
    public class WrapTest
    {
        [TestMethod]
        public void WrapTest_WhenEmpty_ThenReturnEmpty()
        {
            Assert.AreEqual("", WordWrapper.Wrap("", 10), "empty string not properly wrapped");
        }

        [TestMethod]
        public void WrapTest_WhenShorterThanLine_ThenReturnLineUnchanged()
        {
            Assert.AreEqual("Text", WordWrapper.Wrap("Text", 10), "short string needs no wrapping");
        }

        [TestMethod]
        public void WrapTest_WhenSpaceAtLineLenght_ThenBreakAtSpace()
        {
            string wrapped = WordWrapper.Wrap("text text text", 10);
            Assert.AreEqual("text text\ntext", wrapped , "wrap at Space and Linelength not working");
        }

        [TestMethod]
        public void WrapTest_WhenSpace1BeforeLineLength_ThenBreakBeforeSpace()
        {
            string wrapped = WordWrapper.Wrap("text text text", 9);
            Assert.AreEqual("text text\ntext", wrapped);
        }

        [TestMethod]
        public void WrapTest_WhenSpace2BeforeLineLength_ThenBreakBeforeSpace()
        {
            string wrapped = WordWrapper.Wrap("text text text", 11);
            Assert.AreEqual("text text\ntext", wrapped);
        }

        [TestMethod]
        public void WrapTest_WhenVeryLongWord_ThenBreakAtLineLengthAnyway()
        {
            string wrapped = WordWrapper.Wrap("texttext text", 4);
            Assert.AreEqual("text\ntext\ntext", wrapped);
        }

        // tests from older version

        [TestMethod]
        public void Wraptest_WhenInEmpty_ThenOutEmpty()
        {
            string wrapped = WordWrapper.Wrap("", 2);
            Assert.AreEqual("", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLineShorterThanMax_ThenWrappedLineSame()
        {
            string wrapped = WordWrapper.Wrap("word", 5);
            Assert.AreEqual("word", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLineLengthAtSpace_ThenBreakAtSpace()
        {
            string wrapped = WordWrapper.Wrap("word word word", 10);
            Assert.AreEqual("word word\nword", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLineLengthAtLetter_ThenWrapSpaceLeftOfLineLength()
        {
            string wrapped = WordWrapper.Wrap("word word word", 11);
            Assert.AreEqual("word word\nword", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLineLengthAtLetter_ThenWrapAtFirstSpaceLeftOfLineLength()
        {
            string wrapped = WordWrapper.Wrap("word word word", 12);
            Assert.AreEqual("word word\nword", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLongLine_ThenBreakAtSpaceOrLineLength()
        {
            string wrapped = WordWrapper.Wrap("word word word", 8);
            Assert.AreEqual("word\nword\nword", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLongLine2_ThenBreakAtSpaceOrLineLength()
        {
            string wrapped = WordWrapper.Wrap("word word word", 9);
            Assert.AreEqual("word word\nword", wrapped);
        }

        [TestMethod]
        public void Wraptest_WhenLongLineWithoutSpace_ThenBreakAtLineLength()
        {
            string wrapped = WordWrapper.Wrap("wordword word", 5);
            Assert.AreEqual("wordw\nord\nword", wrapped);
        }
    }
}
