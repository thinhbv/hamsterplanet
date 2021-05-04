using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeb.Entities;

namespace MyWeb.Models
{
    public class ProductsModel
    {
        public GroupProduct group { get; set; }
        public List<Product> products { get; set; }
        public ProductsModel()
        {
            group = new GroupProduct();
            products = new List<Product>();
        }

        public ProductsModel(int id)
        {
            try
            {
                using (var entity = new dehunEntities())
                {
                    group = entity.GroupProducts.SingleOrDefault(r => r.Id == id);
                    List<int> groups = entity.GroupProducts.Where(r => r.Level.StartsWith(group.Level) && r.Active == 1).Select(r => r.Id).ToList();
                    products = entity.Products.AsEnumerable().Where(r => r.Active == 1 && groups.Any(c => c.CompareTo(r.GroupId) == 0 && !string.IsNullOrEmpty(r.Image1))).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}