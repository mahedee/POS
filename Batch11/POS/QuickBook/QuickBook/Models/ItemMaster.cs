using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuickBook.Models
{
    public class ItemMaster
    {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ItemSrl { get; set; }
            public int ItemNo { get; set; }
            public string ItemName { get; set; }
            public string ItemType { get; set; }
    }
}