using System;
using NUnit.Framework;
using NUniverse.RomanBookkeeper.WebApplication.Arithmetics;

namespace NUniverse.RomanBookkeeper.WebApplication.Tests.Arithmetics
{
    [TestFixture]
    public class RomanRodeTests
    {
        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Constructor_UsingNullEmptyOrWhitespaceSymbol_ThrowsException(
                [ValueSource(typeof (SymbolGenerator), "GetNullEmptyAndWhitespaceStrings")] string nullEmptyOrWhitespaceString)
        {
            RomanRode romanRode = new RomanRode(nullEmptyOrWhitespaceString, null, null);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Constructor_UsingInvalidRomanSymbol_ThrowsException()
        {
            RomanRode romanRode = new RomanRode("123", null, null);
        }

        [Test]
        public void Constructor_UsingAValidRomanSymbol_DoesNotThrowsException(
                [ValueSource(typeof (SymbolGenerator), "GetRomanBasicSymbols")] string romanSymbol)
        {
            RomanRode romanRode = new RomanRode(romanSymbol, null, null);
        }
    }
}