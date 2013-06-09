using System.Web.Mvc;
using NUnit.Framework;
using NUniverse.RomanBookkeeper.WebApplication.Controllers;

namespace NUniverse.RomanBookkeeper.WebApplication.Tests.Controllers
{
    [TestFixture]
    public class AboutControllerTests
    {
        [Test]
        public void Index_ReturnsView()
        {
            AboutController aboutController = new AboutController();
            ViewResult viewResult = (ViewResult)aboutController.Index();
            Assert.AreEqual("About", viewResult.ViewBag.Title);
        }
    }
}