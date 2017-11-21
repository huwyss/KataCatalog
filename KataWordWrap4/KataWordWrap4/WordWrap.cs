using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataWordWrap4
{
    public class WordWrap
    {
        public static string Wrap(string input, int lineLength)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            string forReturn = "";
            
            if (input.Length > lineLength)
            {
                int index =  input.Substring(0, lineLength + 1).LastIndexOf(" ");
                if (index == -1)
                {
                    forReturn = input.Substring(0, lineLength) + "\n" + Wrap(input.Substring(lineLength), lineLength);
                }
                else
                {
                    forReturn = input.Substring(0,index) + "\n" + Wrap(input.Substring(index+1), lineLength);
                }
            }
            else
            {
                forReturn = input;
            }

            return forReturn;
        }
    }
}
