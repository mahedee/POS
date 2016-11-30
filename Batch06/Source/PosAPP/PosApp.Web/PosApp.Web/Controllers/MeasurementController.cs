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
    public class MeasurementController : Controller
    {
        DALMeasurement dal = new DALMeasurement();
        // GET: Measurement
        public ActionResult Index()
        {
            var viewMeasurement = dal.GetAll();
            return View(viewMeasurement);
        }

        // GET: Measurement/Details/5
        public ActionResult Details(int id)
        {
            ViewMeasurement viewMeasurement = dal.Get(id);
            return View(viewMeasurement);
        }

        // GET: Measurement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Measurement/Create
        [HttpPost]
        public ActionResult Create(Measurement measurement)
        {
            try
            {
                // TODO: Add insert logic here
                bool saved = dal.Save(measurement);
                if (saved)
                {
                    return RedirectToAction("Index");
                }

                return View(measurement);
            }
            catch
            {
                return View();
            }
        }

        // GET: Measurement/Edit/5
        public ActionResult Edit(int id)
        {
            Measurement measurement = dal.GetDbModel(id);
            return View(measurement);
        }

        // POST: Measurement/Edit/5
        [HttpPost]
        public ActionResult Edit(Measurement measurement)
        {
            try
            {
                // TODO: Add update logic here
                bool update = dal.Update(measurement);
                if (update)
                {
                    return RedirectToAction("Index");
                }
                return View(measurement);
            }
            catch
            {
                return View();
            }
        }

        // GET: Measurement/Delete/5
        public ActionResult Delete(int id)
        {
            Measurement measurement = dal.GetDbModel(id);
            return View(measurement);
        }

        // POST: Measurement/Delete/5
        [HttpPost]
        public ActionResult Delete(Measurement measurement)
        {
            try
            {
                // TODO: Add delete logic here
                bool deleted = dal.Delete(measurement);
                if (deleted)
                {
                    return RedirectToAction("Index");
                }

                return View(measurement);
            }
            catch
            {
                return View();
            }
        }
    }
}
