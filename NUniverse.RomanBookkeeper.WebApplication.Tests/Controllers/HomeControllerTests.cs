using System.Web.Mvc;
using NUnit.Framework;
using NUniverse.RomanBookkeeper.Core;
using NUniverse.RomanBookkeeper.WebApplication.Controllers;
using NUniverse.RomanBookkeeper.WebApplication.Models;

namespace NUniverse.RomanBookkeeper.WebApplication.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_ReturnsView()
        {
            HomeController homeController = new HomeController();
            ViewResult viewResult = (ViewResult)homeController.Index();
            Assert.AreEqual("Home", viewResult.ViewBag.Title);
        }

        [Test]
        public void Summing_ReturnsView()
        {
            HomeController homeController = new HomeController();
            ViewResult viewResult = (ViewResult)homeController.Summing();
            Assert.AreEqual("Summing", viewResult.ViewBag.Title);
        }

        [Test]
        public void Contact_ReturnsView()
        {
            HomeController homeController = new HomeController();

            ViewResult viewResult = (ViewResult)homeController.Contact();

            Assert.AreEqual("Contact", viewResult.ViewBag.Title);
        }

        [Test]
        public void DoSumming_UsingValidModule_ReturnsValidResult()
        {
            RomanNumber leftNumber = new RomanNumber("MMCDLVII");
            RomanNumber rightNumber = new RomanNumber("MCMIII");
            RomanNumber expectedSummingResult = leftNumber.SumWith(rightNumber);
            SummingModel summingModel = new SummingModel { LeftOperand = leftNumber.Value, RightOperand = rightNumber.Value };
            HomeController homeController = new HomeController();
            ViewResult viewResult = (ViewResult)homeController.DoSumming(summingModel);
            Assert.AreEqual(expectedSummingResult.Value, viewResult.ViewBag.SummingResult);
        }
    }
}