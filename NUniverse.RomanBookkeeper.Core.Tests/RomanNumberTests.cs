using System;
using NUnit.Framework;

namespace NUniverse.RomanBookkeeper.Core.Tests
{
    [TestFixture]
    public class RomanNumberTests
    {
        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Constructor_UsigNullEmptyOrWhitespaceStringAsParameter_ThrowsException(
                [ValueSource(typeof (SymbolGenerator), "GetNullEmptyAndWhitespaceStrings")] string nullEmptyOrWhitespaceString)
        {
            RomanNumber romanNumber = new RomanNumber(nullEmptyOrWhitespaceString);
        }

        [Test]
        public void TryParse_UsingNonRomanSymbol_ReturnsFalse([ValueSource(typeof (SymbolGenerator), "GetNonRomanSymbols")] string nonRomanSymbol)
        {
            RomanNumber romanNumber;
            bool parseResult = RomanNumber.TryParse(nonRomanSymbol, out romanNumber);
            Assert.IsFalse(parseResult);
        }

        [Test]
        public void TryParse_UsingRomanBasicSymbol_ReturnsTrue([ValueSource(typeof (SymbolGenerator), "GetRomanBasicSymbols")] string basicRomanSymbol)
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
        public void TryParse_UsingValidRomanNumeral_ReturnsTrue([ValueSource(typeof (SymbolGenerator), "GenerateValidRomanNumerals")] string romanNumberAsString)
        {
            RomanNumber romanNumber;
            bool parseResult = RomanNumber.TryParse(romanNumberAsString, out romanNumber);
            Assert.IsTrue(parseResult);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Parse_UsingNonRomanSymbol_ReturnsFalse([ValueSource(typeof (SymbolGenerator), "GetNonRomanSymbols")] string nonRomanSymbol)
        {
            RomanNumber.Parse(nonRomanSymbol);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Parse_UsigNullEmptyOrWhitespaceStringAsParameter_ThrowsException(
                [ValueSource(typeof (SymbolGenerator), "GetNullEmptyAndWhitespaceStrings")] string nullEmptyOrWhitespaceString)
        {
            RomanNumber.Parse(nullEmptyOrWhitespaceString);
        }

        [Test]
        public void Parse_UsingRomanBasicSymbol_ReturnsRomanNumber([ValueSource(typeof (SymbolGenerator), "GetRomanBasicSymbols")] string basicRomanSymbol)
        {
            RomanNumber romanNumber = RomanNumber.Parse(basicRomanSymbol);
            Assert.IsNotNull(romanNumber);
        }

        [Test]
        public void Parse_UsingIAsParameter_ReturnsI()
        {
            RomanNumber one = RomanNumber.Parse("I");
            Assert.AreEqual(RomanNumber.One.Value, one.Value);
        }

        [Test]
        public void Parse_UsingVAsParameter_ReturnsV()
        {
            RomanNumber five = RomanNumber.Parse("V");
            Assert.AreEqual(RomanNumber.Five.Value, five.Value);
        }

        [Test]
        public void Parse_UsingXAsParameter_ReturnsX()
        {
            RomanNumber ten = RomanNumber.Parse("X");
            Assert.AreEqual(RomanNumber.Ten.Value, ten.Value);
        }

        [Test]
        public void Parse_UsingLAsParameter_ReturnsL()
        {
            RomanNumber fifty = RomanNumber.Parse("L");
            Assert.AreEqual(RomanNumber.Fifty.Value, fifty.Value);
        }

        [Test]
        public void Parse_UsingCAsParameter_ReturnsC()
        {
            RomanNumber oneHundred = RomanNumber.Parse("C");
            Assert.AreEqual(RomanNumber.OneHundred.Value, oneHundred.Value);
        }

        [Test]
        public void Parse_UsingDAsParameter_ReturnsD()
        {
            RomanNumber fiveHundred = RomanNumber.Parse("D");
            Assert.AreEqual(RomanNumber.FiveHundred.Value, fiveHundred.Value);
        }

        [Test]
        public void Parse_UsingMAsParameter_ReturnsM()
        {
            RomanNumber oneThousand = RomanNumber.Parse("M");
            Assert.AreEqual(RomanNumber.OneThousand.Value, oneThousand.Value);
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void SumWith_UsigNullAsParameter_ThrowsException()
        {
            RomanNumber.OneThousand.SumWith(null);
        }

        [Test]
        public void SumWith_UsigRomanNumber_ReturnsRomanNumber()
        {
            RomanNumber expectedResult = new RomanNumber("MMMDCCCLXXIV"); //3874
            RomanNumber leftOperand = new RomanNumber("MMDLIV"); //2554
            RomanNumber rightOperand = new RomanNumber("MCCCXX"); //1320
            RomanNumber actualResult = leftOperand.SumWith(rightOperand);
            Assert.AreEqual(expectedResult.Value, actualResult.Value);
        }
    }
}