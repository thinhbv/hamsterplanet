using Libs.Utils;
using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Entities;
using static Libs.Utils.Consts;

namespace MyWeb.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ServiceDetailModel model = new ServiceDetailModel(id);
                ViewBag.Title = model.product.Name;
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }


        // GET: Service/List/5
        public ActionResult List(int id)
        {
            try
            {
                ServiceListModel model = new ServiceListModel(id);
                if (model.servicesModel != null && model.servicesModel.group != null)
                {
                    ViewBag.Title = model.servicesModel.group.Name;
                }
                
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
