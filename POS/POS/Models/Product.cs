using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Barcode is required")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(40, MinimumLength = 1)]
        [Display(Name = "Product Name")]
        public int ProductName { get; set; }

        [Required(ErrorMessage = "Unit Price is required.")]
        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Current Stock is required.")]
        [Display(Name = "Current Stock")]
        public float CurrentStock { get; set; }

        [Required(ErrorMessage = "Create/Modification Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Create/Modification Date")]
        public DateTime ModifiedDate { get; set; }

        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int UnitId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
    }
}