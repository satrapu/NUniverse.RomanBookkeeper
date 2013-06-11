using System.Web.Mvc;
using NUnit.Framework;
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
        public void DoSumming_UsingMissingLeftOperand_DisplaysError()
        {
            SummingModel summingModel = new SummingModel();
            SummingController summingController = new SummingController();
            summingController.DoSumming(summingModel);
            Assert.IsTrue(summingController.ModelState.ContainsKey("LeftOperand"));
        }

        [Test]
        public void DoSumming_UsingInvalidRomanNumberAsLeftOperand_DisplaysError()
        {
            SummingModel summingModel = new SummingModel {LeftOperand = "IIII", RightOperand = "MD"};
            SummingController summingController = new SummingController();
            summingController.DoSumming(summingModel);
            Assert.IsTrue(summingController.ModelState.ContainsKey("LeftOperand"));
        }

        [Test]
        public void DoSumming_UsingMissingRightOperand_DisplaysError()
        {
            SummingModel summingModel = new SummingModel {LeftOperand = "leftoperand"};
            SummingController summingController = new SummingController();
            summingController.DoSumming(summingModel);
            Assert.IsTrue(summingController.ModelState.ContainsKey("RightOperand"));
        }

        [Test]
        public void DoSumming_UsingInvalidRomanNumberAsRightOperand_DisplaysError()
        {
            SummingModel summingModel = new SummingModel {LeftOperand = "MD", RightOperand = "IIII"};
            SummingController summingController = new SummingController();
            summingController.DoSumming(summingModel);
            Assert.IsTrue(summingController.ModelState.ContainsKey("RightOperand"));
        }

        [Test]
        public void DoSumming_UsingRomanNumbersAsLeftAndRightOperand_DisplaysSummingResult()
        {
            SummingModel summingModel = new SummingModel {LeftOperand = "MD", RightOperand = "LX"};
            SummingController summingController = new SummingController();
            ViewResult viewResult = (ViewResult) summingController.DoSumming(summingModel);
            Assert.AreEqual("MDLX", viewResult.ViewBag.SummingResult);
        }
    }
}