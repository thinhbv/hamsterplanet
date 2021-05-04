using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeb.Entities;

namespace MyWeb.Models
{
    public class ProductsListModel
    {
        public List<Product> productsModel { get; set; }
        public List<ProductsModel> productsAllModel { get; set; }
        public ProductsModel productsOther { get; set; }
        public ProductsListModel()
        {
            List<GroupProduct> groups;
            try
            {
                productsModel = new List<Product>();
                productsAllModel = new List<ProductsModel>();
                productsOther = new ProductsModel();
                using (var entity = new dehunEntities())
                {
                    ProductsModel model;
                    GroupProduct group = entity.GroupProducts.Where(r => r.Priority == 1 && r.Active == 1).FirstOrDefault();
                    productsModel = entity.Products.Where(r => r.Active == 1 && r.IsHot == 1 && !string.IsNullOrEmpty(r.Image1)).ToList();

                    groups = entity.GroupProducts.Where(r => r.Active == 1).ToList();
                    foreach (var item in groups)
                    {
                        model = new ProductsModel();
                        model.group = item;
                        model.products = entity.Products.Where(r => r.Active == 1 && r.GroupId == item.Id && !string.IsNullOrEmpty(r.Image1)).ToList();
                        if (model.products.Count > 0)
                        {
                            productsAllModel.Add(model);
                        }
                    }
                    productsOther.group = group;
                    productsOther.products = entity.Products.Where(r => r.GroupId == group.Id && r.Active == 1 && !string.IsNullOrEmpty(r.Image1)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}