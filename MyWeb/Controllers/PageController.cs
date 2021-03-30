using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Entities;

namespace MyWeb.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Detail(int id)
        {
            using (dehunEntities entity = new dehunEntities())
            {
                Page page = entity.Pages.Where(r => r.Id == id).FirstOrDefault();
                ViewBag.Title = page.Name;
                return View(page);
            }
        }
    }
}