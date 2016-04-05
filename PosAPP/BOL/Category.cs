﻿using System;
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
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
