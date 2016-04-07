using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Table("tblCategory")]
    public class Category
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Category Name is Required")]
        [Display(Name ="Category Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Create/Modification Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Create/Modification Date")]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
