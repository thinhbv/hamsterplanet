using System;
using System.Collections.Generic;
using System.Linq;
using static Libs.Utils.Consts;
using MyWeb.Entities;

namespace MyWeb.Models
{
    public partial class HomeModel
    {
        public List<Advertise> Slider { get; set; }
        //public List<GroupProduct> Wedo { get; set; }
        //public List<Page> HomeService { get; set; }
        //public List<Product> OurService { get; set; }
        //public List<ImagesModel> CompletedProject { get; set; }
        public List<Product> ProductsList { get; set; }
        public List<ProductsModel> ProductsAllList { get; set; }
        public ProductsModel ProductsOther { get; set; }
        public List<Images> ImagesList { get; set; }
        public List<News> HomeNews { get; set; }

        public HomeModel()
        {
            Slider = GetSlider();
            //Wedo = GetWedo();
            //HomeService = GetHomeServices();
            //OurService = GetOurServices();
            //CompletedProject = GetCompletedProject();
            ProductsList = new ProductsListModel().productsModel;
            ProductsAllList = new ProductsListModel().productsAllModel;
            ImagesList = new ImagesModel().images;
            //HomeNews = GetHomeNews();
        }

        public List<Advertise> GetSlider()
        {
            try
            {
                using (var entity = new dehunEntities())
                {
                    List<Advertise> Slider = (from a in entity.Advertises
                                              where a.Position == (int)BannerPosition.Slider && a.Active == (int)Active.Show
                                              select a)
                                          .ToList();
                    return Slider;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GroupProduct> GetWedo()
        {
            //List<ServicesModel> lstModel = new List<ServicesModel>();
            try
            {
                using (var entity = new dehunEntities())
                {
                    List<GroupProduct> groups = (from g in entity.GroupProducts
                                                 where g.Active == (int)Active.Show && g.Priority == (int)Active.Show && g.Position == 1
                                                 select g).ToList();
                    //List<Product> Wedo = (from p in entity.Products
                    //                      join g in entity.GroupProducts on p.GroupId equals g.Id
                    //                      where g.Active == (int)Active.Show && p.Active == (int)Active.Show && g.Priority == (int)Active.Show
                    //                      select p)
                    //                      .ToList();
                    //for (int i = 0; i < groups.Count; i++)
                    //{
                    //    ServicesModel model = new ServicesModel();
                    //    if (i == 0)
                    //    {
                    //        model.classname = "active";
                    //    }
                    //    model.group = groups[i];
                    //    model.products = Wedo.Where(r => r.GroupId == groups[i].Id).ToList();
                    //    lstModel.Add(model);
                    //}

                    return groups;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Page> GetHomeServices()
        {
            try
            {
                using (var entity = new dehunEntities())
                {
                    List<Page> homeservice = (from p in entity.Pages
                                        where p.Active == (int)Active.Show && p.Position.Contains(((int)PagePosition.MiddlePage).ToString())
                                        select p)
                                      .ToList();

                    return homeservice;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> GetOurServices()
        {
            try
            {
                using (var entity = new dehunEntities())
                {
                    List<Product> ourservice = (from p in entity.Products
                                                where p.Active == (int)Active.Show && p.IsPopular == (int)Active.Show && p.IsNew == 0
                                                select p)
                                              .ToList();

                    return ourservice;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ImagesModel> GetCompletedProject()
        {
            List<ImagesModel> models = new List<ImagesModel>();
            try
            {
                using (var entity = new dehunEntities())
                {
                    List<GroupImage> groups = (from g in entity.GroupImages
                                               where g.Active == 1
                                               select g).ToList();
                    List<Images> images = (from i in entity.Images1
                                            where i.Active == (int)Active.Show
                                            select i)
                                            .ToList();
                    foreach (var item in groups)
                    {
                        ImagesModel model = new ImagesModel();
                        model.group = item;
                        model.images = images.Where(r => r.GroupId == item.Id).ToList();
                        models.Add(model);
                    }
                    return models;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<News> GetHomeNews()
        {
            try
            {
                using (var entity = new dehunEntities())
                {
                    List<News> homenews = (from n in entity.News
                                           where n.Active == (int)Active.Show && n.Priority == (int)Active.Show
                                           select n)
                                            .ToList();

                    return homenews;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}