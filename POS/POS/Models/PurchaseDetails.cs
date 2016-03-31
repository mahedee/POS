using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class PurchaseDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Purchase Details Id")]
        public int PurchaseDetailsId { get; set; }

        public int PurchaseId { get; set; }
        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Purchase rate is required.")]
        [Display(Name = "Purchase Rate")]
        [DataType(DataType.Currency)]
        public decimal PurchaseRate { get; set; }

        [Required(ErrorMessage = "Sales rate is required.")]
        [Display(Name = "Sales Rate")]
        [DataType(DataType.Currency)]
        public decimal SalesRate { get; set; }

        [Display(Name = "Vat")]
        public float Vat { get; set; }

        [Display(Name = "Discount")]
        public float Discount { get; set; }

        [Required(ErrorMessage = "Manufacturing Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Manufacturing Date")]
        public DateTime ManufacturingDate { get; set; }

        [Required(ErrorMessage = "Expiry Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }

        [Required(ErrorMessage = "Create/Modification Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Create/Modification Date")]
        public DateTime ModifiedDate { get; set; }

    }
}