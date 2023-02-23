using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Managerment
{
    public class OrderManagerment
    {
        private static OrderManagerment instance = null;
        private static readonly object instanceLock = new object();
        private OrderManagerment()
        {
        }

        public static OrderManagerment Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new OrderManagerment();
                }
                return instance;
            }
        }
        public List<Order> GetByMemberId(int memberId)
        {
            using (var context = new SaleManagerWPFContext())
            {
                var orders = context.Orders.Where(x => x.MemberId == memberId).ToList();
                return orders;
            }
        }
        public List<Order> GetAllOrders()
        {
            using (var context = new SaleManagerWPFContext())
            {
                return context.Orders.ToList();
            }
        }
        public bool CreateOrder(Order order)
        {
            using (var context = new SaleManagerWPFContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteOrder(int orderId)
        {
            using (var context = new SaleManagerWPFContext())
            {
                var orde = context.Orders.Where(x => x.OrderId == orderId).FirstOrDefault();
                if (orde != null)
                {
                    context.Orders.Remove(orde);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool UpdateOder(Order order)
        {
            using (var context = new SaleManagerWPFContext())
            {
                var orde = context.Orders.Where(x => x.OrderId == order.OrderId).FirstOrDefault();
                if (orde != null)
                {
                    orde.OrderDate = order.OrderDate;
                    orde.RequiredDate = order.RequiredDate;
                    orde.ShippedDate = order.ShippedDate;
                    orde.Freight = order.Freight;
                    orde.MemberId = order.MemberId;
                    context.Orders.Update(orde);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
