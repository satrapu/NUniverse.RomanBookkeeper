﻿using System.Web.Mvc;
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
            ViewResult viewResult = (ViewResult)homeController.Index();
            Assert.AreEqual("Home", viewResult.ViewBag.Title);
        }
    }
}