using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetByMemberId(int memberId);
        List<Order> GetAllOrders();
        bool CreateOrder(Order order);
        bool DeleteOrder(int orderId);
        bool UpdateOder(Order order);
    }
}
