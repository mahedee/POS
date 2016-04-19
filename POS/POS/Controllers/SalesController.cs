using POS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Controllers
{
    public class SalesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Purchase
        public ActionResult Index()
        {
            var customerList = db.Customers.ToList();
            ViewBag.Customers = customerList;

            var productList = db.Products.ToList();
            ViewBag.Products = productList;
            return View();
        }

        [HttpPost]
        public JsonResult SaveSales(Sales objSales)
        {

            bool status = false;
            if (ModelState.IsValid)
            {
                //string currentUser = User.Identity.GetUserId();

                //objPurchase.CreatedBy = currentUser;
                //objPurchase.CreatedAt = DateTime.Now;
                //objPurchase.UpdatedAt = DateTime.Now;

                List<Product> productList = new List<Product>();

                using (ApplicationDbContext dc = new ApplicationDbContext())
                {
                    foreach (SalesDetail p in objSales.SalesDetailses)
                    {
                        Product product = dc.Products.Where(x => x.ProductId == p.ProductId).FirstOrDefault();
                        product.Stock = product.Stock - p.Quantity;

                        productList.Add(product);
                        
                    }
                    dc.Saleses.Add(objSales);
                    foreach (var p in productList)
                    {
                        dc.Entry(p).State = EntityState.Modified;
                    }

                    dc.SaveChanges();
                    status = true;
                }
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }


        [HttpPost]
        //public JsonResult GetProductData(string productID)
        //{
        //    Product product = Product.GetProduct(Convert.ToInt32(productID));
        //    if (product != null)
        //    {
        //        return Json(new { success = true, productName = product.Name });
        //    }
        //    return Json(new { success = false });

        //}
	}
}