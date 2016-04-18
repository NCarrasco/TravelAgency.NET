using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using TravelAgency.BLL.BLL;
using WebMatrix.WebData;

namespace TravelAgency.WF.Util
{
    public class LoggedUserUtil
    {
        /// <summary>
        /// Returns Client ID for the logged user.
        /// </summary>
        /// <param name="user">the logged user</param>
        /// <returns>the Client ID or null when it is not found</returns>
        public static int? GetLoggerClientID(IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                TravelAgencyService service = new TravelAgencyService();
                using (service.ToDisposable())
                {
                    int? userId = service.GetClientId(user.Identity.Name);
                    return userId;
                }
            }
            return null;
        }

        /// <summary>
        /// Logs out the current user and redirects to the current page.
        /// </summary>
        /// <param name="caller">the control with Response and Request proeprties</param>
        public static void PerformLogOutAndRedirect(UserControl caller)
        {
            WebSecurity.Logout();
            caller.Response.Redirect(caller.Request.RawUrl);
        }
    }
}