﻿using System;
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

            #region Problem Route Area
            routes.MapRoute(
                name: "ProblemSingle",
                url: "Problem/{Id}",
                defaults: new { controller = "Problem", action = "Single" },
                constraints: new { id = "\\d+" }
            );

            routes.MapRoute(
                name: "ProblemIndex",
                url: "Problem/Page-{id}",
                defaults: new { controller = "Problem", action = "Index", id = "1" }
            );
            #endregion

            #region Article Route Area
            routes.MapRoute(
                name: "ArticleSingle",
                url: "Article/{Id}",
                defaults: new { controller = "Article", action = "Single" },
                constraints: new { id = "\\d+" }
            );

            routes.MapRoute(
                name: "ArticleIndex",
                url: "Article/Page-{id}",
                defaults: new { controller = "Article", action = "Index", id = "1" }
            );
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
