using System.Web.Mvc;
using NUnit.Framework;
using NUniverse.RomanBookkeeper.WebApplication.Arithmetics;
using NUniverse.RomanBookkeeper.WebApplication.Controllers;
using NUniverse.RomanBookkeeper.WebApplication.Models;

namespace NUniverse.RomanBookkeeper.WebApplication.Tests.Controllers
{
    [TestFixture]
    public class SummingControllerTests
    {
        [Test]
        public void Index_ReturnsView()
        {
            SummingController summingController = new SummingController();
            ViewResult viewResult = (ViewResult) summingController.Index();
            Assert.AreEqual("Summing", viewResult.ViewBag.Title);
        }

        [Test]
        [Ignore]
        public void DoSumming_UsingValidModel_ReturnsValidResult()
        {
            RomanNumber leftNumber = new RomanNumber("MMCDLVII");
            RomanNumber rightNumber = new RomanNumber("MCMIII");
            RomanNumber expectedSummingResult = leftNumber.SumWith(rightNumber);
            SummingModel summingModel = new SummingModel {LeftOperand = leftNumber.Value, RightOperand = rightNumber.Value};
            SummingController summingController = new SummingController();
            ViewResult viewResult = (ViewResult) summingController.DoSumming(summingModel);
            Assert.AreEqual(expectedSummingResult.Value, viewResult.ViewBag.SummingResult);
        }
    }
}