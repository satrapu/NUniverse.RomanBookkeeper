using System.Web.Mvc;
using NUnit.Framework;
using NUniverse.RomanBookkeeper.WebApplication.Controllers;

namespace NUniverse.RomanBookkeeper.WebApplication.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index_ReturnsView()
        {
            HomeController homeController = new HomeController();
            ViewResult viewResult = homeController.Index() as ViewResult;
            Assert.AreEqual("Home", viewResult.ViewBag.Title);
        }

        [Test]
        public void Summing_ReturnsView()
        {
            HomeController homeController = new HomeController();
            ViewResult viewResult = homeController.Summing() as ViewResult;
            Assert.AreEqual("Summing", viewResult.ViewBag.Title);
        }

        [Test]
        public void Contact_ReturnsView()
        {
            HomeController homeController = new HomeController();
            ViewResult viewResult = homeController.Contact() as ViewResult;
            Assert.AreEqual("Contact", viewResult.ViewBag.Title);
        }
    }
}