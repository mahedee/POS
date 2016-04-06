using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Table("tblBrand")]
    public  class Brand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand Name is Required")]
        [Display(Name ="Brand Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
