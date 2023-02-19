using BusinessObject.Models;
using DataAcess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Managerment
{
    public class MemberManagerment
    {
        private static MemberManagerment instance = null;
        private static readonly object instanceLock = new object();
        private MemberManagerment()
        {
        }

        public static MemberManagerment Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new MemberManagerment();
                }
                return instance;
            }
        }
        public Task<bool> CreateMember(Member model)
        {
            throw new NotImplementedException();
        }
        public List<Member> GetAllMembers()
        {
            using (var context1 = new SaleManagerWPFContext())
            {
                return context1.Members.ToList();
            }
        }

        public Member GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMember(Member model)
        {
            throw new NotImplementedException();
        }
    }
}
