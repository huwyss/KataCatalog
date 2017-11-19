using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataDataMunging
{
    /*
     * first(minTuple(tupleStream(readFile())))
     * 
     * readFile() |> tupleStream() |> minTuple() |> first()
     */

    public class DayFinder
    {
        private static int numericElement(string input, int index)
        {
            return int.Parse(input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[index]);
        }

        public static int dayFromLine(string input)
        {
            return numericElement(input, 0);
        }

        public static int temperatureDifferenceFromLine(string input)
        {
            return numericElement(input, 1) - numericElement(input, 2);
        }

        public static int dayWithMinimalTemperatureRange(string fileContent)
        {
            int dayOfSmallestDiff = 0;
            int smallestDiff = 1000000;
            foreach (string line in fileContent.Split("\n".ToCharArray()))
            {
                int currentDiff = temperatureDifferenceFromLine(line);
                if (currentDiff < smallestDiff)
                {
                    smallestDiff = currentDiff;
                    dayOfSmallestDiff = dayFromLine(line);
                }
            }
            return dayOfSmallestDiff;
        }
    }
}
