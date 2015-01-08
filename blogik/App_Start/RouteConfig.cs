using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace blogik
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "PostMain",
                url: "Post",
                defaults: new { controller = "Post", action = "Index" }
            );

            routes.MapRoute(
                name: "PostPage",
                url: "Post/Page/{id}",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional }
                , constraints: new { id = @"^[\d]+$" }
            );

            routes.MapRoute(
                name: "Post",
                url: "Post/{id}",
                defaults: new { controller = "Post", action = "NPost", id = UrlParameter.Optional }
                , constraints: new { id = @"^[a-zA-Z\d\-]+$" }
            );

            routes.MapRoute(
                name: "Tags",
                url: "Tags/{id}",
                defaults: new { controller = "Tags", action = "NTags", id = UrlParameter.Optional }
                , constraints: new { id = @"^[a-zA-Z\d\-]+$" }
            );

            routes.MapRoute(
                name: "Search",
                url: "Search",
                defaults: new { controller = "Post", action = "Search"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    "CatchAll",
            //    "{action}",
            //    defaults: new { controller = "Home", action = "Error" }
            //);
            //routes.MapRoute(
            //name: "Error",
            //url: "{controller}/{action}/{id}",
            //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }   
}