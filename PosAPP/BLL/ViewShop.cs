using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ViewShop
    {
        public ViewShop(Shop shop)
        {
            Id = shop.Id;
            Name = shop.Name;
            Address = shop.Address;
            Email = shop.Email;
            WebAddress = shop.WebAddress;
            Phone = shop.Phone;
            FinancialYearId = shop.FinancialYearId;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string WebAddress { get; set; }
        public string Phone { get; set; }
        public int FinancialYearId { get; set; }
    }
}
