using System.Web.Mvc;

namespace NUniverse.RomanBookkeeper.WebApplication.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "About";
            ViewBag.Message = "This web application has been developed by Bogdan Marian";
            return View();
        }
    }
}