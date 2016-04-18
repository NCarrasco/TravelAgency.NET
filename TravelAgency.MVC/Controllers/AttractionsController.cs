using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelAgency.BLL.BLL;
using TravelAgency.BLL.Util;
using TravelAgency.DAL.DAL;
using TravelAgency.MVC.Util;
using TravelAgency.MVC.ViewModels;

namespace TravelAgency.MVC.Controllers
{
    public class AttractionsController : Controller
    {
        private TravelAgencyService service = new TravelAgencyService();

        // GET: Attractions
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tAtrakcjeUslugi attraction = service.FindAttraction(id.Value);
            if (attraction == null)
            {
                return HttpNotFound();
            }
            ConfigureViewBag(attraction, AuthorizeUtil.GetUserId(service, User));
            return View(attraction);
        }
        [Authorize]
        public ActionResult Reserve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tAtrakcjeUslugi attraction = service.FindAttraction(id.Value);
            if (attraction == null)
            {
                return HttpNotFound();
            }
            int? userId = AuthorizeUtil.GetUserId(service, User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            tKlient client = service.GetClientWithPersons(userId.Value);
            int personId = client.tOsoby.First().IDOsoby;
            ConfigureViewBag(attraction, userId);
            return View(new ReservationModel { Attraction = attraction, ClientWithPersons = client, PersonId = personId });
        }

        private void ConfigureViewBag(tAtrakcjeUslugi attraction, int? userId)
        {
            ViewBag.CanReserve = service.IsOfferReserved(attraction.IDOferty, userId);
            ViewBag.IsReserved = IsAttractionReserved(attraction.IDAtrakcjiUslugi);
        }

        private bool IsAttractionReserved(int attrId)
        {
            int? userId = AuthorizeUtil.GetUserId(service, User);
            if (userId == null)
                return false;
            tKlient client = service.GetClientWithPersons(userId.Value);
            return service.IsAttractionReserved(attrId, client.tOsoby.First().IDOsoby, userId.Value);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Reserve(ReservationModel reserveModel)
        {
            if (reserveModel == null)
            {
                return HttpNotFound();
            }
            tAtrakcjeUslugi attraction = reserveModel.Attraction;
            int? clientId = AuthorizeUtil.GetUserId(service, User);
            if (clientId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ConfigureViewBag(attraction, clientId);
            try
            {
                if (service.IsOfferReserved(attraction.IDOferty, clientId))
                {
                    if (!service.IsAttractionReserved(attraction.IDAtrakcjiUslugi, reserveModel.PersonId, clientId.Value))
                    {
                        service.ReserveAttraction(attraction.IDAtrakcjiUslugi, reserveModel.PersonId, clientId.Value);
                    }
                    ViewBag.ReserveMessage = "Attraction is reserved";
                }
                else
                {
                    ModelState.AddModelError("", "Offer is not reserved. To reserve attraction reserve offer first.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Failed to reserve offer: " + ex.Message);
            }
            return View(reserveModel);
        }
    }
}