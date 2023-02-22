using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Managerment
{
    public class ProductManagerment
    {
        private static ProductManagerment instance = null;
        private static readonly object instanceLock = new object();
        private ProductManagerment()
        {
        }

        public static ProductManagerment Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ProductManagerment();
                }
                return instance;
            }
        }
        public List<Product> GetAllProducts()
        {
            using (var context = new SaleManagerWPFContext())
            {
                return context.Products.ToList();
            }
        }
        public List<Product> SearchProductById(int id)
        {
            using (var context = new SaleManagerWPFContext())
            {
                return context.Products.Where(x => x.ProductId == id).ToList();
            }
        }
        public List<Product> SearchProductByName(string name)
        {
            using (var context = new SaleManagerWPFContext())
            {
                return context.Products.Where(x => x.ProductName.Contains(name)).ToList();
            }
        }
        public List<Product> SearchProductByPrice(int price)
        {
            using (var context = new SaleManagerWPFContext())
            {
                return context.Products.Where(x => x.UnitPrice == price).ToList();
            }
        }
        public List<Product> SearchProductByStocks(int stocks)
        {
            using (var context = new SaleManagerWPFContext())
            {
                return context.Products.Where(x => x.UnitsInStock == stocks).ToList();
            }
        }
        public bool AddNewProduct(Product product)
        {
            using (var context = new SaleManagerWPFContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
                return true;
            }
        }
        public bool UpdateProduct(Product product)
        {
            using (var context = new SaleManagerWPFContext())
            {
                var entity = context.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
                if (entity != null)
                {
                    entity.ProductName = product.ProductName;
                    entity.UnitPrice = product.UnitPrice;
                    entity.UnitsInStock = product.UnitsInStock;
                    entity.Weight = product.Weight;
                    entity.CategoryId = product.CategoryId;
                    context.Products.Update(entity);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool DeleteProduct(int productId)
        {
            using (var context = new SaleManagerWPFContext())
            {
                var product = context.Products.Where(x => x.ProductId == productId).FirstOrDefault();
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
