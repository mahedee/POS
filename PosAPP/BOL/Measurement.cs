using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    //[Table("tblMeasurement")]
    public class Measurement
    {
        [Display(Name ="Measurement Id")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Measurement Name is Required")]
        [Display(Name ="Measurement")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
