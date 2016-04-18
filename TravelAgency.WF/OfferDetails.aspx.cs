using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgency.BLL.BLL;
using TravelAgency.BLL.Util;

namespace TravelAgency.WF
{
    public partial class OfferDetails : System.Web.UI.Page
    {
        private TravelAgencyService service = new TravelAgencyService();

        private IDictionary<int, bool> attractionIdToReservedMap;

        protected void Page_Load(object sender, EventArgs e)
        {
            int? offerId = GetOfferId();
            if (offerId.HasValue)
            {
                int attractionCount = service.GetAttractions(offerId.Value).Count();
                AttractionPanel.Visible = attractionCount > 0;
            }
            if (User.Identity.IsAuthenticated)
            {
                attractionIdToReservedMap = service.GetAttractionIdToReservedMap(service.GetClientId(User.Identity.Name));
            }

        }

        protected void ReserveButton_Click(object sender, EventArgs e)
        {
            int? offerId = OfferDetailsView.DataKey[0] as int?;
            if (offerId.HasValue)
            {
                Response.Redirect(String.Format("Logged/ConfirmOfferReserve?oid={0}", offerId.Value));
            }
        }

        protected bool IsOfferReserved
        {
            get
            {
                int? offerId = GetOfferId();
                if (offerId.HasValue)
                {
                    return service.IsOfferReserved(offerId.Value, AuthorizeUtil.GetUserId(service, User));
                }
                return false;
            }
        }

        private int? GetOfferId()
        {
            int? offerId = null;
            if (OfferDetailsView.DataKey.Values.Count > 0)
            {
                offerId = OfferDetailsView.DataKey[0] as int?;
            }
            else
            {
                int value;
                if (int.TryParse(Request.QueryString["oid"], out value))
                    offerId = value;
            }
            return offerId;
        }

        protected void GridViewAttractions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int? attractionId = DataBinder.Eval(e.Row.DataItem, "IDAtrakcjiUslugi") as int?;
                e.Row.CssClass = IsAttractionReserved(attractionId) ? "item-reserved" : "";
                System.Web.UI.WebControls.LinkButton lbNewWindow = new System.Web.UI.WebControls.LinkButton();
                lbNewWindow = (System.Web.UI.WebControls.LinkButton)e.Row.FindControl("btnShowDetails");
                if (lbNewWindow != null)
                {
                    lbNewWindow.Attributes.Add("attractionId", attractionId.ToString());
                }
            }
        }

        private bool IsAttractionReserved(int? attractionId)
        {
            if (attractionId.HasValue && attractionIdToReservedMap != null && attractionIdToReservedMap.ContainsKey(attractionId.Value))
                return attractionIdToReservedMap[attractionId.Value];
            return false;
        }

        protected void btnShowDetails_Click(object sender, EventArgs e)
        {
            var link = sender as LinkButton;
            var attractionIdStr = link.Attributes["attractionId"] as String;
            int attractionId = int.Parse(attractionIdStr);
            Response.Redirect(String.Format("/AttractionDetails?aid={0}", attractionId));
        }
        public override void Dispose()
        {
            base.Dispose();
            service.Dispose();
        }
    }
}