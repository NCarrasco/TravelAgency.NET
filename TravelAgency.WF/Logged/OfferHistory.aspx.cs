using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgency.BLL.BLL;
using TravelAgency.WF.Util;

namespace TravelAgency.WF
{
    public partial class OfferHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void OfferHistoryGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.LinkButton lbNewWindow = new System.Web.UI.WebControls.LinkButton();
                lbNewWindow = (System.Web.UI.WebControls.LinkButton)e.Row.FindControl("btnDetails");
                if (lbNewWindow != null)
                {
                    string offerId = DataBinder.Eval(e.Row.DataItem, "IDOferty").ToString();
                    lbNewWindow.Attributes.Add("offerId", offerId);
                }
            }
        }
        protected void btnDetails_Click(object sender, EventArgs e)
        {
            var link = sender as LinkButton;
            var offerIdStr = link.Attributes["offerId"] as String;
            int offerId = int.Parse(offerIdStr);
            Response.Redirect(String.Format("/Logged/OfferHistoryDetails?oid={0}", offerId));
        }

        protected void OfferHistoryObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            var id = LoggedUserUtil.GetLoggerClientID(User);
            if (id.HasValue)
                e.InputParameters["userId"] = id.Value;
        }
    }
}