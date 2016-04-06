using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Table("tblPurchase")]
    public class Purchase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string InvoiceNo { get; set; }

        public DateTime PurchaseDate { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Remarks { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Address { get; set; }

        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

    }
}
