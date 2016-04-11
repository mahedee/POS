using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    [Table("Purchase")]
    public class Purchase : CommonProperties
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter an invoice number")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string InvoiceNo { get; set; }

        [Required(ErrorMessage = "Please select a date")]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Please choose a supplier")]
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Remarks { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive total")]
        public double Total { get; set; }

        public double Vat { get; set; }
        public double Discount { get; set; }
        public double PercentDiscount { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive grand total")]
        public double GrandTotal { get; set; }

        public double DueTotal { get; set; }

        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}