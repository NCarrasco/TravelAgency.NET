using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebMatrix.WebData;
using TravelAgency.BLL.BLL;
using TravelAgency.DAL.DAL;
using System.Web.Security;
using TravelAgency.BLL.Util;

namespace TravelAgency.WF.Account
{
    public partial class Login : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (WebSecurity.Login(LoginTextBox.Text, Password.Text, persistCookie: RememberMe.Checked))
                {
                    WebDataHelper.AddUserToRole(LoginTextBox.Text);
                    RedirectHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ModelState.AddModelError("", "Login failed.");
                }
            }
        }

    }
}