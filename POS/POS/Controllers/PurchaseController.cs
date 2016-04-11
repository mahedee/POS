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
    }
}