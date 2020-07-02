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

            #region ChangePassword Reset Area
            routes.MapRoute(
                name: "PasswordReset",
                url: "Password/Reset/{code}",
                defaults: new { controller = "Password", action = "Reset" },
                constraints: new { code = "\\w*" }
            );
            #endregion

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
                name: "ArticleAuthorPage",
                url: "Article/User-{Id}/Page-{pageId}",
                defaults: new { controller = "Article", action = "Author" },
                constraints: new { id = "\\d+", pageId = "\\d+" }
            );

            routes.MapRoute(
                name: "ArticleAuthor",
                url: "Article/User-{Id}",
                defaults: new { controller = "Article", action = "Author" },
                constraints: new { id = "\\d+" }
            );


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
