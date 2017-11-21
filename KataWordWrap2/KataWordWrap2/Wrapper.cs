using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KataWordWrap2
{
    public class Wrapper
    {
        public static string Wrap(string input, int length)
        {
            string wrapped = "";
            bool insertBreak = false;

            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                string firstLine = input.Substring(0, length + 1);
                int lastSpaceInFirstLine = firstLine.LastIndexOf(' ');
                if (lastSpaceInFirstLine < 0)
                {
                    lastSpaceInFirstLine = length;
                    insertBreak = true;
                }

                if (insertBreak)
                {
                    wrapped = input.Substring(0, lastSpaceInFirstLine) + "\n";
                    wrapped += Wrap(input.Substring(lastSpaceInFirstLine, input.Length - lastSpaceInFirstLine), length);
                }
                else
                {
                    wrapped = input.Substring(0, lastSpaceInFirstLine) + "\n";
                    wrapped += Wrap(input.Substring(lastSpaceInFirstLine + 1, input.Length - lastSpaceInFirstLine - 1), length);
                }
            }

            return wrapped;
        }
    }
}
