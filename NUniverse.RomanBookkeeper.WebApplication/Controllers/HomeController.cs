using System.Web.Mvc;
using NUniverse.RomanBookkeeper.Core;
using NUniverse.RomanBookkeeper.WebApplication.Models;

namespace NUniverse.RomanBookkeeper.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            ViewBag.Message = "Welcome to the Roman Bookkeeper MMXIII application";
            return View();
        }

        public ActionResult Summing()
        {
            InitSummingView();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            ViewBag.Message = "This web application has been developed by Bogdan Marian";
            return View();
        }

        public ActionResult DoSumming(SummingModel model)
        {
            RomanNumber leftOperand = RomanNumber.Parse(model.LeftOperand);
            RomanNumber rightOperand = RomanNumber.Parse(model.RightOperand);
            RomanNumber result = leftOperand.SumWith(rightOperand);
            ViewBag.SummingResult = result.Value;

            InitSummingView();
            return View("Summing");
        }

        private void InitSummingView()
        {
            ViewBag.Title = "Summing";
            ViewBag.Message = "Perform summing of two Roman numbers";
        }
    }
}