using System;
using System.Collections.Generic;

namespace KataVeryLong
{
    public class VeryLong
    {
        private string _integerString;
        

        public VeryLong(string integerString)
        {
            _integerString = integerString;
        }

        public VeryLong Subtract(VeryLong subtrahend)
        {
            int minuendDecimalPlaces = GetDecimalPlaces();
            int subtrahendDecimalPlaces = subtrahend.GetDecimalPlaces();
            int decimalPlaces = Math.Max(minuendDecimalPlaces, subtrahendDecimalPlaces);
            FillUpDecimalPlacesWithZero(decimalPlaces);
            subtrahend.FillUpDecimalPlacesWithZero(decimalPlaces);

            string result = "";
            int diff = 0;
            int borrow = 0;
            int currentLastDigit = 0;
            int currentLastDigitSubtrahend = 0;
            int i = 0;

            if (!IsLargerOrEqual(subtrahend))
            {
                // swap: minuend is smaller than subtrahend --> result is negative
                VeryLong newMinuend = subtrahend;
                VeryLong newSubtrahend = new VeryLong(ToString());
                VeryLong difference = newMinuend.Subtract(newSubtrahend);
                return new VeryLong("-" + difference.ToString());
            }

            while (Length() > i || subtrahend.Length() > i || borrow != 0)
            {
                if (GetLastDigit(i) == ".")
                {
                    result = result.Insert(0, ".");
                    i++;
                    continue;
                }

                currentLastDigit = int.Parse(GetLastDigit(i));
                currentLastDigitSubtrahend = int.Parse(subtrahend.GetLastDigit(i));
                diff = currentLastDigit - currentLastDigitSubtrahend - borrow;
                if (diff < 0)
                {
                    borrow = 1;
                    diff += 10;
                }
                else
                {
                    borrow = 0;
                }
                result = result.Insert(0, diff.ToString());
                i++;
            }

            result = RemoveLeadingZeros(result);
            return new VeryLong(result);
        }

        public void RemoveLeadingZeros()
        {
            _integerString = VeryLong.RemoveLeadingZeros(_integerString);
        }

