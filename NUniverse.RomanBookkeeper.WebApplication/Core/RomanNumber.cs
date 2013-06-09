using System;
using System.Text.RegularExpressions;

namespace NUniverse.RomanBookkeeper.WebApplication.Core
{
    public class RomanNumber
    {
        // http://stackoverflow.com/questions/267399/how-do-you-match-only-valid-roman-numerals-with-a-regular-expression
        private static readonly Regex romanNumberRegex = new Regex("^M{0,}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
        private const string notAValidRomanNumberErrorMessage = "<{0}> does not represent a valid Roman number";
        private static readonly RomanNumber one = new RomanNumber("I");
        private static readonly RomanNumber five = new RomanNumber("V");
        private static readonly RomanNumber ten = new RomanNumber("X");
        private static readonly RomanNumber fifty = new RomanNumber("L");
        private static readonly RomanNumber oneHundred = new RomanNumber("C");
        private static readonly RomanNumber fiveHundred = new RomanNumber("D");
        private static readonly RomanNumber oneThousand = new RomanNumber("M");

        private RomanNumber()
        {
        }

        public RomanNumber(string input)
        {
            RomanNumber romanNumber;

            if (!TryParse(input, out romanNumber))
            {
                throw new ArgumentException(string.Format(notAValidRomanNumberErrorMessage, input), "input");
            }

            Value = romanNumber.Value;
        }

        public static RomanNumber One
        {
            get
            {
                return one;
            }
        }

        public static RomanNumber Five
        {
            get
            {
                return five;
            }
        }

        public static RomanNumber Ten
        {
            get
            {
                return ten;
            }
        }

        public static RomanNumber Fifty
        {
            get
            {
                return fifty;
            }
        }

        public static RomanNumber OneHundred
        {
            get
            {
                return oneHundred;
            }
        }

        public static RomanNumber FiveHundred
        {
            get
            {
                return fiveHundred;
            }
        }

        public static RomanNumber OneThousand
        {
            get
            {
                return oneThousand;
            }
        }

        public string Value
        {
            get;
            private set;
        }

        public static bool TryParse(string input, out RomanNumber result)
        {
            result = null;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            if (!romanNumberRegex.IsMatch(input))
            {
                return false;
            }

            result = new RomanNumber {Value = input};
            return true;
        }

        public static RomanNumber Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || !romanNumberRegex.IsMatch(input))
            {
                throw new ArgumentException(string.Format(notAValidRomanNumberErrorMessage, input), "input");
            }

            return new RomanNumber(input);
        }

        public RomanNumber SumWith(RomanNumber otherRomanNumber)
        {
            if (otherRomanNumber == null)
            {
                throw new ArgumentNullException("otherRomanNumber");
            }

            return new RomanNumber(string.Concat(Value, otherRomanNumber.Value));
        }
    }
}