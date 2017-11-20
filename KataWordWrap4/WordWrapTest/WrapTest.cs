using System;
using KataWordWrap4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordWrapTest
{
    [TestClass]
    public class WrapTest
    {
        [TestMethod]
        public void WrapTest_WhenEmpty_ThenEmpty()
        {
            string wrapped = WordWrap.Wrap("", 10);
            Assert.AreEqual("", wrapped);
        }

        [TestMethod]
        public void WrapTest_WhenNull_ThenEmpty()
        {
            string wrapped = WordWrap.Wrap(null, 10);
            Assert.AreEqual("", wrapped);
        }


        [TestMethod]
        public void WrapTest_WhenSimpleString()
        {
            string wrapped = WordWrap.Wrap("Hallo zusammen", 14);
            Assert.AreEqual("Hallo zusammen", wrapped);
        }



        [TestMethod]
        public void WrapTest_WhenStringToLong()
        {
            string wrapped = WordWrap.Wrap("HalloPat", 5);
            Assert.AreEqual("Hallo\nPat", wrapped);
        }


        [TestMethod]
        public void WrapTest_WhenStringmorthen3Lines()
        {
            string wrapped = WordWrap.Wrap("HalloHalloHallo", 5);
            Assert.AreEqual("Hallo\nHallo\nHallo", wrapped);
        }


        [TestMethod]
        public void WrapTest_WhenStringhasSpace()
        {
            string wrapped = WordWrap.Wrap("Hallo Hallo Hallo", 5);
            Assert.AreEqual("Hallo\nHallo\nHallo", wrapped);
        }

        [TestMethod]
        public void WrapTest_WhenStringhasSpaceAnywhere()
        {
            string wrapped = WordWrap.Wrap("Hallo Hallo Hallo", 6);
            Assert.AreEqual("Hallo\nHallo\nHallo", wrapped);
        }

        [TestMethod]
        public void WrapTest_WhenStringhasSpaceAnywhereDoppelSpace()
        {
            string wrapped = WordWrap.Wrap("Hallo Ha      Hallo", 6);
            Assert.AreEqual("Hallo\nHa    \n Hallo", wrapped);
        }

        [TestMethod]
        public void WrapTest_full()
        {
            string wrapped = WordWrap.Wrap("Diesist ein zufälliger Te", 6);
            Assert.AreEqual("Diesis\nt ein\nzufäll\niger\nTe", wrapped);
        }

    }
}
