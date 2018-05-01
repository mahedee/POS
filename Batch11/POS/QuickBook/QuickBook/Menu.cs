using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBook
{
    public class Menu
    {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public int ParentMenuId { get; set; }
        public List<Menu> List { get; set; }
    }
}