using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eUseControl
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                          
            );
            routes.MapRoute(
                name: "ContactUs",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "about",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "about", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "service",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "service", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "Appointment",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "appointment", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "Price",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "price", id = UrlParameter.Optional }

            );

        }
    }
}
