using StudentFollowApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentFollowApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
