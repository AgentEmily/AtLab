using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplicationRoute
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            
            
            //routes.MapRoute(
            //    name: "test",
            //    url: "{p1}/{p2}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapMvcAttributeRoutes();
            
            //http://localhost/blog/2015 (限制輸入4個數字)
            //網頁上要出現 BlogByYear : 2015

            routes.MapRoute(
                name: "blog",
                url: "blog/{year}",
                defaults: new { controller = "HWRoute", action = "BlogByYear", id = UrlParameter.Optional },
                constraints: new {year="[0-9]{4}" }
            );

            routes.MapRoute(
                name: "blogbymonth",
                url: "blog/{year}/{month}",
                defaults: new { controller = "HWRoute", action = "BlogByMonth", id = UrlParameter.Optional },
                constraints: new { year = "[0-9]{4}", month = "[0-9]{2}" }
            );
            
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "test1",
            //    url: "{action}/{p1}/{p2}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    constraints: new {p1="[0-9]+"}
            //);
        }
    }
}
