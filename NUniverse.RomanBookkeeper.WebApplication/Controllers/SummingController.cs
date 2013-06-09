using System.Web.Mvc;
using NUniverse.RomanBookkeeper.WebApplication.Core;
using NUniverse.RomanBookkeeper.WebApplication.Models;

namespace NUniverse.RomanBookkeeper.WebApplication.Controllers
{
    public class SummingController : Controller
    {
        public ActionResult Index()
        {
            InitSummingView();
            return View();
        }

        public ActionResult DoSumming(SummingModel model)
        {
            if (ModelState.IsValid)
            {
                bool hasErrors = false;
                RomanNumber leftOperand;
                RomanNumber rightOperand;

                if (!RomanNumber.TryParse(model.LeftOperand, out leftOperand))
                {
                    ModelState.AddModelError("LeftOperand", string.Format("'{0}' is not a valid Roman number", model.LeftOperand));
                    hasErrors = true;
                }

                if (!RomanNumber.TryParse(model.RightOperand, out rightOperand))
                {
                    ModelState.AddModelError("RightOperand", string.Format("'{0}' is not a valid Roman number", model.RightOperand));
                    hasErrors = true;
                }

                if (!hasErrors)
                {
                    RomanNumber result = leftOperand.SumWith(rightOperand);
                    ViewBag.SummingResult = result.Value;
                }
            }

            InitSummingView();
            return View("Index", model);
        }

        private void InitSummingView()
        {
            ViewBag.Title = "Summing";
            ViewBag.Message = "Perform summing of two Roman numbers";
        }
    }
}