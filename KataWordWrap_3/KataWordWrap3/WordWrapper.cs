using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataWordWrap3
{
    public class WordWrapper
    {
        public static string Wrap(string input, int lineLength)
        {
            if (input.Length <= lineLength)
            {
                return input;
            }

            int lastSpaceInLine = input.Substring(0, lineLength + 1).LastIndexOf(' ');
            if (lastSpaceInLine >= 0)
            {
                return input.Substring(0, lastSpaceInLine) + "\n" + Wrap(input.Substring(lastSpaceInLine + 1), lineLength);
            }
            else // there is no space in the first line -> wrap it at linelength
            {
                return input.Substring(0, lineLength) + "\n" + Wrap(input.Substring(lineLength), lineLength);
            }
        }
    }
}
