using BusinessObject.Models;
using System;
using System.Collections.Generic;
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
        public List<Product> SearchProduct(int? id, string name, int? unitPrice, int? unitStocks)
        {
            using (var context = new SaleManagerWPFContext())
            {
                List<Product> products = new List<Product>();
                if (id != null)
                {
                    products = context.Products.Where(x => x.ProductId == id).ToList();
                }
                if (name != null)
                {
                    products = products.Where(x => x.ProductName.Contains(name)).ToList();
                }
                if (unitPrice != null)
                {
                    products = products.Where(x => x.UnitPrice == unitPrice).ToList();
                }
                if (unitStocks != null)
                {
                    products = products.Where(x => x.UnitsInStock == unitStocks).ToList();
                }
                //else
                //{

                //    products = context.Products
                //        .Where(x => x.ProductName.Contains(name)
                //    && x.UnitPrice == unitPrice
                //    && x.UnitsInStock == unitStocks)
                //        .ToList();
                //}
                return products;
            }
        }
    }
}
