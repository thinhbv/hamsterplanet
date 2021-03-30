using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeb.Entities;

namespace MyWeb.Models
{
    public class ProductsListModel
    {
        public List<ProductsModel> productsModel { get; set; }
        public List<ProductsModel> productsAllModel { get; set; }
        public ProductsModel productsOther { get; set; }
        public ProductsListModel()
        {
            try
            {
                productsModel = new List<ProductsModel>();
                productsAllModel = new List<ProductsModel>();
                productsOther = new ProductsModel();
                using (var entity = new dehunEntities())
                {
                    ProductsModel model = new ProductsModel();
                    GroupProduct group = entity.GroupProducts.Where(r => r.Priority == 1).FirstOrDefault();
                    List<GroupProduct> groups = entity.GroupProducts.Where(r => r.Priority == 1 && r.Active == 1).ToList();
                    foreach (var item in groups)
                    {
                        model.group = item;
                        model.products = entity.Products.Where(r => r.Active == 1 && r.GroupId == item.Id).ToList();
                        productsModel.Add(model);
                    }

                    groups = entity.GroupProducts.Where(r => r.Active == 1 && r.Position == 1).ToList();
                    foreach (var item in groups)
                    {
                        model.group = item;
                        model.products = entity.Products.Where(r => r.Active == 1 && r.GroupId == item.Id).ToList();
                        productsAllModel.Add(model);
                    }
                    productsOther.group = group;
                    productsOther.products = entity.Products.Where(r => r.GroupId == group.Id && r.Active == 1).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}