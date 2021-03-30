using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Controllers
{
    public class SharedController : Controller
    {
        [ChildActionOnly]
        public ActionResult Header()
        {
            HeaderModel model = HeaderModel.GetConfig();
            return PartialView("../Partial/_Header", model);
        }

        [ChildActionOnly]
        public ActionResult MenuMain()
        {
            ViewBag.LogoUrl = HeaderModel.GetLogoUrl();
            List<Entities.Page> model = HeaderModel.GeneralMenuMain();
            return PartialView("../Partial/_MenuMain", model);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            FooterModel model = new FooterModel();
            return PartialView("../Partial/_Footer", model);
        }
    }
}