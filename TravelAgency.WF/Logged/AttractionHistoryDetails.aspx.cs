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
    public partial class AttractionHistoryDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AttractionHistoryObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            var id = LoggedUserUtil.GetLoggerClientID(User);
            if (id.HasValue)
                e.InputParameters["userId"] = id.Value;
        }

        protected void btnOfferHistory_Click(object sender, EventArgs e)
        {
            int aid;
            if (int.TryParse(Request.QueryString["aid"], out aid))
            {
                TravelAgencyService service = new TravelAgencyService();
                using (service.ToDisposable())
                {
                    int? offerId = service.GetOfferHistoryIdByAttractionId(aid);
                    if(offerId.HasValue)
                        Response.Redirect(String.Format("/Logged/OfferHistoryDetails?oid={0}", offerId.Value));
                }
            }
        }
    }
}