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
        List<Product> SearchProductById(int id);
        List<Product> SearchProductByName(string name);
        List<Product> SearchProductByPrice(int price);
        List<Product> SearchProductByStocks(int stocks);
        bool AddNewProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int productId);
    }
}
