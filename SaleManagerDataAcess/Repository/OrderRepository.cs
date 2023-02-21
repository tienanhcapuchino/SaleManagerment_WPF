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
        public List<Order> GetByMemberId(int memberId) => OrderManagerment.Instance.GetByMemberId(memberId);
    }
}
