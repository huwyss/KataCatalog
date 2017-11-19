using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataVeryLong
{
    public enum PiAlgorithm
    {
        Euler,
        BBP
    }

    public class VeryLongMath
    {
        private static Stopwatch _stopWatch;
        private static PiAlgorithm _piAlgorithm = PiAlgorithm.BBP;

        public static void SetPiAlgorithm(PiAlgorithm algo)
        {
            _piAlgorithm = algo;
        }

        public static VeryLong Pi(int numberOfDigits)
        {
            VeryLong factor = new VeryLong(1.ToString());
            int additionalCalcDigits = 10;
            int additionalLimitDigits = 0;
            VeryLong pi = new VeryLong("0");

            if (_piAlgorithm == PiAlgorithm.BBP)
            {
                pi = GetStartValueBBP(numberOfDigits + additionalCalcDigits); // BBP
            }
            else if (_piAlgorithm == PiAlgorithm.Euler)
            {
                pi = new VeryLong("3"); // Euler
            }

            VeryLong limit = new VeryLong("0." + VeryLong.GetZeros(numberOfDigits + additionalLimitDigits) + "1"
                + VeryLong.GetZeros(additionalCalcDigits - additionalLimitDigits - 1));
            int i = 0;

            StartTime();

            while (true)
            {
                i++;
                VeryLong term = new VeryLong("0");

                if (_piAlgorithm == PiAlgorithm.BBP)
                {
                    term = GetPiTermBBP(i, numberOfDigits + additionalCalcDigits, ref factor);
                }
                else if (_piAlgorithm == PiAlgorithm.Euler)
                {
                    term = GetPiTermEuler(i, numberOfDigits + additionalCalcDigits);
                }

                if (!term.IsLargerOrEqual(limit))
                {
                    Console.WriteLine("limit reached:");
                    Console.WriteLine("Term:  " + term.ToString());
                    Console.WriteLine("limit: " + limit.ToString());
                    PrintTime();
                    break;
                }

                if (_piAlgorithm == PiAlgorithm.BBP) // BBP
                {
                    pi = pi.Add(term);
                }
                else if (_piAlgorithm == PiAlgorithm.Euler)
                {
                    if (i % 2 == 1)
                    {
                        pi = pi.Add(term);
                    }
                    else
                    {
                        pi = pi.Subtract(term);
                    }
                }

                if (i % 10 == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Term " + i);
                    Console.WriteLine("Pi:    " + pi.ToString());
                    Console.WriteLine("Term:  " + term.ToString());
                    Console.WriteLine("limit: " + limit.ToString());
                    PrintTime();
                }
                else if (i % 1 == 0)
                {
                    Console.Write(".");
                }
            }

            VeryLong piCorrectDigits = new VeryLong(pi.ToString().Remove(numberOfDigits + 2));
            return piCorrectDigits;
        }

        public static VeryLong GetPiTermDivisorEuler(int n)
        {
            // 1 --> 2*3*4
            // 2 --> 4*5*6
            // 3 --> 6*7*8

            VeryLong factor1 = new VeryLong("2").Multiply(new VeryLong(n.ToString()));
            VeryLong factor2 = new VeryLong(factor1.Add(new VeryLong("1")).ToString());
            VeryLong factor3 = new VeryLong(factor2.Add(new VeryLong("1")).ToString());
            return factor1.Multiply(factor2).Multiply(factor3);
        }

        //             4         4         4
        // pi = 3 + ------- - ------- + ------- +- ...
        //           2*3*4     4*5*6     6*7*8
        public static VeryLong GetPiTermEuler(int n, int numberOfDigits)
        {
            VeryLong four = new VeryLong("4");
            VeryLong quotient = four.DivideBy(GetPiTermDivisorEuler(n), numberOfDigits);
            return quotient;
        }

        public static VeryLong GetStartValueBBP(int numberOfDigits)
        {
            // n = 0 --> term = 4/1 - 2/4 - 1/5 - 1/6

            VeryLong subtrahend1 = new VeryLong("0.5");
            VeryLong subtrahend2 = new VeryLong("0.2");
            VeryLong subtrahend3 = new VeryLong(1.ToString()).DivideBy(new VeryLong(6.ToString()), numberOfDigits);
            VeryLong start = new VeryLong(4.ToString()).Subtract(subtrahend1).Subtract(subtrahend2).Subtract(subtrahend3);
            return start;
        }

        //  1      /  4       2        1        1    \
        //------ * |----- - ------ - ------ - ------ |
        // 16^n    \ 8n+1    8n+4     8n+5     8n+6  /
        public static VeryLong GetPiTermBBP(int n, int numberOfDigits, ref VeryLong factor)
        {
            VeryLong factor16 = new VeryLong(16.ToString());
            factor = factor.DivideBy(factor16, numberOfDigits);

            VeryLong summand1 = new VeryLong(4.ToString());
            VeryLong divisor1 = new VeryLong(8.ToString());
            divisor1 = divisor1.Multiply(new VeryLong(n.ToString())).Add(new VeryLong(1.ToString()));
            summand1 = summand1.DivideBy(divisor1, numberOfDigits);

            VeryLong subtrahend2 = new VeryLong(2.ToString());
            VeryLong divisor2 = new VeryLong(8.ToString());
            divisor2 = divisor2.Multiply(new VeryLong(n.ToString())).Add(new VeryLong(4.ToString()));
            subtrahend2 = subtrahend2.DivideBy(divisor2, numberOfDigits);

            VeryLong subtrahend3 = new VeryLong(1.ToString());
            VeryLong divisor3 = new VeryLong(8.ToString());
            divisor3 = divisor3.Multiply(new VeryLong(n.ToString())).Add(new VeryLong(5.ToString()));
            subtrahend3 = subtrahend3.DivideBy(divisor3, numberOfDigits);

            VeryLong subtrahend4 = new VeryLong(1.ToString());
            VeryLong divisor4 = new VeryLong(8.ToString());
            divisor4 = divisor4.Multiply(new VeryLong(n.ToString())).Add(new VeryLong(6.ToString()));
            subtrahend4 = subtrahend4.DivideBy(divisor4, numberOfDigits);

            VeryLong sum = summand1.Subtract(subtrahend2).Subtract(subtrahend3).Subtract(subtrahend4);
            VeryLong term = sum.Multiply(factor);
            term.LimitPrecisionTo(numberOfDigits);

            return term;
        }

        // Berechne die quadratwurzel aus q (Heronverfahren)
        //
        //         1    /       q   \
        // xn+1 = --- * | xn + ---- |
        //         2    \       xn  /
        // Each iteration about doubles the correct decimal places!
        public static VeryLong Sqrt(VeryLong input, int numberOfDigits)
        {
            int additionalCalcDigits = 5;
            int additionalLimitDigits = 0;
            VeryLong limit = new VeryLong("0." + VeryLong.GetZeros(numberOfDigits + additionalLimitDigits) + "1"
                + VeryLong.GetZeros(additionalCalcDigits - additionalLimitDigits - 1));
            VeryLong xnew;
            VeryLong delta;
            VeryLong xn = new VeryLong(input.ToString());
            int i = 0;

            while(true)
            {
                VeryLong summand2 = input.DivideBy(xn, numberOfDigits + additionalCalcDigits);
                VeryLong factor = xn.Add(summand2);
                xnew = new VeryLong("0.5").Multiply(factor);
                delta = xnew.Subtract(xn);
                Console.WriteLine("i " + i);
                Console.WriteLine("Sqrt delta: " + delta.ToString());
                Console.WriteLine("limit:      " + limit.ToString());
                Console.WriteLine("Sqrt:       " + xnew.ToString());
                xn = xnew;
                i++;
                if (!delta.Abs().IsLargerOrEqual(limit))
                {
                    break;
                }
            }

            xn.LimitPrecisionTo(numberOfDigits);
            return xn;
        }

        private static void StartTime()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }

        private static void PrintTime()
        {
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = _stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}
