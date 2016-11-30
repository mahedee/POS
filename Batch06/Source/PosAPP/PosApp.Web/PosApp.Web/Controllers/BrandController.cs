using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;
using DAL;

namespace PosApp.Web.Controllers
{
    public class BrandController : Controller
    {
        DALBrand dal = new DALBrand(); 
        // GET: Brand
        public ActionResult Index()
        {
            var viewBrand = dal.GetAll();
            return View(viewBrand);
        }

        // GET: Brand/Details/5
        public ActionResult Details(int id)
        {
            ViewBrand viewBrand = dal.Get(id);
            return View(viewBrand);
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            try
            {
                // TODO: Add insert logic here
                bool saved = dal.Save(brand);
                if (saved)
                {
                    return RedirectToAction("Index");
                }

                return View(brand);
            }
            catch
            {
                return View();
            }
        }

        // GET: Brand/Edit/5
        public ActionResult Edit(int id)
        {
            Brand brand = dal.GetDbModel(id);
            return View(brand);
        }

        // POST: Brand/Edit/5
        [HttpPost]
        public ActionResult Edit(Brand brand)
        {
            try
            {
                // TODO: Add update logic here
                bool update = dal.Update(brand);
                if (update)
                {
                    return RedirectToAction("Index");
                }
                return View(brand);
            }
            catch
            {
                return View();
            }
        }

        // GET: Brand/Delete/5
        public ActionResult Delete(int id)
        {
            Brand brand = dal.GetDbModel(id);
            return View(brand);
        }

        // POST: Brand/Delete/5
        [HttpPost]
        public ActionResult Delete(Brand brand)
        {
            try
            {
                // TODO: Add delete logic here
                bool deleted = dal.Delete(brand);
                if (deleted)
                {
                    return RedirectToAction("Index");
                }

                return View(brand);
            }
            catch
            {
                return View();
            }
        }
    }
}
