using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using pppk_projekt_Cosmos.DAO;
namespace pppk_projekt_Cosmos
{
    public class MvcApplication : System.Web.HttpApplication
    {
      

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CosmosServiceDBProvider.Init().GetAwaiter().GetResult();
        }
    }
}
