using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace NUniverse.RomanBookkeeper.WebApplication.Arithmetics
{
    public class RomanNumber
    {
        // http://stackoverflow.com/questions/267399/how-do-you-match-only-valid-roman-numerals-with-a-regular-expression
        private static readonly Regex romanNumberRegex = new Regex("^M{0,}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
        private const string notAValidRomanNumberErrorMessage = "<{0}> does not represent a valid Roman number";
        private static readonly RomanNumber one = new RomanNumber("I");
        private static readonly RomanNumber four = new RomanNumber("IV");
        private static readonly RomanNumber five = new RomanNumber("V");
        private static readonly RomanNumber nine = new RomanNumber("IX");
        private static readonly RomanNumber ten = new RomanNumber("X");
        private static readonly RomanNumber fourty = new RomanNumber("XL");
        private static readonly RomanNumber fifty = new RomanNumber("L");
        private static readonly RomanNumber ninety = new RomanNumber("XC");
        private static readonly RomanNumber oneHundred = new RomanNumber("C");
        private static readonly RomanNumber fourHundred = new RomanNumber("CD");
        private static readonly RomanNumber fiveHundred = new RomanNumber("D");
        private static readonly RomanNumber nineHundred = new RomanNumber("CM");
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

        public static RomanNumber Four
        {
            get
            {
                return four;
            }
        }

        public static RomanNumber Five
        {
            get
            {
                return five;
            }
        }

        public static RomanNumber Nine
        {
            get
            {
                return nine;
            }
        }

        public static RomanNumber Ten
        {
            get
            {
                return ten;
            }
        }

        public static RomanNumber Fourty
        {
            get
            {
                return fourty;
            }
        }

        public static RomanNumber Fifty
        {
            get
            {
                return fifty;
            }
        }

        public static RomanNumber Ninety
        {
            get
            {
                return ninety;
            }
        }

        public static RomanNumber OneHundred
        {
            get
            {
                return oneHundred;
            }
        }

        public static RomanNumber FourHundred
        {
            get
            {
                return fourHundred;
            }
        }

        public static RomanNumber FiveHundred
        {
            get
            {
                return fiveHundred;
            }
        }

        public static RomanNumber NineHundred
        {
            get
            {
                return nineHundred;
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

            result = new RomanNumber { Value = input };
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

        //Summing algorithm is based on this article: http://mathforum.org/dr.math/faq/faq.roman.html
        private RomanNumber SumWith_Solution1(RomanNumber otherRomanNumber)
        {
            if (otherRomanNumber == null)
            {
                throw new ArgumentNullException("otherRomanNumber");
            }

            int thousandCounter = 0;
            int fiveHundredCounter = 0;
            int hundredCounter = 0;
            int fiftyCounter = 0;
            int tenCounter = 0;
            int fiveCounter = 0;
            int oneCounter = 0;

            foreach (string symbol in Value.Select(symbol => symbol.ToString(CultureInfo.InvariantCulture)))
            {
                if (symbol.Equals(oneThousand.Value, StringComparison.InvariantCulture))
                {
                    thousandCounter++;
                }
                else if (symbol.Equals(nineHundred.Value, StringComparison.InvariantCulture))
                {
                    hundredCounter += 9;
                }
                else if (symbol.Equals(fiveHundred.Value, StringComparison.InvariantCulture))
                {
                    fiveHundredCounter++;
                }
                else if (symbol.Equals(fourHundred.Value, StringComparison.InvariantCulture))
                {
                    hundredCounter += 4;
                }
                else if (symbol.Equals(oneHundred.Value, StringComparison.InvariantCulture))
                {
                    hundredCounter++;
                }
                else if (symbol.Equals(ninety.Value, StringComparison.InvariantCulture))
                {
                    tenCounter += 9;
                }
                else if (symbol.Equals(fifty.Value, StringComparison.InvariantCulture))
                {
                    fiftyCounter++;
                }
                else if (symbol.Equals(fourty.Value, StringComparison.InvariantCulture))
                {
                    tenCounter += 4;
                }
                else if (symbol.Equals(ten.Value, StringComparison.InvariantCulture))
                {
                    tenCounter++;
                }
                else if (symbol.Equals(nine.Value, StringComparison.InvariantCulture))
                {
                    oneCounter += 9;
                }
                else if (symbol.Equals(five.Value, StringComparison.InvariantCulture))
                {
                    fiveCounter++;
                }
                else if (symbol.Equals(four.Value, StringComparison.InvariantCulture))
                {
                    oneCounter += 4;
                }
                else if (symbol.Equals(one.Value, StringComparison.InvariantCulture))
                {
                    oneCounter++;
                }
            }

            string result = string.Concat(new string('M', thousandCounter),
                                          new string('D', fiveHundredCounter),
                                          new string('C', thousandCounter),
                                          new string('L', fiftyCounter),
                                          new string('X', tenCounter),
                                          new string('V', fiveCounter),
                                          new string('I', oneCounter));
            return new RomanNumber(string.Concat(Value, otherRomanNumber.Value));
        }

        // other solution: http://mathdude.quickanddirtytips.com/how-to-add-and-subtract-roman-numerals.aspx
        public string SumWith_Solution2(RomanNumber otherRomanNumber)
        {
            if (otherRomanNumber == null)
            {
                throw new ArgumentNullException("otherRomanNumber");
            }

            // phase 1: concatenate the 2 numbers
            string thousand = "";
            string fiveHundred = "";
            string hundred = "";
            string fifty = "";
            string ten = "";
            string five = "";
            string one = "";

            //phase 2: sort symbols descending e.g. M, D, C, L, X, V, I
            foreach (char symbol in string.Concat(Value, otherRomanNumber.Value))
            {
                switch (symbol)
                {
                    case 'M':
                        thousand = string.Concat(thousand, symbol);
                        break;
                    case 'D':
                        fiveHundred = string.Concat(fiveHundred, symbol);
                        break;
                    case 'C':
                        hundred = string.Concat(hundred, symbol);
                        break;
                    case 'L':
                        fifty = string.Concat(fifty, symbol);
                        break;
                    case 'X':
                        ten = string.Concat(ten, symbol);
                        break;
                    case 'V':
                        five = string.Concat(five, symbol);
                        break;
                    case 'I':
                        one = string.Concat(one, symbol);
                        break;
                }
            }

            string result = string.Concat(thousand, fiveHundred, hundred, fifty, ten, five, one);

            // phase 3: reduce
            return result;
        }

        public static string Sum(RomanNumber left, RomanNumber right)
        {
            IDictionary<char, string> buckets = new Dictionary<char, string>();
            buckets.Add('M', string.Empty);
            buckets.Add('D', string.Empty);
            buckets.Add('C', string.Empty);
            buckets.Add('L', string.Empty);
            buckets.Add('X', string.Empty);
            buckets.Add('V', string.Empty);
            buckets.Add('I', string.Empty);

            string concat = left.Value + right.Value;
            int index = 0;

            while (index < concat.Length)
            {
                char symbol = concat.ElementAt(index);

                switch (symbol)
                {
                    case 'M':
                    case 'D':
                    case 'L':
                    case 'V':
                        buckets[symbol] += symbol;
                        break;
                    case 'C':
                        if (index < concat.Length - 1 && concat.ElementAt(index + 1) == 'D')
                        {
                            buckets[symbol] += "CCCC";
                            index++;
                        }
                        else
                        {
                            buckets[symbol] += symbol;
                        }

                        break;
                    case 'X':
                        if (index < concat.Length - 1 && concat.ElementAt(index + 1) == 'L')
                        {
                            buckets[symbol] += "XXXX";
                            index++;
                        }
                        else
                        {
                            buckets[symbol] += symbol;
                        }

                        break;
                    case 'I':
                        if (index < concat.Length - 1 && concat.ElementAt(index + 1) == 'V')
                        {
                            buckets[symbol] += "IIII";
                            index++;
                        }
                        else
                        {
                            buckets[symbol] += symbol;
                        }

                        break;
                }

                index++;
            }

            string normalizeResult = buckets['M'] + buckets['D'] + buckets['C'] + buckets['L'] + buckets['X'] + buckets['V'] + buckets['I'];
            return normalizeResult;
        }
    }
}