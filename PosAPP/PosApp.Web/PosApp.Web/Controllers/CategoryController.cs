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
    public class CategoryController : Controller
    {
        DALCategory dal = new DALCategory();
        // GET: Category
        public ActionResult Index()
        {
            var viewCategory = dal.GetAll();
            return View(viewCategory);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            ViewCategory viewCategory = dal.Get(id);
            return View(viewCategory);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                // TODO: Add insert logic here
                bool saved = dal.Save(category);
                if (saved)
                {
                    return RedirectToAction("Index");
                }

                return View(category);
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = dal.GetDbModel(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                // TODO: Add update logic here
                bool update = dal.Update(category);
                if (update)
                {
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = dal.GetDbModel(id);
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            try
            {
                // TODO: Add delete logic here
                bool deleted = dal.Delete(category);
                if (deleted)
                {
                    return RedirectToAction("Index");
                }

                return View(category);
            }
            catch
            {
                return View();
            }
        }
    }
}
