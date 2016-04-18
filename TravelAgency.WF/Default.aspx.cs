using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TravelAgency.WF.Util;
using WebMatrix.WebData;

namespace TravelAgency.WF
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            WebSecurity.Logout();
            Response.Redirect(Request.RawUrl);
        }
    }
}