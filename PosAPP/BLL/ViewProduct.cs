using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ViewProduct
    {
        public ViewProduct(Product product)
        {
            Id=product.Id;
            MeasurementId = product.MeasurementId;
            Name = product.Name;
            Stock = product.Stock;
            BarCode = product.BarCode;
            ShopId = product.ShopId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public string BarCode { get; set; }
        public int ShopId { get; set; }
        public int MeasurementId { get; set; }
      

    }
}
