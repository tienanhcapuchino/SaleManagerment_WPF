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
        public List<Product> SearchProductById(int id) => ProductManagerment.Instance.SearchProductById(id);

        public List<Product> SearchProductByName(string name) => ProductManagerment.Instance.SearchProductByName(name);

        public List<Product> SearchProductByPrice(int price) => ProductManagerment.Instance.SearchProductByPrice(price);

        public List<Product> SearchProductByStocks(int stocks) => ProductManagerment.Instance.SearchProductByStocks(stocks);
        public bool AddNewProduct(Product product) => ProductManagerment.Instance.AddNewProduct(product);
        public bool UpdateProduct(Product product) => ProductManagerment.Instance.UpdateProduct(product);
        public bool DeleteProduct(int productId) => ProductManagerment.Instance.DeleteProduct(productId);
    }
}
