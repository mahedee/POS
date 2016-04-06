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

        [Display(Name ="Shop Id")]
        public int Id { get; set; }

        [Display(Name ="Shop Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Name { get; set; }

        [Display(Name ="Address")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(300)]
        public string Address { get; set; }

        [Display(Name = "Email Address")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Web Address")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string WebAddress { get; set; }

        [Display(Name ="Phone Number")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string Phone { get; set; }

        public int FinancialYearId { get; set; }
        [ForeignKey("FinancialYearId")]
        public virtual FinancialYear FinancialYear { get; set; }
        //public virtual ICollection<Product>Products { get; set; }

        //public virtual FinancialYear FinancialYear { get; set; }
        //public virtual Product Product { get; set; }
    }

}
