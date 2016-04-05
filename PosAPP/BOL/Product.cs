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
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(300)]
        public string Name { get; set; }
        public int Stock { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string BarCode { get; set; }

        //public int CatId { get; set; }
        //[ForeignKey("CatId")]
        //public virtual Category Category { get; set; }
        public int ShopId { get; set; }
        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }

        //public int BrandId { get; set; }
        //[ForeignKey("BrandId")]
        //public virtual Brand Brand { get; set; }

        public int MeasurementId { get; set; }
        [ForeignKey("MeasurementId")]
        public virtual Measurement Measurement { get; set; }

    }
}
