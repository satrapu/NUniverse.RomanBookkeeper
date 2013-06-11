using System;
using NUnit.Framework;
using NUniverse.RomanBookkeeper.WebApplication.Arithmetics;

namespace NUniverse.RomanBookkeeper.WebApplication.Tests.Arithmetics
{
    [TestFixture]
    public class BeadTests
    {
        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void Constructor_UsingInvalidSymbol_ThrowsException(
                [ValueSource(typeof (SymbolGenerator), "GetNullEmptyAndWhitespaceStrings")] string nullEmptyOrWhitespaceString)
        {
            Bead bead = new Bead(nullEmptyOrWhitespaceString);
        }

        [Test]
        public void Constructor_UsingValidSymbol_DoesNotThrowException()
        {
            Bead bead = new Bead("symbol");
        }
    }
}