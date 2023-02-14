using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Core.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public Product ProductEntity { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public double UnitPrice { get; set; }
        public int UnitInStock { get; set; }
    }
}
