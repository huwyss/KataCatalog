using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataNumbersInWords2
{
    public class Group
    {
        public int Number { get; set; } // 1-999
        public int Potenz { get; set; } // 3 für 1'000, 6 für 1'000'000

        public string Name {
            get
            {
                switch (Potenz)
                {
                    case 0:
                        return "";
                        break;
                    case 3:
                        return "thousand";
                        break;
                    case 6:
                        return "million";
                        break;
                    case 9:
                        return "billion";
                        break;
                    case 12:
                        return "trillion";
                        break;
                    case 15:
                        return "quadrillion";
                        break;
                    case 18:
                        return "quintillion";
                        break;
                    default:
                        return "";
                        break;
                }
            }
        }
        
        public Group(int number, int potenz)
        {
            Number = number;
            Potenz = potenz;
        }

        public string ToWords()
        {
            string words = "";
            if (Number > 0)
            {
                words = Converter.Convert1To999(Number);
                if (Potenz > 0)
                {
                    words += " " + Name;
                }
            }

            return words;
        }
    }
}
