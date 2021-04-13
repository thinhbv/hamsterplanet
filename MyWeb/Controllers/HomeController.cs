using Libs.Utils;
using MyWeb.Entities;
using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Libs.Utils.Consts;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new HomeModel());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            try
            {
                using (var entity = new dehunEntities())
                {
                    Config config = entity.Configs.FirstOrDefault();
                    if (config != null)
                    {
                        ViewBag.Location = config.Contact;
                    }
                    List<Support> support = entity.Supports.Where(r => r.Active == (int)Active.Show).ToList();

                    if (support.Count > 0)
                    {
                        ViewBag.Phone = support[0].Phone;
                        ViewBag.Email = support[0].Email;
                        for (int i = 1; i < support.Count; i++)
                        {
                            ViewBag.Phone += " - " + support[i].Phone;
                            ViewBag.Email += " - " + support[i].Email;
                        }
                    }
                }

                return View();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        [HttpPost]
        public void Contact(Contact contact)
        {
            try
            {
                using (var entity = new dehunEntities())
                {
                    contact.Date = DateTime.Now;
                    entity.Contacts.Add(contact);
                    entity.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}