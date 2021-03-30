using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeb.Entities;
using static Libs.Utils.Consts;

namespace MyWeb.Models
{
    public partial class NewsModel
    {
        public GroupNew group { get; set; }
        public List<News> news { get; set; }

        public NewsModel(int id)
        {
            try
            {
                using (var entity = new dehunEntities())
                {
                    group = (from g in entity.GroupNews
                             where g.Active == (int)Active.Show && g.Id == id
                             select g).FirstOrDefault();
                    news = (from n in entity.News
                            where n.Active == (int)Active.Show && n.GroupNewsId == id
                            orderby n.Date descending
                            select n).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}