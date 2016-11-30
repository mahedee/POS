using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ViewMeasurement
    {
        public ViewMeasurement(Measurement measurement)
        {
            Id = measurement.Id;
            Name = measurement.Name;
        }
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}
