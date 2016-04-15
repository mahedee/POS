using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.Models;
using System.Data.Entity;

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
            ViewBag.ProductId = productList;
            return View();
        }

        [HttpPost]
        public JsonResult SaveOrder(Purchase objPurchase)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext dc = new ApplicationDbContext())
                {
                    //Order order = new Order { OrderNo = O.OrderNo, OrderDate = O.OrderDate, Description = O.Description };
                    //foreach (var i in objOrder.OrderDetails)
                    //{
                    //    //
                    //    // i.TotalAmount = 
                    //    order.OrderDetails.Add(i);
                    //}
                    dc.Purchases.Add(objPurchase);
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





        //[HttpPost]
        //public JsonResult SaveOrder(Purchase O)
        //{
        //    bool status = false;
        //    if (ModelState.IsValid)
        //    {
        //        using (ApplicationDbContext db = new ApplicationDbContext())
        //        {
        //            Purchase purchase = new Purchase { InvoiceNo = O.InvoiceNo, PurchaseDate = O.PurchaseDate, SupplierId = O.SupplierId, Remarks = O.Remarks };

        //            foreach (var i in O.PurchaseDetails)
        //            {
        //                purchase.PurchaseDetails.Add(i);
        //            }
        //            db.Purchases.Add(O);
        //            db.SaveChanges();
        //            status = true;
        //        }
        //    }
        //    else
        //    {
        //        status = false;
        //    }
        //    return new JsonResult { Data = new { status = status } };
        //}

        //[HttpPost]
        //public JsonResult SavePurchase(Purchase O)
        //{
        //    bool status = false;
        //    if (ModelState.IsValid)
        //    {
        //        using (db)
        //        {
        //            db.Purchases.Add(O);
        //            db.SaveChanges();
        //            status = true;  
        //        }

        //        using (ApplicationDbContext db = new ApplicationDbContext())
        //        {
        //            Purchase order = new Purchase { InvoiceNo = O.InvoiceNo, PurchaseDate = O.PurchaseDate, 
        //                SupplierId = O.SupplierId, Remarks = O.Remarks };

        //            foreach (var i in db.PurchaseDetails)
        //            {
        //                //
        //                // i.TotalAmount = 
        //                order.PurchaseDetails.Add(i);
        //                //order.OrderDetails.Add(i);
        //            }
        //            db.Purchases.Add(order);
        //            //dc.Order.Add(objOrder);
        //            db.SaveChanges();
        //            status = true;
        //        }
        //    }
        //    else
        //    {
        //        status = false;
        //    }
        //    return new JsonResult { Data = new { status = status } };
        //}
    }
}