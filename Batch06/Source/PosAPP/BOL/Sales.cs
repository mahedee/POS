using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Sales
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Sales Id")]
        public int SalesId { get; set; }

        [Required(ErrorMessage = "Sales Invoice number is required.")]
        [Display(Name = "Sales Invoice")]
        public string SalesInvoiceNo { get; set; }

        [Required(ErrorMessage = "Sales Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Sales Date")]
        public DateTime SalesDate { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [Display(Name = "Remarks")]
        [StringLength(200)]
        public string Remarks { get; set; }

        //public int InChargeUserId { get; set; }

        [Required(ErrorMessage = "Create/Modification Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Create/Modification Date")]
        public DateTime ModifiedDate { get; set; }

        public ICollection<SalesDetails> SalesDetailses { get; set; }
    }
}
