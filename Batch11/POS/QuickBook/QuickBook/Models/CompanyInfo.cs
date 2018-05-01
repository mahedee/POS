using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuickBook.Models
{
    public class CompanyInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerialNo { get; set; }
        public string CompanyNo { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
    }
}