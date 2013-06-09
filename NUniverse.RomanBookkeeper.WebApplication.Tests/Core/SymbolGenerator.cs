using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NUniverse.RomanBookkeeper.WebApplication.Tests.Core
{
    public static class SymbolGenerator
    {
        public static IEnumerable<string> GetNullEmptyAndWhitespaceStrings()
        {
            yield return null;
            yield return string.Empty;

            for (int index = char.MinValue; index <= char.MaxValue; index++)
            {
                char character = Convert.ToChar(index);

                if (char.IsWhiteSpace(character))
                {
                    yield return character.ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        public static IEnumerable<string> GetNonRomanSymbols()
        {
            foreach (int digit in Enumerable.Range(0, 10))
            {
                yield return digit.ToString(CultureInfo.InvariantCulture);
            }

            foreach (char letter in "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLowerInvariant())
            {
                yield return letter.ToString(CultureInfo.InvariantCulture);
            }
        }

        public static IEnumerable<string> GetRomanBasicSymbols()
        {
            return "IVXLCDM".ToUpperInvariant().Select(letter => letter.ToString(CultureInfo.InvariantCulture));
        }

        public static IEnumerable<string> GenerateValidRomanNumerals()
        {
            return new[] {"MMXIII"};
        }
    }
}