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
            routes.MapRoute(
             name: "User",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "user", id = UrlParameter.Optional }
             
             );

             routes.MapRoute(
             name: "Doctor",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "doctor_page", id = UrlParameter.Optional }

         );









            routes.MapRoute(
             name: "Team",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "team", id = UrlParameter.Optional }

         );
            routes.MapRoute(
             name: "Signin",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "sign_in", id = UrlParameter.Optional }

         );
            routes.MapRoute(
         name: "Signup",
         url: "{controller}/{action}/{id}",
         defaults: new { controller = "Home", action = "sign_up", id = UrlParameter.Optional }

     );

        }
    }
}
