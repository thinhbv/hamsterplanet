using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Controllers
{
    public class NewsController : Controller
    {
        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                NewsDetailModel model = new NewsDetailModel(id);
                ViewBag.Title = model.news.Name;
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }


        // GET: News/List/5
        public ActionResult List(int id)
        {
            try
            {
                NewsModel model = new NewsModel(id);
                ViewBag.Title = model.group.Name;
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}