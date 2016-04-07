using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace BLL
{
    public class ViewCategory
    {
        public ViewCategory(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            ModifiedDate = category.ModifiedDate;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
