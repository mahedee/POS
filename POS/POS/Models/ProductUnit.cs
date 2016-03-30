using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class ProductUnit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Unit Id")]
        public int UnitId { get; set; }
        
        [StringLength(50, MinimumLength = 1)]
        public string UnitName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Create/Modification Date")]
        public DateTime ModifiedDate { get; set; }
    }
}