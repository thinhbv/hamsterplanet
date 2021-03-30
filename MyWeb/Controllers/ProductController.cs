using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Entities;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List(int id)
        {
            ProductsModel models = new ProductsModel(id);
            return View(models);
        }

        // GET: Product
        public ActionResult Detail(int id)
        {
            ProductDetailModel models = new ProductDetailModel(id);
            return View(models);
        }
    }
}