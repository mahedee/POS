using BLL;
using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PosApp.Web.Controllers
{
    public class FinancialYearController : Controller
    {
        DALFinancialYear dal = new DALFinancialYear();
        // GET: FinancialYear
        public ActionResult Index()
        {
            var viewFinancialYear = dal.GetAll();
            return View(viewFinancialYear);
        }

        // GET: FinancialYear/Details/5
        public ActionResult Details(int id)
        {
            ViewFinancialYear viewFinancialYear = dal.Get(id);
            return View(viewFinancialYear);
        }

        // GET: FinancialYear/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinancialYear/Create
        [HttpPost]
        public ActionResult Create(FinancialYear financialYear)
        {
            try
            {
                // TODO: Add insert logic here
                bool saved = dal.Save(financialYear);
                if (saved)
                {
                    return RedirectToAction("Index");
                }

                return View(financialYear);
            }
            catch
            {
                return View();
            }
        }

        // GET: FinancialYear/Edit/5
        public ActionResult Edit(int id)
        {
            FinancialYear financialYear = dal.GetDbModel(id);
            return View(financialYear);
        }

        // POST: FinancialYear/Edit/5
        [HttpPost]
        public ActionResult Edit(FinancialYear financialYear)
        {
            try
            {
                // TODO: Add update logic here
                bool update = dal.Update(financialYear);
                if (update)
                {
                    return RedirectToAction("Index");
                }
                return View(financialYear);
            }
            catch
            {
                return View();
            }
        }

        // GET: FinancialYear/Delete/5
        public ActionResult Delete(int id)
        {
            FinancialYear financialYear = dal.GetDbModel(id);
            return View(financialYear);
        }

        // POST: FinancialYear/Delete/5
        [HttpPost]
        public ActionResult Delete(FinancialYear financialYear)
        {
            try
            {
                // TODO: Add delete logic here
                bool deleted = dal.Delete(financialYear);
                if (deleted)
                {
                    return RedirectToAction("Index");
                }

                return View(financialYear);
            }
            catch
            {
                return View();
            }
        }
    }
}
