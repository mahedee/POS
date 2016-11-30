using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALProduct
    {
        //create a db obj
        PosContext db = new PosContext();
        public List<ViewProduct> GetAll()
        {
            //fetch db.animal data, and pull all rows table into RAM
            var products = db.Products.ToList();
            //convert this data into view data
            var viewProducts = new List<ViewProduct>();
            foreach (var li in products)
            {
                var viewProduct = new ViewProduct(li);
                viewProducts.Add(viewProduct);
            }
            //return
            return viewProducts;
        }

        public ViewProduct Get(int id)
        {
            var product = db.Products.Find(id);
            return new ViewProduct(product);
        }
        public bool Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return true;
        }
        public bool Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public bool Delete(Product product)
        {
            Product entity = db.Products.Find(product.Id);
            db.Products.Remove(entity);
            db.SaveChanges();
            return true;
        }

        public Product GetDbModel(int id)
        {
            return db.Products.Find(id);
        }
    }
}
