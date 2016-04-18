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
    public partial class AttractionDetails : System.Web.UI.Page
    {
        private TravelAgencyService service = new TravelAgencyService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ReserveButton_Click(object sender, EventArgs e)
        {
            if (DetailsViewAttraction.DataKey.Values.Count > 0)
            {
                int? aid = DetailsViewAttraction.DataKey["IDAtrakcjiUslugi"] as int?;
                if (aid.HasValue)
                {
                    Response.Redirect("Logged/ConfirmAttractionReserve?aid=" + aid.Value);
                }
            }
        }
        public override void Dispose()
        {
            base.Dispose();
            service.Dispose();
        }

        public bool IsAttractionReserved
        {
            get
            {
                int? attractionId = GetAttractionId();
                if (attractionId.HasValue && User.Identity.IsAuthenticated)
                {
                    int? clientId = service.GetClientId(User.Identity.Name);
                    return service.IsAttractionReserved(attractionId.Value, clientId.Value);
                }
                return false;
            }
        }

        private int? GetAttractionId()
        {
            int? attractionId = null;
            if (DetailsViewAttraction.DataKey.Values.Count > 0)
            {
                attractionId = DetailsViewAttraction.DataKey[0] as int?;
            }
            else
            {
                int value;
                if (int.TryParse(Request.QueryString["aid"], out value))
                    attractionId = value;
            }
            return attractionId;
        }

        protected void btnBackToOffer_Click(object sender, EventArgs e)
        {
            int? attractionId = GetAttractionId();
            if (attractionId.HasValue)
            {
                int? offerId = service.GetOfferIdByAttractionId(attractionId.Value);
                if (offerId.HasValue)
                    Response.Redirect("OfferDetails?oid=" + offerId.Value);
            }
        }

        protected bool CanReserveAttraction
        {
            get
            {
                int? aid = GetAttractionId();
                if (aid.HasValue)
                {
                    int? offerId = service.GetOfferIdByAttractionId(aid.Value);
                    if (offerId.HasValue && User.Identity.IsAuthenticated)
                    {
                        return service.IsOfferReserved(offerId.Value, service.GetClientId(User.Identity.Name));
                    }
                }
                return true;
            }
        }
    }
}