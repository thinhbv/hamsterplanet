using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeb.Entities;

namespace MyWeb.Models
{
    public class ProductDetailModel
    {
        public Product product { get; set; }
        public List<Product> productsRelate { get; set; }
        public ProductDetailModel(int id)
        {
            try
            {
                using (var entity = new dehunEntities())
                {
                    product = entity.Products.SingleOrDefault(r => r.Id == id);
                    productsRelate = entity.Products.Where(r => r.GroupId == product.GroupId && r.Active == 1 && r.Id != id && !string.IsNullOrEmpty(r.Image1)).Take(10).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}