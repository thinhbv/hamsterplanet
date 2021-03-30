using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeb.Entities;
using static Libs.Utils.Consts;

namespace MyWeb.Models
{
    public partial class NewsDetailModel
    {
        public News news {get;set;}
        public List<News> newsReleate { get; set; }

        public NewsDetailModel(int id)
        {
            try
            {
                using (var entity = new dehunEntities())
                {
                    news = (from n in entity.News
                            where n.Active == (int)Active.Show && n.Id == id
                            select n).FirstOrDefault();
                    newsReleate = (from n in entity.News
                                   where n.Active == (int)Active.Show && n.GroupNewsId == news.GroupNewsId && n.Id != id
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