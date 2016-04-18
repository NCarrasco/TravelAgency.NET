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
    public partial class ConfirmOfferReserve : System.Web.UI.Page
    {
        private TravelAgencyService service = new TravelAgencyService();

        protected void Page_Load(object sender, EventArgs e)
        {
            int offerId;
            bool isFound = false;
            if (int.TryParse(Request.QueryString["oid"], out offerId))
            {
                var offer = service.FindOffer(offerId);
                if (offer != null)
                {
                    isFound = true;
                    if (IsOfferReserved(offerId))
                    {
                        pnlConfirm.Visible = false;
                        Message.Text = "Offer is already reserved.";
                    }
                    else
                    {
                        pnlConfirm.Visible = true;
                        OfferId.Value = offerId.ToString();
                        Message.Text = String.Format("Do you really want to reserve the offer: Country: '{0}'; Departure Date: {1} ",
                            offer.tPanstwa.NazwaPanstwa, offer.DataWyjazdu);
                    }
                }
            }
            if (!isFound)
            {
                Message.Text = "Offer is not found.";
            }

        }

        public override void Dispose()
        {
            base.Dispose();
            service.Dispose();
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            int offerId;
            if (int.TryParse(OfferId.Value, out offerId))
            {
                var offer = service.FindOffer(offerId);
                if (offer != null)
                {
                    int? userId = AuthorizeUtil.GetUserId(service, User);
                    if (userId == null)
                    {
                        Response.Redirect("~/Account/Login");
                    }
                    pnlConfirm.Visible = false;
                    if (!IsOfferReserved(offerId))
                    {
                        tKlient client = service.GetClientWithPersons(userId.Value);
                        int personId = client.tOsoby.First().IDOsoby;
                        service.ReserveOffer(offerId, personId, client.IDKlienta);
                    }
                    Message.Text = "Offer has been reserved.";
                }
            }
        }
        private bool IsOfferReserved(int offerId)
        {
            return service.IsOfferReserved(offerId, AuthorizeUtil.GetUserId(service, User));
        }

        protected void BackToOfferButton_Click(object sender, EventArgs e)
        {
            int offerId = int.MinValue;
            if (!int.TryParse(OfferId.Value, out offerId))
            {
                if (!int.TryParse(Request.QueryString["oid"], out offerId))
                {
                    Response.Redirect("~/Offers");
                }
            }
            if (offerId != int.MinValue)
                Response.Redirect("~/OfferDetails?oid=" + offerId);
        }
    }
}