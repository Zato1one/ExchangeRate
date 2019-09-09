using AutoMapper;
using ExchangeRate.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ExchangeRate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterAutomapperProfile();
        }
        private void RegisterAutomapperProfile()
        {
            Mapper.Initialize(config => {
                config.AddProfile<WebAutomapperProfile>();
            });
        }
    }
}
