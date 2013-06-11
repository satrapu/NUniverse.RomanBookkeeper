using System;
using NUnit.Framework;
using NUniverse.RomanBookkeeper.WebApplication.Arithmetics;

namespace NUniverse.RomanBookkeeper.WebApplication.Tests.Core
{
    [TestFixture]
    public class RomanNumberTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_UsigNullEmptyOrWhitespaceStringAsParameter_ThrowsException(
                [ValueSource(typeof(SymbolGenerator), "GetNullEmptyAndWhitespaceStrings")] string nullEmptyOrWhitespaceString)
        {
            RomanNumber romanNumber = new RomanNumber(nullEmptyOrWhitespaceString);
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

        [Test]
        public void TryParse_UsingValidRomanNumeral_ReturnsTrue(
                [ValueSource(typeof(SymbolGenerator), "GenerateValidRomanNumerals")] string romanNumberAsString)
        {
            RomanNumber romanNumber;
            bool parseResult = RomanNumber.TryParse(romanNumberAsString, out romanNumber);
            Assert.IsTrue(parseResult);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_UsingNonRomanSymbol_ReturnsFalse([ValueSource(typeof(SymbolGenerator), "GetNonRomanSymbols")] string nonRomanSymbol)
        {
            RomanNumber.Parse(nonRomanSymbol);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_UsigNullEmptyOrWhitespaceStringAsParameter_ThrowsException(
                [ValueSource(typeof(SymbolGenerator), "GetNullEmptyAndWhitespaceStrings")] string nullEmptyOrWhitespaceString)
        {
            RomanNumber.Parse(nullEmptyOrWhitespaceString);
        }

        [Test]
        public void Parse_UsingRomanBasicSymbol_ReturnsRomanNumber(
                [ValueSource(typeof(SymbolGenerator), "GetRomanBasicSymbols")] string basicRomanSymbol)
        {
            RomanNumber romanNumber = RomanNumber.Parse(basicRomanSymbol);
            Assert.IsNotNull(romanNumber);
        }
    }
}