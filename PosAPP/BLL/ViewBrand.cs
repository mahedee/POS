using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace BLL
{
    public class ViewBrand
    {
        public ViewBrand(Brand brand)
        {
            Id = brand.Id;
            Name = brand.Name;
            ModifiedDate = brand.ModifiedDate;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
