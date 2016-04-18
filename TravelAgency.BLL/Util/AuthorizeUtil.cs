using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using TravelAgency.BLL.BLL;
using TravelAgency.Repository;

namespace TravelAgency.BLL.Util
{
    public class AuthorizeUtil
    {

        public static int? GetUserId(TravelAgencyService service, IPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
                return service.GetClientId(user.Identity.Name);
            return null;
        }
    }
}