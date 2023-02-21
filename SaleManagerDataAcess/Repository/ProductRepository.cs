using BusinessObject.Models;
using DataAcess.Managerment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAllProducts() => ProductManagerment.Instance.GetAllProducts();
        public List<Product> SearchProduct(int? id, string name, int? unitPrice, int? unitStocks) => ProductManagerment.Instance.SearchProduct(id, name, unitPrice, unitStocks);
    }
}
