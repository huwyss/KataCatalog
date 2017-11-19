using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KataDataMunging;

namespace DataMungingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void returnsTheDayOfASingleLine()
        {
            //arrange
            string singleLine = "   4  77    59    68          51.1       0.00         110  9.1 130  12  8.6  62 40 1021.1";

            // act
            int day = DayFinder.dayFromLine(singleLine);

            // assert
            Assert.AreEqual(4, day);
        }

        [TestMethod]
        public void returnsTheTemperatureDifferenceOfASingleLine()
        {
            //arrange
            string singleLine = "   4  77    59    68          51.1       0.00         110  9.1 130  12  8.6  62 40 1021.1";

            // act
            int difference = DayFinder.temperatureDifferenceFromLine(singleLine);

            // assert
            Assert.AreEqual(18, difference);
        }

        [TestMethod]
        public void returnsTheLastDayOfATwoDayMonth()
        {
            //arrange
            string fileContent = "   4  77    59    68          51.1       0.00         110  9.1 130  12  8.6  62 40 1021.1\n"+
                                 "   5  90    89    78          68.3       0.00 TFH     220  8.3 260  12  6.9  84 55 1014.4";

            // act
            int day = DayFinder.dayWithMinimalTemperatureRange(fileContent);

            // assert
            Assert.AreEqual(5, day);
        }

        [TestMethod]
        public void returnsTheFirstDayOfATwoDayMonth()
        {
            //arrange
            string fileContent = "   4  77    76    68          51.1       0.00         110  9.1 130  12  8.6  62 40 1021.1\n" +
                                 "   5  90    88    78          68.3       0.00 TFH     220  8.3 260  12  6.9  84 55 1014.4";

            // act
            int day = DayFinder.dayWithMinimalTemperatureRange(fileContent);

            // assert
            Assert.AreEqual(4, day);
        }

        [TestMethod]
        public void returnsTheFirstDayOfAThreeDayMonth()
        {
            //arrange
            string fileContent = "   6  81    61    71          63.7       0.00 RFH     030  6.2 030  13  9.7  93 60 1012.7\n" +
                                 "   7  73    72    65          53.0       0.00 RF      050  9.5 050  17  5.3  90 48 1021.8\n" +
                                 "   8  75    54    65          50.0       0.00 FH      160  4.2 150  10  2.6  93 41 1026.3";

            // act
            int day = DayFinder.dayWithMinimalTemperatureRange(fileContent);

            // assert
            Assert.AreEqual(7, day);
        }
    }
}
