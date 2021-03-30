using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeb.Entities;

namespace MyWeb.Models
{
    public partial class ServicesModel
    {
        public GroupProduct group { get; set; }
        public string classname { get; set; }
        public List<Product> products { get; set; }
        public ServicesModel()
        {
            group = new GroupProduct();
            products = new List<Product>();
        }
    }
}