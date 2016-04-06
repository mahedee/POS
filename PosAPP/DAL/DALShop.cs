using BOL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    class DALShop
    {
        //create a db obj
        PosContext db = new PosContext();
        public List<ViewShop> GetAll()
        {
            //fetch db.animal data, and pull all rows table into RAM
            var shops = db.Shops.ToList();
            //convert this data into view data
            var viewShops = new List<ViewShop>();
            foreach (var li in shops)
            {
                var viewShop = new ViewShop(li);
                viewShops.Add(viewShop);
            }
            //return
            return viewShops;
        }

        public ViewShop Get(int id)
        {
            var shop = db.Shops.Find(id);
            return new ViewShop(shop);
        }
        public bool Save(Shop shop)
        {
            db.Shops.Add(shop);
            db.SaveChanges();
            return true;
        }
        public bool Update(Shop shop)
        {
            db.Entry(shop).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public bool Delete(Shop shop)
        {
            Shop entity = db.Shops.Find(shop.Id);
            db.Shops.Remove(entity);
            db.SaveChanges();
            return true;
        }

        public Shop GetDbModel(int id)
        {
            return db.Shops.Find(id);
        }
    }
}
