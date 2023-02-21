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
    }
}
