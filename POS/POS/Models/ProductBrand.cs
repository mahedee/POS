using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class ProductBrand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Brand Id")]
        public int BrandId { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string BrandName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Create/Modification Date")]
        public DateTime ModifiedDate { get; set; }
    }
}