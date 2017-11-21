using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataWordWrap
{
    public class WordWrap
    {
        public static string Wrap(string input, int lineLength)
        {
            if (input.Length <= lineLength)
            {
                return input;
            }

            int firstLineLength = input.Substring(0, lineLength + 1).LastIndexOf(' ');
            bool lineWithoutSpace = false;
            if (firstLineLength == -1)
            {
                firstLineLength = lineLength;
                lineWithoutSpace = true;
            }

            string firstLine = input.Substring(0, firstLineLength) + "\n";

            int indexSecondPart = lineWithoutSpace ? firstLineLength : firstLineLength + 1;
            int lengthSecondPart = lineWithoutSpace ? input.Length - firstLineLength : input.Length - firstLineLength - 1;

            string secondPart = Wrap(input.Substring(indexSecondPart, lengthSecondPart), lineLength);

            return firstLine + secondPart;
        }

    }
}
