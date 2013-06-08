using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NUniverse.RomanBookkeeper.Core.Tests
{
    public static class SymbolGenerator
    {
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
            return "IVXLCDM".ToUpper().Select(letter => letter.ToString(CultureInfo.InvariantCulture));
        }
    }
}