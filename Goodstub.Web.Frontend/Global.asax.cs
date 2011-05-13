using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Goodstub.Web.Routing;
using Goodstub.Web.Frontend.RouteConstraints;
using Goodstub.Web.Frontend.Unity;

namespace Goodstub.Web.Frontend
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    "User",
            //    "{username}/{action}",
            //    new { controller = "Authors", action = "Index" },
            //    new { user = new UserRouteConstraint() }
            //);

            //routes.MapRouteLowercase(
            //    "Default",
            //    "{controller}/{action}/{id}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new string[] { "Goodstub.Web.Frontend.Controllers" }
            //);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityManager.Instance));
        }
    }
}