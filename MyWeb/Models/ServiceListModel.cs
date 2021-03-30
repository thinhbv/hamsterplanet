using MyWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Libs.Utils.Consts;

namespace MyWeb.Models
{
    public partial class ServiceListModel
    {
        public ServicesModel servicesModel { get; set; }
        public List<GroupProduct> groups { get; set; }

        public ServiceListModel(int id)
        {
            using (dehunEntities entity = new dehunEntities())
            {
                servicesModel = new ServicesModel();
                groups = (from g in entity.GroupProducts
                          where g.Active == (int)Active.Show && g.Position == 1
                          select g).ToList();
                servicesModel.group = groups.SingleOrDefault(r => r.Id == id);
                groups.Remove(servicesModel.group);
                servicesModel.products = (from p in entity.Products
                                          where p.Active == (int)Active.Show && p.GroupId == id
                                          select p).ToList();

            }
        }
    }
}