using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "ArticleIndex",
                url: "Article/Page-{id}",
                defaults: new { controller = "Article", action = "Index", id = UrlParameter.Optional }
            );




            //routes.MapRoute(
            //    name: "ArticleNew",
            //    url: "Article/New",
            //    defaults: new { controller = "Article", action = "New" }
            //);
            //routes.MapRoute(
            //    name: "ArticleEdit",
            //    url: "Article/Edit",
            //    defaults: new { controller = "Article", action = "Edit", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    name: "LogOnConfig",
            //    url: "Log/On",
            //    defaults: new { controller = "Log", action = "On" }
            //);

            //routes.MapRoute(
            //    name: "LogOffConfig",
            //    url: "Log/Off",
            //    defaults: new { controller = "Log", action = "Off" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
