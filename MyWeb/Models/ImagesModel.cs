using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeb.Entities;

namespace MyWeb.Models
{
    public partial class ImagesModel
    {
        public GroupImage group { get; set; }
        public List<Images> images { get; set; }
        public ImagesModel()
        {
            try
            {
                images = new List<Images>();
                using (var entity = new dehunEntities())
                {
                    List<Images> images = entity.Images1.Where(r => r.Priority == 1 && r.Active == 1).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}