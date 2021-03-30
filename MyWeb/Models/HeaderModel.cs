using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Libs.Utils.Consts;

namespace MyWeb.Models
{
    public partial class HeaderModel
    {
        public string logoUrl { get; set; }
        public Entities.Config config { get; set; }
        public Entities.Support support { get; set; }
        public List<Entities.Page> menuTop { get; set; }
        public List<Entities.Page> menuMain { get; set; }
        public string menuMainText { get; set; }

        public HeaderModel()
        {
            config = new Entities.Config();
            support = new Entities.Support();
            menuTop = new List<Entities.Page>();
            menuMain = new List<Entities.Page>();
        }
        public static string GetLogoUrl()
        {
            using (var entity = new Entities.dehunEntities())
            {
                string logoUrl = (from a in entity.Advertises
                                 where a.Position == (int)BannerPosition.Logo && a.Active == (int)Active.Show
                                 select a).FirstOrDefault().Image;
                return logoUrl;
            }
        }
        public static HeaderModel GetConfig()
        {
            var model = new HeaderModel();
            using (var entity = new Entities.dehunEntities())
            {
                //model.logoUrl = (from a in entity.Advertises
                //                 where a.Position == (int)BannerPosition.Logo && a.Active == (int)Active.Show
                //                 select a).FirstOrDefault().Image;
                model.support = entity.Supports.FirstOrDefault();
                HttpContext.Current.Session.Add("support", model.support);
                model.config = entity.Configs.FirstOrDefault();
                HttpContext.Current.Session.Add("config", model.config);

                model.menuTop = (from p in entity.Pages
                                 where p.Position.Contains(((int)MenuPosition.Top).ToString()) && p.Active == (int)Active.Show
                                 select p)
                                 .OrderBy(r => r.Ord)
                                 .ToList();

                model.menuMain = (from p in entity.Pages
                                  where p.Position.Contains(((int)MenuPosition.Middle).ToString()) && p.Active == (int)Active.Show
                                  select p)
                                  .OrderBy(r => r.Level)
                                  .ToList();

                model.menuMainText = GeneralMenuText(model.menuMain);
                return model;
            }
                
        }

        public static List<Entities.Page> GeneralMenuMain()
        {
            using (var entity = new Entities.dehunEntities())
            {
                var menuMain = (from p in entity.Pages
                                  where p.Position.Contains(((int)MenuPosition.Middle).ToString()) && p.Active == (int)Active.Show
                                  select p)
                                  .OrderBy(r => r.Level)
                                  .ToList();
                
                return menuMain;
            }

        }
        #region Hiển thị menu chính
        private static string GeneralMenuText(List<Entities.Page> menuMain)
        {
            string strReturn = string.Empty;
            if (menuMain.Count > 0)
            {
                for (int i = 1; i < menuMain.Count; i++)
                {
                    string rdnNum = string.Empty;
                    if (menuMain[i - 1].Level.Length < menuMain[i].Level.Length)
                    {
                        strReturn += "<li><a href=\"" + menuMain[i - 1].Link + "\" title='" + menuMain[i - 1].Name + "'>" + menuMain[i - 1].Name + "</a>\n";
                        strReturn += "<ul class='sub-menu'>\n";
                    }
                    else if (menuMain[i - 1].Level.Length == menuMain[i].Level.Length)
                    {
                        strReturn += "<li><a href=\"" + menuMain[i - 1].Link + "\" title='" + menuMain[i - 1].Name + "'>" + menuMain[i - 1].Name + "</a></li>\n";
                    }
                    else if (menuMain[i - 1].Level.Length > menuMain[i].Level.Length)
                    {
                        strReturn += "<li><a title='" + menuMain[i - 1].Name + "' href=\"" + menuMain[i - 1].Link + "\">" + menuMain[i - 1].Name + "</a></li>\n";
                        strReturn += Inma(menuMain[i - 1].Level.Length, menuMain[i].Level.Length);
                    }
                }
                //Khi phần tử cuối cùng là con của phần tử trước nó
                if (menuMain[menuMain.Count - 2].Level.Length < menuMain[menuMain.Count - 1].Level.Length)
                {
                    strReturn += "<li><a title='" + menuMain[menuMain.Count - 1].Name + "' href=\"" + menuMain[menuMain.Count - 1].Link + "\">" + menuMain[menuMain.Count - 1].Name + "</a></li>\n";
                    strReturn += Inma(menuMain[menuMain.Count - 1].Level.Length, 5);
                }
                else
                {
                    //Khi phần tử cuối cùng không phải là con
                    strReturn += "<li><a href=\"" + menuMain[menuMain.Count - 1].Link + "\" title='" + menuMain[menuMain.Count - 1].Name + "'>" + menuMain[menuMain.Count - 1].Name + "</a></li>\n";
                    strReturn += Inma(menuMain[menuMain.Count - 1].Level.Length, 5);
                }
            }
            return strReturn;
        }

        #endregion
        #region In mã HTML
        /// <summary>
        /// In thẻ đóng html
        /// </summary>
        /// <param name="a">Integer</param>
        /// <returns>String html</returns>
        private static string Inma(int prev, int next)
        {
            string str = "";
            if (prev == 15 && next == 10)
            {
                str = "</ul></li></ul>";
            }
            else if (prev == 15 && next == 5)
            {
                str = "</ul></li></ul></li>";
            }
            else if (prev == 10 && next == 5)
            {
                str = "</ul></li>";
            }
            return str;
        }
        #endregion
    }
}