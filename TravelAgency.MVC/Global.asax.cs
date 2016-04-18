using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;

namespace TravelAgency.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // In deployment step add migration here
            // var migration = new DbMigration(new Configuration());
            // migration.Update();
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("TravelAgencyContext", "tKlient", "IDKlienta", "email", autoCreateTables: true);
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
