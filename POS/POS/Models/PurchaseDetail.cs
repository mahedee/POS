using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    [Table("PurchaseDetails")]
    public class PurchaseDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseDetailId { get; set; }

        public int PurchaseId { get; set; }
        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }

        [Required(ErrorMessage = "Please choose a product")]
        public int ProductId { get; set; }

        [RegularExpression(@"^([A-Z a-z 0-9 -]+)*$", ErrorMessage = "Only characters & Numbers are allowed!")]
        [Display(Name = "Barcode")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string BarCode { get; set; }

        public double Quantity { get; set; }
        public double PRate { get; set; }
        public double SRate { get; set; }
        public double Vat { get; set; }
        public double Discount { get; set; }
    }
}