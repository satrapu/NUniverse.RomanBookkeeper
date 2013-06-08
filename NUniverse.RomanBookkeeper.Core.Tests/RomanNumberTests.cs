using System;
using NUnit.Framework;

namespace NUniverse.RomanBookkeeper.Core.Tests
{
    [TestFixture]
    public class RomanNumberTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_UsigNullEmptyOrWhitespaceStringAsParameter_ThrowsException([Values(null, "", " ", "\t")] string input)
        {
            RomanNumber romanNumber = new RomanNumber(input);
        }

        [Test]
        public void TryParse_UsingNonRomanSymbol_ReturnsFalse([ValueSource(typeof(SymbolGenerator), "GetNonRomanSymbols")] string nonRomanSymbol)
        {
            RomanNumber romanNumber;
            bool parseResult = RomanNumber.TryParse(nonRomanSymbol, out romanNumber);
            Assert.IsFalse(parseResult);
        }

        [Test]
        public void TryParse_UsingRomanBasicSymbol_ReturnsTrue([ValueSource(typeof(SymbolGenerator), "GetRomanBasicSymbols")] string basicRomanSymbol)
        {
            RomanNumber romanNumber;
            bool parseResult = RomanNumber.TryParse(basicRomanSymbol, out romanNumber);
            Assert.IsTrue(parseResult);
        }

        [Test]
        public void TryParse_UsingGiganticAmountOfThousandRomanSymbols_ReturnsTrue()
        {
            string giganticAmountOfThousandRomanSymbol = new string('M', 99999);
            RomanNumber romanNumber;
            bool parseResult = RomanNumber.TryParse(giganticAmountOfThousandRomanSymbol, out romanNumber);
            Assert.IsTrue(parseResult);
        }
    }
}