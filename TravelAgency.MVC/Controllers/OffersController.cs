using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelAgency.DAL.DAL;
using PagedList;
using TravelAgency.MVC.ViewModels;
using TravelAgency.BLL.BLL;
using TravelAgency.MVC.Util;
using TravelAgency.BLL.Util;

namespace TravelAgency.MVC.Controllers
{
    public class OffersController : Controller
    {
        private TravelAgencyService service = new TravelAgencyService();

        // GET: Offers
        public ActionResult Index()
        {
            int? page = null;
            int value;
            if (int.TryParse(Request.QueryString["page"], out value))
                page = value;
            var tOferta = service.GetOffers();
            var filtering = new FilteringData(Request.QueryString, ModelState);
            tOferta = filtering.Apply(tOferta).OrderBy(i => i.DataWyjazdu);

            int pageNumber = (page ?? 1);
            IDictionary<int, bool> offerToReservedMap = service.GetOfferIdToReservedMap(AuthorizeUtil.GetUserId(service, User));
            return View(new OffersViewModel(
                tOferta.ToPagedList(pageNumber, filtering.ItemsOnPage), filtering, offerToReservedMap));
        }

        // GET: Offers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tOferta tOferta = service.FindOffer(id.Value);
            if (tOferta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IsReserved = IsOfferReserved(id.Value);
            ViewBag.AttractionReserved = new AttractionReserved(service.GetAttractionIdToReservedMap(AuthorizeUtil.GetUserId(service, User)));
            return View(tOferta);
        }

        [Authorize]
        public ActionResult Reserve(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tOferta tOferta = service.FindOffer(id.Value);
            if (tOferta == null)
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
            ViewBag.IsReserved = IsOfferReserved(id.Value);
            return View(new ReservationModel { Offer = tOferta, ClientWithPersons = client, PersonId = personId });
        }

        private bool IsOfferReserved(int offerId)
        {
            return service.IsOfferReserved(offerId, AuthorizeUtil.GetUserId(service, User));
        }

        [Authorize]
        [HttpPost]
        public ActionResult Reserve(ReservationModel reserveModel)
        {
            if (reserveModel == null)
            {
                return HttpNotFound();
            }
            tOferta offer = reserveModel.Offer;
            int? clientId = AuthorizeUtil.GetUserId(service, User);
            ViewBag.IsReserved = IsOfferReserved(offer.IDOferty);
            if (clientId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                if (!service.IsOfferReserved(offer.IDOferty, reserveModel.PersonId, clientId.Value))
                {
                    service.ReserveOffer(offer.IDOferty, reserveModel.PersonId, clientId.Value);
                }
                ViewBag.ReserveMessage = "Offer is reserved";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Failed to reserve offer: " + ex.Message);
            }
            return View(reserveModel);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
