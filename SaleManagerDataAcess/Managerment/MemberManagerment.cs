using BusinessObject.Models;
using DataAcess.Repository;
using Microsoft.EntityFrameworkCore;
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
        public bool CreateMember(Member model)
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

        public bool UpdateMember(Member model)
        {
            using (var context = new SaleManagerWPFContext())
            {
                var user = context.Members.Where(x => x.MemberId == model.MemberId).FirstOrDefault();
                if (user != null)
                {
                    user.Email = model.Email;
                    user.City = model.City;
                    user.Country = model.Country;
                    user.Password = model.Password;
                    user.CompanyName = model.CompanyName;
                    context.Members.Update(user);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool UserLogged(UserDto model)
        {
            using (var context = new SaleManagerWPFContext())
            {
                var user = context.Members.Where(x => x.Email == model.Username && x.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
                return false;
            }
        }
        public bool IsEmailExist(string email, int id)
        {
            bool check = false;
            using (var context = new SaleManagerWPFContext())
            {
                var currentUser = context.Members.Where(x => x.MemberId == id).FirstOrDefault();
                var listEmails = context.Members.Where(x => x.Email != currentUser.Email).Select(x => x.Email).ToList();
                if (listEmails.Any() && listEmails.Contains(email))
                {
                    check = true;
                }
                return check;
            }
        }
        public Member FindByEmail(string email)
        {
            using (var context = new SaleManagerWPFContext())
            {
                var user = context.Members.Where(x => x.Email == email).FirstOrDefault();
                return user;
            }
        }
    }

}
