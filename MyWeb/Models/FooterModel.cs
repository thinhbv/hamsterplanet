using MyWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Libs.Utils.Consts;

namespace MyWeb.Models
{
    public partial class FooterModel
    {
        public Page about { get; set; }
        public List<Page> menuBottom { get; set; }
        public string address { get; set; }
        public Support support { get; set; }

        public FooterModel()
        {
            using (dehunEntities entity = new dehunEntities())
            {
                about = (from p in entity.Pages
                         where p.Active == (int)Active.Show && p.Position.Contains(((int)PagePosition.About).ToString())
                         select p).FirstOrDefault();
                List<Page> pages = (from p in entity.Pages
                              where p.Active == (int)Active.Show && p.Position.Contains(((int)PagePosition.Menu_Bottom).ToString())
                              orderby p.Level
                              select p).ToList();
                menuBottom = new List<Page>();
                foreach (Page item in pages.Where(r => r.Level.Length == 5).ToList())
                {
                    menuBottom.Add(item);
                }
                address = ((Config)HttpContext.Current.Session["config"]).Contact;
                support = ((Support)HttpContext.Current.Session["support"]);
            }
        }
    }
}