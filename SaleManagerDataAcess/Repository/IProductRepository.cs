using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        List<Product> SearchProduct(int? id, string name, int? unitPrice, int? unitStocks);
    }
}
