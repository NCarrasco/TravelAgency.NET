using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgency.BLL.BLL;
using TravelAgency.BLL.Util;
using TravelAgency.DAL.DAL;

namespace TravelAgency.WF
{
    public partial class ConfirmAttractionReserve : System.Web.UI.Page
    {
        private TravelAgencyService service = new TravelAgencyService();

        protected void Page_Load(object sender, EventArgs e)
        {
            int attractionId;
            bool isFound = false;
            if (int.TryParse(Request.QueryString["aid"], out attractionId))
            {
                var attraction = service.FindAttraction(attractionId);
                if (attraction != null)
                {
                    isFound = true;
                    if (IsAttractionReserved(attractionId))
                    {
                        pnlConfirm.Visible = false;
                        Message.Text = "Attraction is already reserved.";
                    }
                    else
                    {
                        pnlConfirm.Visible = true;
                        AttractionId.Value = attractionId.ToString();
                        Message.Text = String.Format("Do you really want to reserve the attraction: name: '{0}'; price: {1} ",
                            attraction.Nazwa, attraction.mCena);
                    }
                }
            }
            if (!isFound)
            {
                Message.Text = "Attraction is not found.";
            }

        }

        public override void Dispose()
        {
            base.Dispose();
            service.Dispose();
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            int attractionId;
            if (int.TryParse(AttractionId.Value, out attractionId))
            {
                var attraction = service.FindAttraction(attractionId);
                if (attraction != null)
                {
                    if (IsOfferReserved(attraction.IDAtrakcjiUslugi))
                    {
                        int? userId = AuthorizeUtil.GetUserId(service, User);
                        if (userId == null)
                        {
                            Response.Redirect("~/Account/Login");
                        }
                        pnlConfirm.Visible = false;
                        if (!IsAttractionReserved(attractionId))
                        {
                            tKlient client = service.GetClientWithPersons(userId.Value);
                            int personId = client.tOsoby.First().IDOsoby;
                            service.ReserveAttraction(attractionId, personId, client.IDKlienta);
                        }
                        Message.Text = "Offer has been reserved.";
                    }
                    else
                    {
                        pnlConfirm.Visible = false;
                        Message.Text = "Offer related to this attraction has to be reserved first.";
                    }
                }
            }
        }
        private bool IsAttractionReserved(int attractionId)
        {
            int? clientId = service.GetClientId(User.Identity.Name);
            return service.IsAttractionReserved(attractionId, clientId);
        }

        protected bool IsOfferReserved(int aid)
        {
            int? offerId = service.GetOfferIdByAttractionId(aid);
            if (offerId.HasValue && User.Identity.IsAuthenticated)
            {
                return service.IsOfferReserved(offerId.Value, service.GetClientId(User.Identity.Name));
            }
            return false;
        }

        protected void BackToAttractionButton_Click(object sender, EventArgs e)
        {
            int attractionId = int.MinValue;
            if (!int.TryParse(AttractionId.Value, out attractionId))
            {
                if (!int.TryParse(Request.QueryString["aid"], out attractionId))
                {
                    Response.Redirect("~/Offers");
                }
            }
            if (attractionId != int.MinValue)
                Response.Redirect("~/AttractionDetails?aid=" + attractionId);

        }
    }
}