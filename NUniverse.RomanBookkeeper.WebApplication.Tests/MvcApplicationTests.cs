using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NUnit.Framework;

namespace NUniverse.RomanBookkeeper.WebApplication.Tests
{
    [TestFixture]
    public class MvcApplicationTests
    {
        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void RegisterBundles()
        {
            BundleTable.MapPathMethod = path => path;
            MvcApplication.RegisterBundles(BundleTable.Bundles);
        }

        [Test]
        public void RegisterRoutes()
        {
            MvcApplication.RegisterRoutes(RouteTable.Routes);
        }

        [Test]
        public void RegisterGlobalFilters()
        {
            MvcApplication.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void Application_Start()
        {
            MvcApplication mvcApplication = new MvcApplication();
            mvcApplication.Application_Start();
        }
    }
}