using MyWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Libs.Utils.Consts;

namespace MyWeb.Models
{
    public partial class ServiceDetailModel
    {
        public Product product { get; set; }
        public List<Product> productRelate { get; set; }
        public List<News> newsRelate { get; set; }

        public ServiceDetailModel(int id)
        {
            using (dehunEntities entity = new dehunEntities())
            {
                productRelate = (from p in entity.Products
                                 where p.Active == (int)Active.Show 
                                 && p.GroupId == (from s in entity.Products
                                                  where s.Id == id
                                                  select s.GroupId).FirstOrDefault()
                                 select p).ToList();
                product = productRelate.Where(r => r.Id == id).FirstOrDefault();
                productRelate.Remove(product);
                newsRelate = entity.News.Where(r => r.Active == 1 
                                                && !string.Empty.Equals(r.LinkDemo) 
                                                && r.LinkDemo.Contains("'" + product.Id.ToString() + "'"))
                                                    .OrderByDescending(r => r.Date)
                                                    .ToList();

            }
        }
    }
}