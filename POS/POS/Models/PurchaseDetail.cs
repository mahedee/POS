using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    [Table("PurchaseDetails")]
    public class PurchaseDetail : CommonProperties
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PurchaseId { get; set; }
        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }

        [Required(ErrorMessage = "Please choose a product")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public double Quantity { get; set; }
        public double PRate { get; set; }
        public double SRate { get; set; }
        public double Total { get; set; }
        public double PercentVat { get; set; }
        public double PercentDiscount { get; set; }
        public double SubTotal { get; set; }

    }
}