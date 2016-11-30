using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALMeasurement
    {
        //create a db obj
        PosContext db = new PosContext();
        public List<ViewMeasurement> GetAll()
        {
            //fetch db.animal data, and pull all rows table into RAM
            var financialYears = db.Measurements.ToList();
            //convert this data into view data
            var viewViewMeasurements = new List<ViewMeasurement>();
            foreach (var li in financialYears)
            {
                var viewViewMeasurement = new ViewMeasurement(li);
                viewViewMeasurements.Add(viewViewMeasurement);
            }
            //return
            return viewViewMeasurements;
        }

        public ViewMeasurement Get(int id)
        {
            var measurement = db.Measurements.Find(id);
            return new ViewMeasurement(measurement);
        }
        public bool Save(Measurement measurement)
        {
            db.Measurements.Add(measurement);
            db.SaveChanges();
            return true;
        }
        public bool Update(Measurement measurement)
        {
            db.Entry(measurement).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public bool Delete(Measurement measurement)
        {
            Measurement entity = db.Measurements.Find(measurement.Id);
            db.Measurements.Remove(entity);
            db.SaveChanges();
            return true;
        }

        public Measurement GetDbModel(int id)
        {
            return db.Measurements.Find(id);
        }
    }
}
