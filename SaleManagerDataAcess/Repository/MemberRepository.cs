using BusinessObject.Models;
using DataAcess.Managerment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public class MemberRepository : IMemberRepository
    {

        public bool CreateMember(Member model) => MemberManagerment.Instance.CreateMember(model);

        public List<Member> GetAllMembers() => MemberManagerment.Instance.GetAllMembers();

        public Member GetById(int id) => MemberManagerment.Instance.GetById(id);

        public bool UpdateMember(Member model) => MemberManagerment.Instance.UpdateMember(model);
        public bool UserLogged(UserDto model) => MemberManagerment.Instance.UserLogged(model);
        public bool IsEmailExist(string email, int id) => MemberManagerment.Instance.IsEmailExist(email, id);
        public Member FindByEmail(string email) => MemberManagerment.Instance.FindByEmail(email);
    }
}
