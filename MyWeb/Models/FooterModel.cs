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
        public List<MenuModel> menuBottom { get; set; }
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
                menuBottom = new List<MenuModel>();
                foreach (Page item in pages.Where(r => r.Level.Length == 10).ToList())
                {
                    MenuModel model = new MenuModel();
                    model.parent = item;
                    model.childs = pages.Where(r => r.Level.Length > 10).Where(r => r.Level.StartsWith(item.Level)).ToList();
                    menuBottom.Add(model);
                }
                address = ((Config)HttpContext.Current.Session["config"]).Contact;
                support = ((Support)HttpContext.Current.Session["support"]);
            }
        }
    }

    public class MenuModel
    {
        public Page parent { get; set; }
        public List<Page> childs { get; set; }
    }
}