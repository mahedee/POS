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
        public ActionResult Index(int ProductId = 0)
        {
            var customerList = db.Customers.ToList();
            ViewBag.Customers = customerList;

            var productList = db.Products.ToList();
            ViewBag.Products = productList;
            return View();
        }
        
        [HttpGet]
        public JsonResult GetProductInfo(int id)
        {
            string[] pp = new string[3];
            var product = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            var pur = db.PurchaseDetails.Where(x => x.ProductId == id).OrderByDescending(x => x.PurchaseDetailId).FirstOrDefault();
            pp[0] = product.Stock.ToString();
            pp[1] = pur.BarCode.ToString();
            pp[2] = pur.SRate.ToString();
            return Json(pp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveSales(Sales objSales)
        {

            bool status = false;
            if (ModelState.IsValid)
            {
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
	}
}