        public static string RemoveLeadingZeros(string number)
        {
            if (number == "0")
            {
                return number;
            }
            
            // if "00000" --> "0"
            int countZeros = number.Length - 1;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] != '0')
                {
                    if (number[i] == '.')
                    {
                        countZeros = i - 1;
                    }
                    else
                    {
                        countZeros = i;
                    }
                    
                    break;
                }
            }

            string withoutZeros = number.Remove(0, countZeros);
            return withoutZeros;
        }

        public VeryLong Add(VeryLong other)
        {
            int summand1DecimalPlaces = GetDecimalPlaces();
            int summand2DecimalPlaces = other.GetDecimalPlaces();
            int decimalPlaces = Math.Max(summand1DecimalPlaces, summand2DecimalPlaces);
            FillUpDecimalPlacesWithZero(decimalPlaces);
            other.FillUpDecimalPlacesWithZero(decimalPlaces);

            string result = "";
            int sum = 0;
            int behalte = 0;
            int resultDigit = 0;
            int currentLastDigit = 0;
            int currentLastDigitOther = 0;
            int i = 0;

            while (Length() > i || other.Length() > i || behalte != 0)
            {
                if (GetLastDigit(i) == ".")
                {
                    result = result.Insert(0, ".");
                    i++;
                    continue;
                }

                currentLastDigit = int.Parse(GetLastDigit(i));
                currentLastDigitOther = int.Parse(other.GetLastDigit(i));
                sum = currentLastDigit + currentLastDigitOther + behalte;
                behalte = sum / 10;
                resultDigit = sum % 10;
                result = result.Insert(0, resultDigit.ToString());
                i++;
            }

            return new VeryLong(result);
        }

        private void FillUpDecimalPlacesWithZero(int decimalPlaces)
        {
            int currentDecimalPlaces = GetDecimalPlaces();
            if (currentDecimalPlaces == decimalPlaces)
            {
                return;
            }

            if (currentDecimalPlaces == 0)
            {
                AddDecimalPoint();
            }

            AddZeros(decimalPlaces - currentDecimalPlaces);
        }

        private void AddDecimalPoint()
        {
            _integerString += ".";
        }

        private void AddZeros(int numberZeros)
        {
            string zeros = "";
            for (int i=0; i<numberZeros; i++)
            {
                zeros += "0";
            }

            _integerString += zeros;
        }

        public static VeryLong AddSummands(List<string> summands)
        {
            VeryLong sum = new VeryLong(summands[0]);
            for (int i=1; i<summands.Count; i++)
            {
                sum = sum.Add(new VeryLong(summands[i]));
            }

            return sum;
        }

        public VeryLong Multiply(VeryLong other)
        {
            int numberDecimalPlaces = GetDecimalPlaces();
            int numberDecimalPlacesOther = other.GetDecimalPlaces();
            int resultDecialPlaces = numberDecimalPlaces + numberDecimalPlacesOther;

            other = RemoveDecimalPlaces(other);
            string integerStringCopy = _integerString;
            _integerString = _integerString.Replace(".", "");

            List<string> multiplicationResults = new List<string>();
            string multiplicationResult = GetZeros(1);
            int currentLastDigit = 0;
            int currentLastDigitOther = 0;
            int resultDigit = 0;
            int behalte = 0;
            int mult = 0;
            int indexOther = 0;
            int index = 0;
           
            while (Length() > index)
            {
                indexOther = 0;
                behalte = 0;
                multiplicationResult = GetZeros(index);

                while (other.Length() > indexOther || behalte != 0)
                {
                    currentLastDigit = int.Parse(GetLastDigit(index));
                    currentLastDigitOther = int.Parse(other.GetLastDigit(indexOther));
                    mult = currentLastDigit * currentLastDigitOther + behalte;
                    behalte = mult / 10;
                    resultDigit = mult % 10;
                    multiplicationResult = multiplicationResult.Insert(0, resultDigit.ToString());
                    indexOther++;
                }

                index++;
                multiplicationResults.Add(multiplicationResult);
            }
            
            VeryLong mainResult = VeryLong.AddSummands(multiplicationResults);
            
            mainResult.SetDecimalPlaces(resultDecialPlaces);
            mainResult.RemoveLeadingZeros();

            _integerString = integerStringCopy;
            return mainResult;
        }

        private void SetDecimalPlaces(int decimalPlaces)
        {
            if (decimalPlaces == 0)
            {
                return;
            }

            _integerString = _integerString.Insert(Length() - decimalPlaces, ".");
            if (_integerString.StartsWith("."))
            {
                _integerString = _integerString.Insert(0, "0");
            }
        }

        public static VeryLong RemoveDecimalPlaces(VeryLong number)
        {
            return new VeryLong(number.ToString().Replace(".", ""));
        }

        public VeryLong DivideBy(VeryLong divisor, out VeryLong remainder)
        {
            string dividendString = "";
            string divisorString = divisor.ToString();
            string quotientDigit = "";
            string quotient = "";
            string mult = "";
            string diff = "";

            for (int i = 0; i < Length(); i++)
            {
                dividendString += GetFirstDigit(i);
                dividendString = VeryLong.RemoveLeadingZeros(dividendString);
                quotientDigit = DivideSimple(dividendString, divisorString);
                quotient += quotientDigit;
                mult = (new VeryLong(quotientDigit).Multiply(new VeryLong(divisorString))).ToString();
                diff = (new VeryLong(dividendString).Subtract(new VeryLong(mult))).ToString();
                dividendString = diff;
            }

            VeryLong quotientResult = new VeryLong(quotient);
            remainder = new VeryLong(diff);
            quotientResult.RemoveLeadingZeros();
            return quotientResult;
        }

        public VeryLong DivideBy(VeryLong divisor, int numberOfDigits)
        {
            int numberDecimalPlacesDivisor = divisor.GetDecimalPlaces();
            divisor = RemoveDecimalPlaces(divisor);

            FillUpDecimalPlacesWithZero(numberOfDigits + numberDecimalPlacesDivisor);

            string dividendString = "";
            string divisorString = divisor.ToString();
            string quotientDigit = "";
            string quotient = "";
            string mult = "";
            string diff = "";

            for (int i = 0; i < Length(); i++)
            {
                if (GetFirstDigit(i) == ".")
                {
                    quotient += ".";
                    continue;
                }

                dividendString += GetFirstDigit(i);
                dividendString = VeryLong.RemoveLeadingZeros(dividendString);
                quotientDigit = DivideSimple(dividendString, divisorString);
                quotient += quotientDigit;
                mult = (new VeryLong(quotientDigit).Multiply(new VeryLong(divisorString))).ToString();
                diff = (new VeryLong(dividendString).Subtract(new VeryLong(mult))).ToString();
                dividendString = diff;
            }

            VeryLong quotientResult = new VeryLong(quotient);
            int resultDecimalPlaces = quotientResult.GetDecimalPlaces();
            quotientResult = RemoveDecimalPlaces(quotientResult);
            quotientResult.SetDecimalPlaces(resultDecimalPlaces - numberDecimalPlacesDivisor);
           
            quotientResult.RemoveLeadingZeros();
            quotientResult.LimitPrecisionTo(numberOfDigits);
            return quotientResult;
        }

        /// <summary>
        /// The result of DivideSimple ist 0, 1, 2, ..., 9
        /// </summary>
        public static string DivideSimple(string dividendString, string divisorString)
        {
            for (int tryQuotient = 9; tryQuotient > 0; tryQuotient--)
            {
                VeryLong mult = new VeryLong(divisorString).Multiply(new VeryLong(tryQuotient.ToString()));
                if (new VeryLong(dividendString).IsLargerOrEqual(mult))
                {
                    return tryQuotient.ToString();
                }
            }

            return "0";
        }

        public bool IsLargerOrEqual(VeryLong other)
        {
            string firstInteger = GetInteger();
            string otherInteger = other.GetInteger();

            // compare integers (number in front of decimal point)
            if (firstInteger.Length > otherInteger.Length)
            {
                return true;
            }
            else if (firstInteger.Length < otherInteger.Length)
            {
                return false;
            }
            else
            {
                int isLargerOrEqual = firstInteger.CompareTo(otherInteger.ToString());
                if (isLargerOrEqual == -1) // other is smaller
                {
                    return false;
                }
                else if (isLargerOrEqual == 1) // other is larger
                {
                    return true;
                }
                else // integers are equal --> compare decimal digits
                {
                    string decimalDigits = GetDecimalDigits();
                    string otherDecimalDigits = other.GetDecimalDigits();
                    isLargerOrEqual = decimalDigits.CompareTo(otherDecimalDigits);
                    if (isLargerOrEqual == -1) // other is smaller
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public string GetInteger()
        {
            int decimalPlaces = GetDecimalPlaces();
            if (decimalPlaces == 0)
            {
                return _integerString;
            }
            else
            {
                return _integerString.Substring(0, Length() - decimalPlaces - 1);
            }
        }

        public string GetDecimalDigits()
        {
            int decimalPlaces = GetDecimalPlaces();
            if (decimalPlaces == 0)
            {
                return "0";
            }
            else
            {
                return _integerString.Substring(Length() - decimalPlaces, decimalPlaces);
            }
        }

        public VeryLong Abs()
        {
            if (_integerString.StartsWith("-"))
            {
                return new VeryLong(ToString().Substring(1));
            }
            else
            {
                return new VeryLong(ToString());
            }
        }

        public static string GetZeros(int numberZeros)
        {
            string zeroes = "";
            for (int i = 0; i<numberZeros; i++)
            {
                zeroes += "0";
            }

            return zeroes;
        }

        public override string ToString()
        {
            return _integerString;
        }

        public string GetLastDigit(int index) // 0 -> last digit
        {
            int length = _integerString.Length;
            if (length > index)
            {
                return _integerString[length - 1 - index].ToString();
            }
            else
            {
                return "0";
            }
        }

        public string GetFirstDigit(int index) // 0 -> first digit
        {
            int length = _integerString.Length;
            if (length > index)
            {
                return _integerString[index].ToString();
            }
            else
            {
                return "0";
            }
        }

        public int Length()
        {
            return _integerString.Length;
        }

        private int GetDecimalPlaces()
        {
            if (_integerString.Contains("."))
            {
                int indexOfDot = _integerString.IndexOf('.');
                return _integerString.Length - indexOfDot - 1;
            }
            else
            {
                return 0;
            }
        }

        public void LimitPrecisionTo(int numberOfDigits)
        {
            int decimalPlaces = GetDecimalPlaces();
            if (numberOfDigits < decimalPlaces)
            {
                int indexOfDot = _integerString.IndexOf(".");
                _integerString = _integerString.Remove(indexOfDot + numberOfDigits + 1);
            }
        }
    }
}
