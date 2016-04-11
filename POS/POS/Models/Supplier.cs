using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    [Table("Supplier")]
    public class Supplier : CommonProperties
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string Mobile { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Address { get; set; }

        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}