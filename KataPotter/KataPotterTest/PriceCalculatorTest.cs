using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataPotter;

namespace KataPotterTest
{
    [TestClass]
    public class PriceCalculatorTest
    {
        private PriceCalculator _calculator;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new PriceCalculator();
        }

        [TestMethod]
        public void CalculatePrice_When1Book_Then8Euros()
        {
            Assert.AreEqual(8, _calculator.GetPrice(new int[] { 0 }));
            Assert.AreEqual(8, _calculator.GetPrice(new int[] { 1 }));
            Assert.AreEqual(8, _calculator.GetPrice(new int[] { 2 }));
            Assert.AreEqual(8, _calculator.GetPrice(new int[] { 3 }));
            Assert.AreEqual(8, _calculator.GetPrice(new int[] { 4 }));
        }

        [TestMethod]
        public void CalculatePrice_WhenSameBooks_Then8EurosPerBook()
        {
            Assert.AreEqual(2 * 8, _calculator.GetPrice(new int[] { 0, 0 }));
            Assert.AreEqual(3 * 8, _calculator.GetPrice(new int[] { 1, 1, 1 }));
            Assert.AreEqual(2 * 8, _calculator.GetPrice(new int[] { 2, 2 }));
            Assert.AreEqual(4 * 8, _calculator.GetPrice(new int[] { 3, 3, 3, 3 }));
            Assert.AreEqual(2 * 8, _calculator.GetPrice(new int[] { 4, 4 }));
        }

        [TestMethod]
        public void CalculatePrice_When2DifferentBooks_Then5PercentOff()
        {
            Assert.AreEqual(2 * 0.95 * 8, _calculator.GetPrice(new int[] { 0, 1 }));
            Assert.AreEqual(2 * 0.95 * 8, _calculator.GetPrice(new int[] { 1, 4 }));
            Assert.AreEqual(2 * 0.95 * 8, _calculator.GetPrice(new int[] { 0, 2 }));
        }

        [TestMethod]
        public void CalculatePrice_When3DifferentBooks_Then10PercentOff()
        {
            Assert.AreEqual(3 * 0.9 * 8, _calculator.GetPrice(new int[] { 0, 1, 2 }));
            Assert.AreEqual(3 * 0.9 * 8, _calculator.GetPrice(new int[] { 1, 3, 4 }));
        }

        [TestMethod]
        public void CalculatePrice_When4DifferentBooks_Then20PercentOff()
        {
            Assert.AreEqual(4 * 0.8 * 8, _calculator.GetPrice(new int[] { 0, 1, 2, 3 }));
            Assert.AreEqual(4 * 0.8 * 8, _calculator.GetPrice(new int[] { 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void CalculatePrice_When5DifferentBooks_Then25PercentOff()
        {
            Assert.AreEqual(5 * 0.75 * 8, _calculator.GetPrice(new int[] { 0, 1, 2, 3, 4 }));
        }

        [TestMethod]
        public void CalculatePrice_WhenDiscountOnSomeBooks_Then5PercentOff()
        {
            Assert.AreEqual(2 * 0.95 * 8 + 8, _calculator.GetPrice(new int[] { 0, 0, 1 }));
        }

        [TestMethod]
        public void CalculatePrice_WhenDifferentDiscounts_ThenCorrectPercentageOffForEachPackage()
        {
            Assert.AreEqual(3 * 0.90 * 8 + 2 * 0.95 * 8, _calculator.GetPrice(new int[] { 0, 0, 1, 1, 2 }));
            Assert.AreEqual(4 * 0.8 * 8 + 2 * 0.95 * 8, _calculator.GetPrice(new int[] { 0, 0, 1, 1, 2, 3 }));
        }

        [TestMethod]
        public void CalculatePrice_WhenDifferentDiscountsThatMustBeOptimized_ThenCorrectPercentageOffForEachPackage()
        {
            // 2 x 4 books with 80% is better than 5 books with 75% and 3 books with 10%
            Assert.AreEqual(2 * 4 * 0.8 * 8, _calculator.GetPrice(new int[] { 0, 0, 1, 1, 2, 2, 3, 4 }));
            Assert.AreEqual(3 * (8 * 5 * 0.75) + 2 * (8 * 4 * 0.8), _calculator.GetPrice(new int[]
                                                                                        { 0, 0, 0, 0, 0,
                                                                                          1, 1, 1, 1, 1,
                                                                                          2, 2, 2, 2,
                                                                                          3, 3, 3, 3, 3,
                                                                                          4, 4, 4, 4 }));
        }

        [TestMethod]
        public void CalculatePrice_When4BooksAnd2Books_ThenDontOptimize()
        {
            // 2 x 3 books with 10% is wors than 4 books with 20% and 1 books normal ??
            // 2 * 3 * 0.9 * 8 (=43.2)  >  4 * 8 * 0.8 + 2 * 8 0.95 (=39.52)
            Assert.AreEqual(4 * 8 * 0.8 + 2 * 8 * 0.95, _calculator.GetPrice(new int[] { 0, 0, 1, 1, 2, 3 }));
        }

        [TestMethod]
        public void GetPackages_WhenBooks001_ThenPackagesWith2BooksAndWith1()
        {
            CompareLists(new int[] { 2, 1 }, _calculator.GetPackages(new int[] { 0, 0, 1 }));
            CompareLists(new int[] { 1, 1, 1 }, _calculator.GetPackages(new int[] { 0, 0, 0 }));
            CompareLists(new int[] { 2, 1 }, _calculator.GetPackages(new int[] { 0, 1, 1 }));
            CompareLists(new int[] { 4, 1, 1 }, _calculator.GetPackages(new int[] { 0, 0, 0, 1, 2, 3 }));
            CompareLists(new int[] { 3, 2, 1 }, _calculator.GetPackages(new int[] { 0, 1, 1, 2, 2, 2 }));

            CompareLists(new int[] { 5, 5, 5, 5, 3 }, _calculator.GetPackages(new int[]
                                                                                        { 0, 0, 0, 0, 0,
                                                                                          1, 1, 1, 1, 1,
                                                                                          2, 2, 2, 2,
                                                                                          3, 3, 3, 3, 3,
                                                                                          4, 4, 4, 4 }));
        }

        private void CompareLists(int[] expectedList, int[] actualList)
        {
            Assert.AreEqual(expectedList.Length, actualList.Length);
            for (int i = 0; i < expectedList.Length; i++)
            {
                Assert.AreEqual(expectedList[i], actualList[i]);
            }
        }
    }
}
