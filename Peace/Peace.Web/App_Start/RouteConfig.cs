using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Peace.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //注册默认路由和命名空间
            routes.MapRoute(
                name: "Default_Peace",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                namespaces: new[] { "Peace.Web.Controllers" }
            );

            //登录和注册用不同的路由
            routes.MapRoute(
              "Default_Peace_Account", // Route name
              "Account/{action}",
              new { controller = "Account", action = "Login" } // Parameter defaults
            );
        }
    }
}