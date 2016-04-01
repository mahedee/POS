using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Table("tblShop")]
    public class Shop
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Address { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string WebAddress { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Phone { get; set; }

        public virtual ICollection<FinancialYear> FinancialYears { get; set; }
        public virtual ICollection<Product>Products { get; set; }

        //public virtual FinancialYear FinancialYear { get; set; }
        //public virtual Product Product { get; set; }
    }

}
