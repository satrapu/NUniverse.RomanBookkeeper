using System.Web.Mvc;
using NUnit.Framework;
using NUniverse.RomanBookkeeper.WebApplication.Controllers;

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
    }
}