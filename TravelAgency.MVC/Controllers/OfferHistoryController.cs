using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelAgency.BLL.BLL;
using TravelAgency.BLL.Util;
using TravelAgency.MVC.Util;
using TravelAgency.MVC.ViewModels;

namespace TravelAgency.MVC.Controllers
{
    public class OfferHistoryController : Controller
    {
        private TravelAgencyService service = new TravelAgencyService();

        // GET: OfferHistory
        [Authorize]
        public ActionResult Index()
        {
            int? userId = AuthorizeUtil.GetUserId(service, User);
            if (userId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var history = service.GetOfferHistory(userId.Value);
            return View(history);
        }
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int? userId = AuthorizeUtil.GetUserId(service, User);
            if (userId == null)
                return RedirectToAction("Login", "Account");
            var history = service.GetOfferHistory(userId.Value, id.Value);
            var attractions = service.GetAttractionHistoryList(userId.Value, id.Value);
            return View(new OfferHistoryDetails { History = history, Attractions = attractions });
        }
        
        [Authorize]
        public ActionResult AttractionDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int? userId = AuthorizeUtil.GetUserId(service, User);
            if (userId == null)
                return RedirectToAction("Login", "Account");
            var history = service.GetAttractionHistory(userId.Value, id.Value);
            return View(history);
        }
    }
}