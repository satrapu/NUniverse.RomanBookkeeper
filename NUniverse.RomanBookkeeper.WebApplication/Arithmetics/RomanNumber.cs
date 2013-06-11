using System;
using System.Text.RegularExpressions;

namespace NUniverse.RomanBookkeeper.WebApplication.Arithmetics
{
    public class RomanNumber
    {
        // http://stackoverflow.com/questions/267399/how-do-you-match-only-valid-roman-numerals-with-a-regular-expression
        private static readonly Regex romanNumberRegex = new Regex("^M{0,}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
        private const string notAValidRomanNumberErrorMessage = "<{0}> does not represent a valid Roman number";
        
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
    }
}