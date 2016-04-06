using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Table("tblSupplier")]
    public class Supplier
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Mobile { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Address { get; set; }

        public virtual ICollection<Purchase> FinancialYears { get; set; }
    }
}
