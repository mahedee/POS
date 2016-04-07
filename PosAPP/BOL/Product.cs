using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Table("tblProduct")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Product Name is Required")]
        [Display(Name ="Product Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        public string Name { get; set; }

        [Display(Name ="Stock")]
        public int Stock { get; set; }

        [Display(Name ="Barcode")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]
        public string BarCode { get; set; }

        //[Display(Name ="Category Id")]
        //public int CatId { get; set; }
        //[ForeignKey("CatId")]
        //public virtual Category Category { get; set; }

        public int ShopId { get; set; }
        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }

        //[Display(Name ="Brand Id")]
        //public int BrandId { get; set; }
        //[ForeignKey("BrandId")]
        //public virtual Brand Brand { get; set; }

        public int MeasurementId { get; set; }
        [ForeignKey("MeasurementId")]
        public virtual Measurement Measurement { get; set; }

        [Required(ErrorMessage = "Create/Modification Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Create/Modification Date")]
        public DateTime ModifiedDate { get; set; }

    }
}
