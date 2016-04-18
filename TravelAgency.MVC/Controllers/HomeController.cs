using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Travel Agency application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "If you have questions or comments don't hesitate to drop me a note.";

            return View();
        }
    }
}