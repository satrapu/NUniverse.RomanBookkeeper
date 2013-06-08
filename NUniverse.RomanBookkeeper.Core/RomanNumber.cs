using System;
using System.Text.RegularExpressions;

namespace NUniverse.RomanBookkeeper.Core
{
    public class RomanNumber
    {
        // http://stackoverflow.com/questions/267399/how-do-you-match-only-valid-roman-numerals-with-a-regular-expression
        private static readonly Regex romanNumberRegex = new Regex("^M{0,}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");

        private RomanNumber()
        {
        }

        public RomanNumber(string value)
        {
            RomanNumber romanNumber;

            if (!TryParse(value, out romanNumber))
            {
                throw new ArgumentException("{0} does not represent a valid roman number", "value");
            }

            Value = romanNumber.Value;
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

            result = new RomanNumber { Value = input };
            return true;
        }
    }
}