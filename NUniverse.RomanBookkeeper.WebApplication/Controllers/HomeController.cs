using System.Web.Mvc;

namespace NUniverse.RomanBookkeeper.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "";
            return View();
        }

        public ActionResult Summing()
        {
            //throw new Exception("BOOOM!", new Exception("Root Cause ;)"));
            ViewBag.Message = "Perform summing of two Roman or Arabic numbers";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "This web application has been developed by Bogdan Marian";
            return View();
        }
    }
}