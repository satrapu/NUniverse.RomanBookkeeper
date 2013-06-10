using System.Web.Mvc;
using NUniverse.RomanBookkeeper.WebApplication.Arithmetics;
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
                //bool hasErrors = false;
                //RomanNumber leftOperand;
                //RomanNumber rightOperand;

                //if (!RomanNumber.TryParse(model.LeftOperand, out leftOperand))
                //{
                //    ModelState.AddModelError("LeftOperand", string.Format("'{0}' is not a valid Roman number", model.LeftOperand));
                //    hasErrors = true;
                //}

                //if (!RomanNumber.TryParse(model.RightOperand, out rightOperand))
                //{
                //    ModelState.AddModelError("RightOperand", string.Format("'{0}' is not a valid Roman number", model.RightOperand));
                //    hasErrors = true;
                //}
                Abacus abacus = null;

                switch (model.NumeralSystem)
                {
                    case "Roman":
                        abacus = new RomanAbacus(100); // Roman abacus wil be able to handle hundreds of thousands
                        break;
                    case "Arabic":
                        abacus = new ArabicAbacus(6); // Arabic abacus wil be able to handle hundreds of thousands
                        break;
                    default:
                        ModelState.AddModelError("NumeralSytem", string.Format("'{0}' is not a registered numberal system", model.NumeralSystem));
                        break;
                }

                if (abacus != null)
                {
                    ViewBag.SummingResult = abacus.PerformSumming(model.LeftOperand, model.RightOperand);
                }
            }

            InitSummingView();
            return View("Index", model);
        }

        private void InitSummingView()
        {
            ViewBag.Title = "Summing";
            ViewBag.Message = "Perform summing of two numbers";
        }
    }
}