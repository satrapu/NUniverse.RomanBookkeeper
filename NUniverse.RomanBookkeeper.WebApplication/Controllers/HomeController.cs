﻿using System.Web.Mvc;

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
    }
}