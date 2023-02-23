using BusinessObject.Models;
using DataAcess.Managerment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public bool CreateOrder(Order order) => OrderManagerment.Instance.CreateOrder(order);

        public bool DeleteOrder(int orderId) => OrderManagerment.Instance.DeleteOrder(orderId);

        public List<Order> GetAllOrders() => OrderManagerment.Instance.GetAllOrders();

        public List<Order> GetByMemberId(int memberId) => OrderManagerment.Instance.GetByMemberId(memberId);

        public bool UpdateOder(Order order) => OrderManagerment.Instance.UpdateOder(order);
    }
}
