﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Table("tblFinancialYear")]
    public class FinancialYear
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartingDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime EndingDate { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }
       
        public virtual ICollection<Shop> FinancialYears { get; set; }
    }
}
