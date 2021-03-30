using Libs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "HomePage",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "LienHe",
                url: "lien-he",
                defaults: new { controller = "Home", action = "Contact" }
            );
            routes.MapRoute(
               name: "NhomDichVu",
               url: "dich-vu/{id}/{name}",
               defaults: new { controller = "Service", action = "List", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "DichVu",
               url: "dich-vu/{group}/{id}/{name}",
               defaults: new { controller = "Service", action = "Details", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "NhomSanPham",
               url: "san-pham/{id}/{name}",
               defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "SanPham",
               url: "san-pham/{group}/{id}/{name}",
               defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "TrangTin",
               url: "{id}/{name}",
               defaults: new { controller = "Page", action = "Detail", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "NhomTin",
               url: Consts.TIN_TUC + "/{id}/{name}",
               defaults: new { controller = "News", action = "List", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "TinTuc",
               url: Consts.TIN_TUC + "/{groupname}/{id}/{name}",
               defaults: new { controller = "News", action = "Details", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "home", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}
