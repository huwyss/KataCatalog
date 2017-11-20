using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataWordWrap3
{
    public class WordWrapper
    {
        public static string Wrap(string input, int maxLength)
        {
            if (input.Length <= maxLength)
            {
                return input;
            }
            else
            {
                string firstLine = input.Substring(0, maxLength + 1);
                int lastSpaceInFirstLine = firstLine.LastIndexOf(' ');
                if (lastSpaceInFirstLine > 0) // break at a space (replace space with \n)
                {
                    return firstLine.Substring(0, lastSpaceInFirstLine) + "\n"
                           + Wrap(input.Substring(lastSpaceInFirstLine + 1, input.Length - lastSpaceInFirstLine - 1), maxLength);
                }
                else // break at maxline and add break
                {
                    return input.Substring(0, maxLength) + "\n"
                       + Wrap(input.Substring(maxLength, input.Length - maxLength), maxLength);
                }
                
            }
        }
    }
}
