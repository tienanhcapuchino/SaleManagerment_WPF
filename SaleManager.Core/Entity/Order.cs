using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Core.Entity
{
    internal class Order
    {
        public int Id { get; set; }
        public Member MemberMember { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public double Freigth { get; set; }
    }
}
