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
    public class DALFinancialYear
    {
        //create a db obj
        PosContext db = new PosContext();
        public List<ViewFinancialYear> GetAll()
        {
            //fetch db.animal data, and pull all rows table into RAM
            var financialYears = db.FinancialYears.ToList();
            //convert this data into view data
            var viewFinancialYears = new List<ViewFinancialYear>();
            foreach (var li in financialYears)
            {
                var viewFinancialYear = new ViewFinancialYear(li);
                viewFinancialYears.Add(viewFinancialYear);
            }
            //return
            return viewFinancialYears;
        }

        public ViewFinancialYear Get(int id)
        {
            var financialYear = db.FinancialYears.Find(id);
            return new ViewFinancialYear(financialYear);
        }
        public bool Save(FinancialYear financialYear)
        {
            db.FinancialYears.Add(financialYear);
            db.SaveChanges();
            return true;
        }
        public bool Update(FinancialYear financialYear)
        {
            db.Entry(financialYear).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public bool Delete(FinancialYear financialYear)
        {
            FinancialYear entity = db.FinancialYears.Find(financialYear.Id);
            db.FinancialYears.Remove(entity);
            db.SaveChanges();
            return true;
        }

        public FinancialYear GetDbModel(int id)
        {
            return db.FinancialYears.Find(id);
        }
    }
}
