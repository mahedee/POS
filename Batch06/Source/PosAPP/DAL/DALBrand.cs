using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BOL;

namespace DAL
{
    public class DALBrand
    {
        PosContext db = new PosContext();
        public List<ViewBrand> GetAll()
        {
            //fetch db.animal data, and pull all rows table into RAM
            var brands = db.Brands.ToList();
            //convert this data into view data
            var viewBrands = new List<ViewBrand>();
            foreach (var li in brands)
            {
                var viewBrand = new ViewBrand(li);
                viewBrands.Add(viewBrand);
            }
            //return
            return viewBrands;
        }

        public ViewBrand Get(int id)
        {
            var brand = db.Brands.Find(id);
            return new ViewBrand(brand);
        }
        public bool Save(Brand brand)
        {
            db.Brands.Add(brand);
            db.SaveChanges();
            return true;
        }
        public bool Update(Brand brand)
        {
            db.Entry(brand).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public bool Delete(Brand brand)
        {
            Brand entity = db.Brands.Find(brand.Id);
            db.Brands.Remove(entity);
            db.SaveChanges();
            return true;
        }

        public Brand GetDbModel(int id)
        {
            return db.Brands.Find(id);
        }
    }
}
