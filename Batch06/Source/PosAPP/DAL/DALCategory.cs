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
    public class DALCategory
    {
        PosContext db = new PosContext();
        public List<ViewCategory> GetAll()
        {
            var categories = db.Categories.ToList();
            var viewCategories = new List<ViewCategory>();
            foreach (var li in categories)
            {
                var viewCategory = new ViewCategory(li);
                viewCategories.Add(viewCategory);
            }
            return viewCategories;
        }

        public ViewCategory Get(int id)
        {
            var category = db.Categories.Find(id);
            return new ViewCategory(category);
        }
        public bool Save(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return true;
        }
        public bool Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public bool Delete(Category category)
        {
            Category entity = db.Categories.Find(category.Id);
            db.Categories.Remove(entity);
            db.SaveChanges();
            return true;
        }

        public Category GetDbModel(int id)
        {
            return db.Categories.Find(id);
        }
    }
}
