using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgency.BLL.BLL;
using TravelAgency.DAL.DAL;

namespace TravelAgency.WF
{
    public partial class Offers : System.Web.UI.Page
    {
        private IDictionary<int, bool> offerIdToReservedMap;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                TravelAgencyService service = new TravelAgencyService();
                using (service.ToDisposable())
                {
                    offerIdToReservedMap = service.GetOfferIdToReservedMap(service.GetClientId(User.Identity.Name));
                }
            }
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            OffersGridView.EnableDynamicData(typeof(tOferta));
        }

        protected void rowsToDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowCount = GetRowCount();
            int newPageSize = int.Parse(rowsToDisplay.SelectedValue);
            OffersGridView.PageSize = newPageSize;
            if (newPageSize > 0)
            {
                int newPageIndex = rowCount / OffersGridView.PageSize;
                if (newPageIndex < OffersGridView.PageIndex)
                {
                    OffersGridView.PageIndex = Math.Max(0, newPageIndex);
                }
            }
        }

        /// <summary>
        /// Returns number of rows from previous pages.
        /// </summary>
        /// <returns></returns>
        private int GetRowCount()
        {
            int index = OffersGridView.PageIndex;
            if (index == 0)
            {
                return 0;
            }
            else {
                return index * OffersGridView.PageCount;
            }
        }

        protected void OffersGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int? offerId = DataBinder.Eval(e.Row.DataItem, "IDOferty") as int?;
                e.Row.CssClass = IsOfferReserved(offerId) ? "item-reserved" : "";
                System.Web.UI.WebControls.LinkButton lbNewWindow = new System.Web.UI.WebControls.LinkButton();
                lbNewWindow = (System.Web.UI.WebControls.LinkButton)e.Row.FindControl("DetailsLink");
                if (lbNewWindow != null)
                {
                    lbNewWindow.Attributes.Add("offerId", offerId.ToString());
                }
            }
        }

        private bool IsOfferReserved(int? offerId)
        {
            if (offerId.HasValue && offerIdToReservedMap != null && offerIdToReservedMap.ContainsKey(offerId.Value))
                return offerIdToReservedMap[offerId.Value];
            return false;
        }

        protected void DetailsLink_Click(object sender, EventArgs e)
        {
            var link = sender as LinkButton;
            var offerIdStr = link.Attributes["offerId"] as String;
            int offerId = int.Parse(offerIdStr);
            Response.Redirect(String.Format("/OfferDetails?oid={0}", offerId));
        }

    }
}