using System;
using NUnit.Framework;
using NUniverse.RomanBookkeeper.WebApplication.Arithmetics;

namespace NUniverse.RomanBookkeeper.WebApplication.Tests.Arithmetics
{
    [TestFixture]
    public class RomanAbacusTests
    {
        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Constructor_UsingInvalidThousandThreshold_ThrowsException([Values(-1, 0)] int invalidThousandThreshold)
        {
            RomanAbacus romanAbacus = new RomanAbacus(invalidThousandThreshold);
        }

        [Test]
        public void Constructor_UsingValidThousandThreshold_DoesNotThrowException([Values(1, 10)] int validThousandThreshold)
        {
            RomanAbacus romanAbacus = new RomanAbacus(validThousandThreshold);
        }

        [Test]
        public void PerformSumming_UsingValidRomanNumbers_ReturnsCorrectResult()
        {
            const string leftOperand = "MMC";
            const string rightOperand = "LX";
            RomanAbacus romanAbacus = new RomanAbacus(100);
            string actualResult = romanAbacus.PerformSumming(leftOperand, rightOperand);
            Assert.AreEqual("MMCLX", actualResult);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void PerformSumming_UsingInvalidRomanNumberAsLeftOperand_ThrowsException()
        {
            const string leftOperand = "123";
            const string rightOperand = "LX";
            RomanAbacus romanAbacus = new RomanAbacus(100);
            romanAbacus.PerformSumming(leftOperand, rightOperand);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void PerformSumming_UsingInvalidRomanNumberAsRightOperand_ThrowsException()
        {
            const string leftOperand = "MMC";
            const string rightOperand = "12";
            RomanAbacus romanAbacus = new RomanAbacus(100);
            romanAbacus.PerformSumming(leftOperand, rightOperand);
        }
    }
}