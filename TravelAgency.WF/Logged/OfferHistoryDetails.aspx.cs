using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgency.BLL.BLL;
using TravelAgency.WF.Util;

namespace TravelAgency.WF.Logged
{
    public partial class OfferHistoryDetails : System.Web.UI.Page
    {
        TravelAgencyService service = new TravelAgencyService();

        protected void Page_Load(object sender, EventArgs e)
        {
            int? id = service.GetClientId(User.Identity.Name);
            int? offerId = GetOfferId();
            int count = 0;
            if (id.HasValue && offerId.HasValue)
            {
                count = service.GetAttractionHistoryList(id.Value, offerId.Value).Count();
                AttractionPanel.Visible = count > 0;
            }
        }

        private int? GetOfferId()
        {
            int value;
            if (int.TryParse(Request.QueryString["oid"], out value))
                return value;
            return null;
        }

        protected void OfferHistoryDetailsDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            var id = service.GetClientId(User.Identity.Name);
            if (id.HasValue)
                e.InputParameters["userId"] = id.Value;
        }

        protected void AttractionHistoryObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            var id = service.GetClientId(User.Identity.Name);
            if (id.HasValue)
                e.InputParameters["userId"] = id.Value;
        }

        protected void btnDetails_Click(object sender, EventArgs e)
        {
            var link = sender as LinkButton;
            var offerIdStr = link.Attributes["attractionId"] as String;
            int offerId = int.Parse(offerIdStr);
            Response.Redirect(String.Format("/Logged/AttractionHistoryDetails?aid={0}", offerId));
        }

        protected void GridViewAttractionHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.LinkButton lbNewWindow = new System.Web.UI.WebControls.LinkButton();
                lbNewWindow = (System.Web.UI.WebControls.LinkButton)e.Row.FindControl("btnDetails");
                if (lbNewWindow != null)
                {
                    string offerId = DataBinder.Eval(e.Row.DataItem, "IDAtrakcjiUslugi").ToString();
                    lbNewWindow.Attributes.Add("attractionId", offerId);
                }
            }
        }
        public override void Dispose()
        {
            base.Dispose();
            service.Dispose();
        }
    }
}