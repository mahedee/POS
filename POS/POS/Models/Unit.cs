using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class Unit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Unit Id")]
        public int UnitId { get; set; }

        [Required(ErrorMessage = "Unit name is required.")]
        [StringLength(40, MinimumLength = 1)]
        [Display(Name = "Unit Name")]
        public int UnitName { get; set; }

        [Required(ErrorMessage = "Create/Modification Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Create/Modification Date")]
        public DateTime ModifiedDate { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}