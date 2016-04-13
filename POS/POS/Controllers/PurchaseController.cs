using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Models;

namespace POS.Controllers
{
    public class PurchaseController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Purchase
        public ActionResult Index()
        {
            var supplierList = db.Suppliers.ToList();
            ViewBag.Suppliers = supplierList;

            var productList = db.Products.ToList();
            ViewBag.Products = productList;
            return View();
        }

        [HttpPost]
        public JsonResult SavePurchase(Purchase objPurchase)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (db)
                {
                    db.Purchases.Add(objPurchase);
                    db.SaveChanges();
                    status = true;  
                }
                
                //using (DemoDBContext dc = new DemoDBContext())
                //{
                //    //////Order order = new Order { OrderNo = O.OrderNo, OrderDate = O.OrderDate, Description = O.Description };
                //    //////foreach (var i in objOrder.OrderDetails)
                //    //////{
                //    //////    //
                //    //////    // i.TotalAmount = 
                //    //////    order.OrderDetails.Add(i);
                //    //////}
                //    dc.Order.Add(objOrder);
                //    dc.SaveChanges();
                //    status = true;
                //}
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}