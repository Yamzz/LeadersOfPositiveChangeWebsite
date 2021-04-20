using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Leadersofpositvechange
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes(); //Enables Attribute Routing

            //routes.MapRoute(
            // "PhotoGallery",
            // "Photos/{galleryId}",
            // new { controller = "Projects", action = "Photos" });

            //routes.MapRoute(
            // "GalleryBrowse",
            // "Home/Gallery/Photos/{galleryId}",
            // new
            // {
            //     controller = "Home",
            //     action = "Photos",
            //     galleryId = UrlParameter.Optional
            // });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Admin", action = "Dashboard", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "LeadersOfPositiveChange", id = UrlParameter.Optional }
            );

        }
    }
}
