using System.Web.Mvc;

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
            ViewBag.Title = "Summing";
            ViewBag.Message = "Perform summing of two Roman numbers";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            ViewBag.Message = "This web application has been developed by Bogdan Marian";
            return View();
        }
    }
}