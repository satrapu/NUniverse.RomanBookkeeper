using System.Web.Mvc;

namespace NUniverse.RomanBookkeeper.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
    }
}