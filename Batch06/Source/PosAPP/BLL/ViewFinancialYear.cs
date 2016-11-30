using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ViewFinancialYear
    {

        public ViewFinancialYear(FinancialYear financialYear)
        {
            Id=financialYear.Id;
            StartingDate= financialYear.StartingDate;
            EndingDate = financialYear.EndingDate;
            Name = financialYear.Name;
        }

        public int Id { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string Name { get; set; }
    }
}
